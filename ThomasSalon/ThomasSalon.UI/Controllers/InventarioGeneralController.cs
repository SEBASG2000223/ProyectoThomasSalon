using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.InventarioGeneral.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.InventarioGeneral;
using ThomasSalon.Abstracciones.LN.Interfaces.Productos.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Productos.ObtenerPorId;
using ThomasSalon.Abstracciones.Modelos.InventarioGeneral;
using ThomasSalon.AccesoADatos.InventarioGeneral.ObtenerPorId;
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
        IObtenerInventarioPorIdAD _obtenerInventarioGeneral;

        public InventarioGeneralController()
        {
            _listarInventarioGeneral = new ListarInventarioGeneralLN();
            _obtenerProductosPorId = new ObtenerProductosPorIdLN();
            _listarProductos = new ListarProductosLN();
            _obtenerInventarioGeneral = new ObtenerInventarioPorIdAD();


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
        public ActionResult DetallesProducto(Guid IdInventarioGeneral)
        {
            InventarioGeneralDto inventario = _obtenerInventarioGeneral.DetallesInventario(IdInventarioGeneral).FirstOrDefault();
            var idSucursal = Convert.ToInt32(TempData["IdSucursalSeleccionada"] ?? 0);

            return View(inventario);
        }




    }
}