using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ThomasSalon.Abstracciones.LN.Interfaces.InventarioGeneral;
using ThomasSalon.Abstracciones.LN.Interfaces.Productos.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Productos.ObtenerPorId;
using ThomasSalon.Abstracciones.Modelos.InventarioGeneral;
using ThomasSalon.LN.InventarioGeneral.Listar;
using ThomasSalon.LN.Productos.Listar;
using ThomasSalon.LN.Productos.ObtenerPorId;

namespace ThomasSalon.UI.Controllers
{
    public class InventarioGeneralController : Controller
    {
        IInventarioGeneralLN _listarInventarioGeneral;
        IObtenerProductosPorIdLN _obtenerProductosPorId;
        IListarProductosLN _listarProductos;

        public InventarioGeneralController()
        {
            _listarInventarioGeneral = new ListarInventarioGeneralLN();
            _obtenerProductosPorId = new ObtenerProductosPorIdLN();
            _listarProductos = new ListarProductosLN();


        }

        // GET: Productos
        public ActionResult ListarInventarioGeneral()
        {
            List<InventarioGeneralDto> laListaDeInventario = _listarInventarioGeneral.Listar();
            if (laListaDeInventario == null || !laListaDeInventario.Any())
            {
                ViewBag.Mensaje = "No hay productos en el inventario.";
            }
            return View(laListaDeInventario);
        }


        // GET: Productos/Details/5
        public ActionResult DetallesProducto(int id)
        {
            var producto = _listarProductos.Listar().FirstOrDefault(p => p.IdProducto == id);
            if (producto == null)
            {
                return HttpNotFound("El producto no existe");
            }

            var proveedores = _listarProductos.ObtenerProveedoresPorProducto();

            ViewBag.Proveedores = proveedores;

            return View(producto);
        }




    }
}