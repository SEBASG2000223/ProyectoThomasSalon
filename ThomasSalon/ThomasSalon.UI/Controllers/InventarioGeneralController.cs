using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ThomasSalon.Abstracciones.LN.Interfaces.InventarioGeneral;
using ThomasSalon.Abstracciones.LN.Interfaces.Productos.ObtenerPorId;
using ThomasSalon.Abstracciones.Modelos.InventarioGeneral;
using ThomasSalon.Abstracciones.Modelos.Productos;
using ThomasSalon.LN.InventarioGeneral.Listar;
using ThomasSalon.LN.Productos.ObtenerPorId;

namespace ThomasSalon.UI.Controllers
{
    public class InventarioGeneralController : Controller
    {
        IInventarioGeneralLN _listarInventarioGeneral;
        IObtenerProductosPorIdLN _obtenerProductosPorId;

        public InventarioGeneralController()
        {
            _listarInventarioGeneral = new ListarInventarioGeneralLN();
            _obtenerProductosPorId = new ObtenerProductosPorIdLN();


        }

        // GET: Productos
        public ActionResult ListarInventarioGeneral()
        {
            List<InventarioGeneralDto> laListaDeInventario = _listarInventarioGeneral.Listar();
            return View(laListaDeInventario);
        }

        // GET: Productos/Details/5
        public ActionResult DetallesProducto(int id)
        {
            ProductosDto producto = _obtenerProductosPorId.Obtener(id);
            var proveedores = _listarInventarioGeneral.Listar()
                .ToDictionary(p => p.IdProducto, p => p.NombreProveedor);
            ViewBag.Proveedores = proveedores;
            return View(producto);
        }

    }
}