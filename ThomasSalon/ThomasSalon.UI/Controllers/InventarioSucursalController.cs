using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using ThomasSalon.Abstracciones.LN.Interfaces.InventarioSucursal;
using ThomasSalon.Abstracciones.LN.Interfaces.InventarioSucursal.Crear;
using ThomasSalon.Abstracciones.LN.Interfaces.InventarioSucursal.Editar;
using ThomasSalon.Abstracciones.LN.Interfaces.Productos.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Productos.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.Sucursales.Listar;
using ThomasSalon.Abstracciones.Modelos.InventarioSucursal;
using ThomasSalon.AccesoADatos;
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
        IListarProductosLN _productosListar;
        IListarSucursalesLN _sucursalesListar;
        IListarProductosLN _listarProductos;
        IEditarInventarioSucursalLN _editarInventarioSucursal;
        IObtenerInventarioSucursalPorIdLN _obtenerInventarioSucursal;
        Contexto _elContexto;

        public InventarioSucursalController()
        {
            _listarInventarioSucursal = new ListarInventarioSucursalLN();
            _crearInventarioSucursal = new CrearInventarioSucursalLN();
            _obtenerProductosPorId = new ObtenerProductosPorIdLN();
            _productosListar = new ListarProductosLN();
            _sucursalesListar = new ListarSucursalesLN();
            _listarProductos = new ListarProductosLN();
            _editarInventarioSucursal = new EditarInventarioSucursalLN();
            _obtenerInventarioSucursal = new ObtenerInventarioSucursalPorIdLN();
            _elContexto = new Contexto();
        }

        // GET: InventarioSucursal
        public ActionResult ListarInventarioSucursal(int idSucursal)
        {
            TempData["IdSucursalSeleccionada"] = idSucursal;
            List<InventarioSucursalDto> inventarios = _listarInventarioSucursal.Listar(idSucursal);
            if (inventarios == null || !inventarios.Any())
            {
                ViewBag.Mensaje = "No hay productos en el inventario.";
            }

            return View(inventarios);
        }




        // GET: Productos/Details/5
        public ActionResult DetallesProducto(int id)
        {
            var producto = _listarProductos.Listar().FirstOrDefault(p => p.IdProducto == id);
            if (producto == null)
            {
                return HttpNotFound("El producto no existe");
            }
            var idSucursal = Convert.ToInt32(TempData["IdSucursalSeleccionada"] ?? 0);
            var proveedores = _listarProductos.ObtenerProveedoresPorProducto();

            ViewBag.Proveedores = proveedores;

            return View(producto);
        }





        // GET: InventarioSucursal/AgregarInventarioSucursal
        public ActionResult AgregarInventarioSucursal()

        {
            // Recuperar el idSucursal desde TempData y convertirlo con Convert.ToInt32
            var idSucursal = Convert.ToInt32(TempData["IdSucursalSeleccionada"] ?? 0);

            var productos = _productosListar.ListarProductosActivos();
            ViewBag.Productos = new SelectList(productos, "IdProducto", "Nombre");

            // Asignar el idSucursal al modelo si es necesario
            var modelo = new InventarioSucursalDto
            {
                IdSucursal = idSucursal
            };

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
                var productos = _productosListar.ListarProductosActivos();
                ViewBag.Productos = new SelectList(productos, "IdProducto", "Nombre");

                ViewBag.Mensaje = ex.Message;

                return View(modelo);
            }
            catch (Exception ex)
            {
                var productos = _productosListar.ListarProductosActivos();
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

            InventarioSucursalDto elInventario = _obtenerInventarioSucursal.Obtener(id);

            var modelo = new InventarioSucursalDto
            {
                IdSucursal = idSucursal,
                IdProducto = id,
                Cantidad = elInventario.Cantidad
            };
            return View(modelo);
        }

        // POST: InventarioSucursal/Edit/5
        [HttpPost]
        public async Task<ActionResult> ActualizarInventario(InventarioSucursalDto modelo)
        {
            try
            {
                // Si IdSucursal no viene en el modelo, lo obtenemos de TempData
                if (modelo.IdSucursal == 0)
                {
                    modelo.IdSucursal = Convert.ToInt32(TempData["IdSucursalSeleccionada"] ?? 0);
                }


                int cantidadDeDatosEditados = await _editarInventarioSucursal.Editar(modelo);

                return RedirectToAction("ListarInventarioSucursal", new { idSucursal = modelo.IdSucursal });
            }
            catch (Exception ex)
            {

                ViewBag.Mensaje = "Ocurrió un error inesperado.";
                return View(modelo);
            }
        }


        // GET: InventarioSucursal/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InventarioSucursal/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("ListarInventarioSucursal");
            }
            catch
            {
                return View();
            }
        }






    }
}
