using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using ThomasSalon.Abstracciones.LN.Interfaces.InventarioSucursal;
using ThomasSalon.Abstracciones.LN.Interfaces.InventarioSucursal.Crear;
using ThomasSalon.Abstracciones.LN.Interfaces.Productos.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Productos.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.Sucursales.Listar;
using ThomasSalon.Abstracciones.Modelos.InventarioSucursal;
using ThomasSalon.Abstracciones.Modelos.Productos;
using ThomasSalon.AccesoADatos;
using ThomasSalon.LN.InventarioSucursal.Crear;
using ThomasSalon.LN.InventarioSucursal.Listar;
using ThomasSalon.LN.Productos.Listar;
using ThomasSalon.LN.Productos.ObtenerPorId;
using ThomasSalon.LN.Sucursales.Listar;

namespace ThomasSalon.UI.Controllers
{
    public class InventarioSucursalController : Controller
    {
        IListarInventarioSucursalLN _listarInventarioSucursal;
        Contexto _elContexto;
        ICrearInventarioSucursalLN _crearInventarioSucursal;
        IListarProductosLN _listarProductos;
        IListarSucursalesLN _listarSucursales;
        IObtenerProductosPorIdLN _obtenerProductosPorId;

        public InventarioSucursalController()
        {
            _listarInventarioSucursal = new ListarInventarioSucursalLN();
            _crearInventarioSucursal = new CrearInventarioSucursalLN();
            _listarProductos = new ListarProductosLN();
            _listarSucursales = new ListarSucursalesLN();
            _obtenerProductosPorId = new ObtenerProductosPorIdLN();
            _elContexto = new Contexto();
        }

        // GET: InventarioSucursal
        public ActionResult ListarInventarioSucursal()
        {
            List<InventarioSucursalDto> laListaDeInventario = _listarInventarioSucursal.Listar();
            return View(laListaDeInventario);
        }

        // GET: Productos/Details/5
        public ActionResult DetallesProducto(int id)
        {
            ProductosDto producto = _obtenerProductosPorId.Obtener(id);
            var proveedoresSucursales = _listarInventarioSucursal.Listar()
                .ToDictionary(p => p.IdProducto, p => p.NombreProveedor);
            ViewBag.ProveedoresSucursales = proveedoresSucursales;
            return View(producto);
        }





        // GET: InventarioSucursal/AgregarInventarioSucursal
        public ActionResult AgregarInventarioSucursal()
        {
            

            // Obtener los productos disponibles para agregar
            ViewBag.ProductosDisponibles = ObtenerProductosDisponibles();

            return View();
        }

        // POST: InventarioSucursal/AgregarInventarioSucursal
        [HttpPost]
        public async Task<ActionResult> AgregarInventarioSucursal(InventarioSucursalDto modelo)
        {
            try
            {
                int cantidadDeDatosGuardados = await _crearInventarioSucursal.Agregar(modelo);

                // Si la inserción es exitosa, redirige a la lista de inventario.
                return RedirectToAction("ListarInventarioSucursal");
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                // Verifica si el error es el del producto ya existente
                if (ex.Number == 10001)
                {
                    ModelState.AddModelError("", "El producto ya existe en la sucursal y no puede ser agregado nuevamente.");
                }
                else
                {
                    ModelState.AddModelError("", "Ocurrió un error inesperado al agregar el producto al inventario.");
                }

                // ⚠️ Mantén al usuario en la misma vista y muestra el error
                return View(modelo);
            }
        }


        private IEnumerable<SelectListItem> ObtenerProductosDisponibles()
        {
            var productosActivos = _listarProductos.Listar()
                .Where(p => p.IdEstado == 1) 
                .Select(p => new SelectListItem
                {
                    Value = p.IdProducto.ToString(),
                    Text = p.Nombre
                });

            return productosActivos;
        }



        // GET: InventarioSucursal/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InventarioSucursal/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                return RedirectToAction("ListarInventarioSucursal");
            }
            catch
            {
                return View();
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
