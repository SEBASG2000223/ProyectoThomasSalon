using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ThomasSalon.Abstracciones.LN.Interfaces.InventarioSucursal;
using ThomasSalon.Abstracciones.LN.Interfaces.Productos.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Servicios.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Sucursales.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Usuarios.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.Ventas.RegistrarVentaProducto;
using ThomasSalon.Abstracciones.LN.Ventas.RegistrarVentaServicio;
using ThomasSalon.Abstracciones.Modelos.Ventas.RegistrarVentaProducto;
using ThomasSalon.Abstracciones.Modelos.Ventas.RegistrarVentaServicio;
using ThomasSalon.AccesoADatos;
using ThomasSalon.LN.InventarioSucursal.Listar;
using ThomasSalon.LN.Servicios.Listar;
using ThomasSalon.LN.Sucursales.Listar;
using ThomasSalon.LN.Productos.Listar;
using ThomasSalon.LN.Usuarios.ObtenerPorId;
using ThomasSalon.LN.Ventas.RegistrarVentaProducto;
using ThomasSalon.LN.Ventas.RegistrarVentaServicio;

namespace ThomasSalon.UI.Controllers
{

    public class VentasController : Controller
    {
        private readonly Contexto _elContexto;
        IRegistrarVentaServicioLN _registrarVentaServicio;
        IObtenerUsuariosPorIdLN _obtenerUsuarioPorId;
        IListarSucursalesLN _listarSucursales;
        IListarServiciosLN _listarServicios;
        IRegistrarVentaProductoLN _registrarVentaProducto;
        IListarProductosLN _listarProductos;




        public VentasController()
        {
            _registrarVentaServicio = new RegistrarVentaServicioLN();
            _obtenerUsuarioPorId = new ObtenerUsuariosPorIdLN();
            _elContexto = new Contexto();
            _listarSucursales = new ListarSucursalesLN();
            _registrarVentaProducto = new RegistrarVentaProductoLN();
            _listarServicios = new ListarServiciosLN();
            _listarProductos = new ListarProductosLN();
        }

        // GET: Ventas
        public ActionResult Index()
        {
            return View();
        }

        // GET: Ventas/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        public async Task<ActionResult> RegistrarVentaProducto()
        {
            var metodosPago = await _elContexto.MetodosDePagoTabla.ToListAsync();
            ViewBag.MetodosPago = new SelectList(metodosPago, "IdMetodoPago", "Nombre");

            var hoy = DateTime.Today;

            var asistenciaConNombre = (from ac in _elContexto.AsistenciaColaboradorTabla
                                       join colab in _elContexto.ColaboradoresTabla on ac.IdColaborador equals colab.IdColaborador
                                       join per in _elContexto.PersonasTabla on colab.IdPersona equals per.IdPersona
                                       where DbFunctions.TruncateTime(ac.Fecha) == hoy
                                       select new
                                       {
                                           IdColaborador = ac.IdColaborador,
                                           Nombre = per.Nombre
                                       }).Distinct().ToList();

            ViewBag.Asistencia = new SelectList(asistenciaConNombre, "IdColaborador", "Nombre");

            var sucursales = _listarSucursales.ListarSucursalesActivas();
            ViewBag.Sucursales = new SelectList(sucursales, "IdSucursal", "Nombre");

            var productos = _listarProductos.ProductosActivos()
                .Select(p => new
                {
                    IdProducto = p.IdProducto,
                    Nombre = p.Nombre,
                    Precio = p.Precio
                }).ToList();

            ViewBag.Productos = productos.Select(p => new SelectListItem
            {
                Value = p.IdProducto.ToString(),
                Text = $"{p.Nombre} | {p.Precio:0.00}"
            }).ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegistrarVentaProducto(RegistrarVentaProductoDTO productoDto)
        {
            var userId = User.Identity.GetUserId();
            var usuarioActual = _obtenerUsuarioPorId.Obtener(userId);

            if (usuarioActual.IdSucursal.HasValue)
            {
                productoDto.IdSucursal = usuarioActual.IdSucursal.Value;
            }
            else
            {
                TempData["Error"] = "No se pudo registrar la venta: el usuario no tiene una sucursal asignada.";
                return View(productoDto);
            }

            if (!ModelState.IsValid)
            {
                await CargarViewBags(); // Método auxiliar para recargar los datos
                return View(productoDto);
            }

            // Verificación de stock
            foreach (var producto in productoDto.Productos)
            {
                var stockProducto = _elContexto.InventarioSucursalTabla
                    .FirstOrDefault(s => s.IdProducto == producto.IdProducto && s.IdSucursal == productoDto.IdSucursal);

                if (stockProducto == null || stockProducto.Cantidad < producto.Cantidad)
                {
                    TempData["Error"] = $"No hay suficiente stock del producto {producto.IdProducto}. Solo quedan {stockProducto?.Cantidad ?? 0} unidades disponibles en la sucursal.";
                    await CargarViewBags();
                    return View(productoDto);
                }
            }

            // Si todo está bien, se registra la venta
            var resultado = await _registrarVentaProducto.RegistrarVentaProducto(productoDto);

            // Actualizar inventario después de la venta
            foreach (var producto in productoDto.Productos)
            {
                var stockProducto = _elContexto.InventarioSucursalTabla
                    .FirstOrDefault(s => s.IdProducto == producto.IdProducto && s.IdSucursal == productoDto.IdSucursal);

                if (stockProducto != null)
                {
                    stockProducto.Cantidad -= producto.Cantidad;
                }
            }

            // Guardamos los cambios en el inventario
            _elContexto.SaveChanges();

            // Redirigir o mostrar mensaje de éxito
            return RedirectToAction("Index");
        }

        private async Task CargarViewBags()
        {
            ViewBag.MetodosPago = new SelectList(await _elContexto.MetodosDePagoTabla.ToListAsync(), "IdMetodoPago", "Nombre");

            var hoy = DateTime.Today;
            var asistenciaConNombre = (from ac in _elContexto.AsistenciaColaboradorTabla
                                       join colab in _elContexto.ColaboradoresTabla on ac.IdColaborador equals colab.IdColaborador
                                       join per in _elContexto.PersonasTabla on colab.IdPersona equals per.IdPersona
                                       where DbFunctions.TruncateTime(ac.Fecha) == hoy
                                       select new
                                       {
                                           IdColaborador = ac.IdColaborador,
                                           Nombre = per.Nombre
                                       }).Distinct().ToList();

            ViewBag.Asistencia = new SelectList(asistenciaConNombre, "IdColaborador", "Nombre");

            var sucursales = _listarSucursales.ListarSucursalesActivas();
            ViewBag.Sucursales = new SelectList(sucursales, "IdSucursal", "Nombre");

            var productos = _listarProductos.ProductosActivos()
                .Select(p => new
                {
                    IdProducto = p.IdProducto,
                    Nombre = p.Nombre,
                    Precio = p.Precio
                }).ToList();

            ViewBag.Productos = productos.Select(p => new SelectListItem
            {
                Value = p.IdProducto.ToString(),
                Text = $"{p.Nombre} | {p.Precio:0.00}"
            }).ToList();
        }


        // GET: Ventas/Create
        public async Task<ActionResult> RegistrarVentaServicio()
        {
            var metodosPago = await _elContexto.MetodosDePagoTabla.ToListAsync();
            ViewBag.MetodosPago = new SelectList(metodosPago, "IdMetodoPago", "Nombre");

            var hoy = DateTime.Today;

            var asistenciaConNombre = (from ac in _elContexto.AsistenciaColaboradorTabla
                                       join colab in _elContexto.ColaboradoresTabla on ac.IdColaborador equals colab.IdColaborador
                                       join per in _elContexto.PersonasTabla on colab.IdPersona equals per.IdPersona
                                       where DbFunctions.TruncateTime(ac.Fecha) == hoy
                                       select new
                                       {
                                           IdColaborador = ac.IdColaborador,
                                           Nombre = per.Nombre
                                       }).Distinct().ToList();

            ViewBag.Asistencia = new SelectList(asistenciaConNombre, "IdColaborador", "Nombre");




            var sucursales = _listarSucursales.ListarSucursalesActivas();
            ViewBag.Sucursales = new SelectList(sucursales, "IdSucursal", "Nombre");

            var servicios = _listarServicios.ListarActivos()
      .Select(s => new
      {
          IdServicio = s.IdServicio,
          Nombre = s.Nombre,
          Precio = s.Precio
      }).ToList();

            // Creamos un SelectList con Text = "Nombre | Precio"
            ViewBag.Servicios = servicios.Select(s => new SelectListItem
            {
                Value = s.IdServicio.ToString(),
                Text = $"{s.Nombre} | {s.Precio:0.00}"
            }).ToList();





            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegistrarVentaServicio(RegistrarVentaServicioDTO ventaDto)
        {
            var userId = User.Identity.GetUserId();
            var usuarioActual = _obtenerUsuarioPorId.Obtener(userId);
            var hoy = DateTime.Today;
            if (usuarioActual.IdSucursal.HasValue)
            {
                ventaDto.IdSucursal = usuarioActual.IdSucursal.Value;
            }
            else
            {
                TempData["Error"] = "No se pudo registrar la venta: el usuario no tiene una sucursal asignada.";
                return View(ventaDto);
            }



            var asistenciaConNombre = (from ac in _elContexto.AsistenciaColaboradorTabla
                                       join colab in _elContexto.ColaboradoresTabla on ac.IdColaborador equals colab.IdColaborador
                                       join per in _elContexto.PersonasTabla on colab.IdPersona equals per.IdPersona
                                       where DbFunctions.TruncateTime(ac.Fecha) == hoy
                                       select new
                                       {
                                           IdColaborador = ac.IdColaborador,
                                           Nombre = per.Nombre
                                       }).Distinct().ToList();

            ViewBag.Asistencia = new SelectList(asistenciaConNombre, "IdColaborador", "Nombre");
            var metodosPago = await _elContexto.MetodosDePagoTabla.ToListAsync();
            ViewBag.MetodosPago = new SelectList(metodosPago, "IdMetodoPago", "Nombre");
            var sucursales = _listarSucursales.ListarSucursalesActivas();
            ViewBag.Sucursales = new SelectList(sucursales, "IdSucursal", "Nombre");
            var servicios = _listarServicios.ListarActivos();
            ViewBag.Servicios = new SelectList(servicios, "IdServicio", "Nombre");

            if (!ModelState.IsValid)
            {
                return View(ventaDto);
            }

            try
            {
                var resultado = await _registrarVentaServicio.RegistrarVentaServicio(ventaDto);

                if (resultado < 0)
                {
                    TempData["Mensaje"] = "Venta registrada exitosamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = "No se pudo registrar la venta. Verifica que todos los campos estén completos y correctos.";
                    // También podrías loguear el contenido del DTO
                    System.Diagnostics.Debug.WriteLine("Venta fallida: " + JsonConvert.SerializeObject(ventaDto));
                    return View(ventaDto);
                }

            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al registrar la venta: " + ex.Message;
                return View(ventaDto);
            }
        }
        public JsonResult BuscarPersonaPorCedula(string cedula)
        {
            var persona = _elContexto.PersonasTabla.FirstOrDefault(p => p.Identificacion == cedula);

            if (persona != null)
            {
                return Json(new { idPersona = persona.IdPersona, nombre = persona.Nombre }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { idPersona = 0, nombre = "" }, JsonRequestBehavior.AllowGet);
        }



        // GET: Ventas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ventas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ventas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ventas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
