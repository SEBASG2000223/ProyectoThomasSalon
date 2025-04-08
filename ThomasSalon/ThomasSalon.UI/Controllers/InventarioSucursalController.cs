using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Usuarios.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.InventarioSucursal;
using ThomasSalon.Abstracciones.LN.Interfaces.InventarioSucursal.Crear;
using ThomasSalon.Abstracciones.LN.Interfaces.InventarioSucursal.Editar;
using ThomasSalon.Abstracciones.LN.Interfaces.Productos.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Productos.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.Sucursales.Listar;
using ThomasSalon.Abstracciones.Modelos.InventarioSucursal;
using ThomasSalon.AccesoADatos;
using ThomasSalon.AccesoADatos.Usuarios.ObtenerPorId;
using ThomasSalon.LN.InventarioSucursal.Crear;
using ThomasSalon.LN.InventarioSucursal.Editar;
using ThomasSalon.LN.InventarioSucursal.Listar;
using ThomasSalon.LN.InventarioSucursal.ObtenerPorId;
using ThomasSalon.LN.Productos.Listar;
using ThomasSalon.LN.Productos.ObtenerPorId;
using ThomasSalon.LN.Sucursales.Listar;

namespace ThomasSalon.UI.Controllers
{
    public class InventarioSucursalController : Controller
    {
        IListarInventarioSucursalLN _listarInventarioSucursal;
        ICrearInventarioSucursalLN _crearInventarioSucursal;
        IObtenerProductosPorIdLN _obtenerProductosPorId;
        IListarSucursalesLN _sucursalesListar;
        IListarProductosLN _listarProductos;
        IEditarInventarioSucursalLN _editarInventarioSucursal;
        IObtenerInventarioSucursalPorIdLN _obtenerInventarioSucursal;
        IObtenerUsuariosPorIdAD _obtenerUsuarioPorId;
        Contexto _elContexto;

        public InventarioSucursalController()
        {
            _listarInventarioSucursal = new ListarInventarioSucursalLN();
            _crearInventarioSucursal = new CrearInventarioSucursalLN();
            _obtenerProductosPorId = new ObtenerProductosPorIdLN();
            _sucursalesListar = new ListarSucursalesLN();
            _listarProductos = new ListarProductosLN();
            _obtenerUsuarioPorId = new ObtenerUsuariosPorIdAD();
            _editarInventarioSucursal = new EditarInventarioSucursalLN();
            _obtenerInventarioSucursal = new ObtenerInventarioSucursalPorIdLN();
            _elContexto = new Contexto();
        }

        // GET: InventarioSucursal
        public ActionResult ListarInventarioSucursal(int idSucursal)
        {
            try
            {
                TempData["IdSucursalSeleccionada"] = idSucursal;
                var userId = User.Identity.GetUserId();
                var usuarioActual = _obtenerUsuarioPorId.Obtener(userId);


                if (usuarioActual == null)
                {
                    throw new Exception("Usuario no encontrado.");
                }

                if (User.IsInRole("Administrador") && usuarioActual.IdSucursal != idSucursal)
                {
                    return View("~/Views/Home/AccesoDenegado.cshtml");



                }

                List<InventarioSucursalDto> inventarios = _listarInventarioSucursal.Listar(idSucursal);
                if (inventarios == null || !inventarios.Any())
                {
                    ViewBag.Mensaje = "No hay productos en el inventario.";
                }

                return View(inventarios);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Ocurrió un error al cargar el inventario.";
                return RedirectToAction("Error", "Home");
            }
        }


        // GET: Productos/Details/5
        public ActionResult DetallesProducto(Guid IdInventario)
        {
            InventarioSucursalDto inventario = _listarInventarioSucursal.DetallesInventario(IdInventario).FirstOrDefault();
            var idSucursal = Convert.ToInt32(TempData["IdSucursalSeleccionada"] ?? 0);

            return View(inventario);
        }


        // GET: InventarioSucursal/AgregarInventarioSucursal
        public ActionResult AgregarInventarioSucursal()
        {
            var idSucursal = Convert.ToInt32(TempData["IdSucursalSeleccionada"] ?? 0);

            var productos = _listarInventarioSucursal.ListarProductosActivos(idSucursal); // Aquí pasamos idSucursal
            ViewBag.Productos = new SelectList(productos, "IdProducto", "Nombre");

            var modelo = new InventarioSucursalDto
            {
                IdSucursal = idSucursal
            };
            TempData.Keep("IdSucursalSeleccionada");

            return View(modelo);
        }



        // POST: InventarioSucursal/AgregarInventarioSucursal
        [HttpPost]
        public async Task<ActionResult> AgregarInventarioSucursal(InventarioSucursalDto modelo)
        {
            try
            {
                int cantidadDeDatosGuardados = await _crearInventarioSucursal.Agregar(modelo);

                return RedirectToAction("ListarInventarioSucursal", new { idSucursal = modelo.IdSucursal });
            }
            catch (InvalidOperationException ex)
            {
                var productos = _listarInventarioSucursal.ListarProductosActivos(modelo.IdSucursal);
                ViewBag.Productos = new SelectList(productos, "IdProducto", "Nombre");

                ViewBag.Mensaje = ex.Message;

                return View(modelo);
            }
            catch (Exception ex)
            {
                var productos = _listarInventarioSucursal.ListarProductosActivos(modelo.IdSucursal);
                ViewBag.Productos = new SelectList(productos, "IdProducto", "Nombre");

                ViewBag.Mensaje = "Ocurrió un error inesperado.";
                return View(modelo);
            }
        }


        // GET: InventarioSucursal/Edit/5
        public ActionResult ActualizarInventario(int id)
        {
            // Recuperar el idSucursal desde TempData y convertirlo con Convert.ToInt32
            var idSucursal = Convert.ToInt32(TempData["IdSucursalSeleccionada"] ?? 0);

            InventarioSucursalDto elInventario = _obtenerInventarioSucursal.Obtener(id, idSucursal);

            var modelo = new InventarioSucursalDto
            {
                IdSucursal = idSucursal,
                IdProducto = id,
                Cantidad = elInventario.Cantidad
            };
            TempData.Keep("IdSucursalSeleccionada");
            return View(modelo);
        }

        // POST: InventarioSucursal/Edit/5
        [HttpPost]
        public async Task<ActionResult> ActualizarInventario(InventarioSucursalDto modelo)
        {
            try
            {
                if (modelo.IdSucursal == 0)
                {
                    modelo.IdSucursal = Convert.ToInt32(TempData["IdSucursalSeleccionada"] ?? 0);
                }


                int cantidadDeDatosEditados = await _editarInventarioSucursal.Editar(modelo);
                TempData.Keep("IdSucursalSeleccionada");

                return RedirectToAction("ListarInventarioSucursal", new { idSucursal = modelo.IdSucursal });
            }
            catch (Exception ex)
            {

                ViewBag.Mensaje = "Ocurrió un error inesperado.";
                return View(modelo);
            }
        }


    }
}
