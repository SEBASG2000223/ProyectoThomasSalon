using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;
using ThomasSalon.AccesoADatos;
using System.Data.Entity;
using ThomasSalon.Abstracciones.LN.Interfaces.Productos.Listar;
using ThomasSalon.LN.Productos.Listar;
using ThomasSalon.Abstracciones.Modelos.Productos;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.LN.Interfaces.Sucursales.Listar;
using ThomasSalon.LN.Sucursales.Listar;
using System.IO;
using System.Web;

namespace ThomasSalon.UI.Controllers
{
    public class CarritoController : Controller
    {
        private readonly Contexto _elContexto;
        IListarProductosLN _listarProductos;
        IListarSucursalesLN _listarSucursales;

        public CarritoController()
        {
            _elContexto = new Contexto();
            _listarProductos = new ListarProductosLN();
            _listarSucursales = new ListarSucursalesLN();
        }


        // GET: Productos
        public async Task<ActionResult> VerCarrito()
        {
            var sucursales = _listarSucursales.ListarSucursalesActivas();
            ViewBag.Sucursales = new SelectList(sucursales, "IdSucursal", "Nombre");

            var metodosPago = await _elContexto.MetodosDePagoTabla.ToListAsync();
            ViewBag.MetodosPago = new SelectList(metodosPago, "IdMetodoPago", "Nombre");

            var tiposEntrega = await _elContexto.TipoDeEntregaTabla.ToListAsync();
            ViewBag.TiposEntrega = new SelectList(tiposEntrega, "IdTipoEntrega", "Nombre");

            var provincias = await _elContexto.ProvinciasTabla.ToListAsync();
            ViewBag.Provincias = new SelectList(provincias, "IdProvincia", "Nombre");

            var tarifasEnvio = provincias.ToDictionary(p => p.IdProvincia.ToString(), p => p.PrecioEntrega);
            ViewBag.TarifasEnvio = tarifasEnvio;

            List<ProductosDto> laListaDeProductos = _listarProductos.ProductosActivos();
            return View(laListaDeProductos);
        }

        [HttpPost]
        public ActionResult RealizarCompra(Guid idMetodoPago, Guid idTipoEntrega,
 string direccionExacta, string comentario, int idSucursal, Guid? idProvincia, HttpPostedFileBase archivoAdjunto)
        {
            string idUsuario = User.Identity.GetUserId();

            if (string.IsNullOrEmpty(idUsuario))
            {
                return Json(new { success = false, message = "Usuario no autenticado." });
            }

            var carrito = _elContexto.CarritoTemporalTabla
                .Where(c => c.IdUsuario == idUsuario)
                .ToList();

            if (!carrito.Any())
            {
                return Json(new { success = false, message = "El carrito está vacío." });
            }

           

            decimal subtotal = carrito.Sum(c => c.Cantidad * c.PrecioUnitario);
            decimal ivaTotal = subtotal * 0.13m;
            decimal costoEnvio = 0;

            var tipoEntregaDomicilio = _elContexto.TipoDeEntregaTabla
                .Where(t => t.Nombre == "Domicilio")
                .Select(t => t.IdTipoEntrega)
                .FirstOrDefault();

            if (idTipoEntrega == tipoEntregaDomicilio)
            {
                costoEnvio = _elContexto.ProvinciasTabla
                    .Where(p => p.IdProvincia == idProvincia)
                    .Select(p => p.PrecioEntrega)
                    .FirstOrDefault();
            }

            decimal montoTotal = subtotal + ivaTotal + costoEnvio;

            Guid? idAdjunto = null;
            if (archivoAdjunto != null && archivoAdjunto.ContentLength > 0)
            {
                using (var binaryReader = new BinaryReader(archivoAdjunto.InputStream))
                {
                    var adjunto = new AdjuntosPedidosTabla
                    {
                        IdAdjuntos = Guid.NewGuid(),
                        Adjunto = binaryReader.ReadBytes(archivoAdjunto.ContentLength)
                    };

                    _elContexto.AdjuntosPedidosTabla.Add(adjunto);
                    _elContexto.SaveChanges();
                    idAdjunto = adjunto.IdAdjuntos;
                }
            }

            var nuevoPedido = new PedidosTabla
            {
                IdPedido = Guid.NewGuid(),
                IdUsuario = idUsuario,
                IdEstadoPedido = 1,
                IdMetodoPago = idMetodoPago,
                IdTipoEntrega = idTipoEntrega,
                IdSucursal = idSucursal,
                IdProvincia = idProvincia,
                DireccionExacta = direccionExacta,
                Comentario = comentario,
                Fecha = DateTime.Now,
                MontoTotal = montoTotal,
                MontoIVA = ivaTotal,
                IdAdjuntos = idAdjunto
            };

            _elContexto.PedidosTabla.Add(nuevoPedido);
            _elContexto.SaveChanges();

            foreach (var item in carrito)
            {

                var detallePedido = new DetallePedidoTabla
                {
                    IdDetallePedido = Guid.NewGuid(),
                    IdPedido = nuevoPedido.IdPedido,
                    IdProducto = item.IdProducto,
                    Cantidad = item.Cantidad,
                    PrecioUnitario = item.PrecioUnitario,
                    Subtotal = subtotal
                };

                _elContexto.DetallePedidoTabla.Add(detallePedido);

                var stockProducto = _elContexto.InventarioSucursalTabla
                    .FirstOrDefault(s => s.IdProducto == item.IdProducto && s.IdSucursal == idSucursal);

                if (stockProducto != null)
                {
                    stockProducto.Cantidad -= item.Cantidad;
                }
            }

            _elContexto.CarritoTemporalTabla.RemoveRange(carrito);
            _elContexto.SaveChanges();

            return Json(new { success = true, message = "Pedido realizado con éxito.", idPedido = nuevoPedido.IdPedido });
        }


        public async Task<ActionResult> ObtenerCarritoProductos(Guid? idProvincia, Guid? idTipoEntrega)
        {
            string idUsuario = User.Identity.GetUserId();
            decimal costoEnvio = 0;
            decimal ivaTotal = 0; // Variable para almacenar el IVA total

            // Obtener ID real del tipo de entrega "Domicilio"
            var tipoEntregaDomicilio = _elContexto.TipoDeEntregaTabla
                .Where(t => t.Nombre == "Domicilio")
                .Select(t => t.IdTipoEntrega)
                .FirstOrDefault();

            var carrito = (from c in _elContexto.CarritoTemporalTabla
                           join p in _elContexto.ProductosTabla on c.IdProducto equals p.IdProducto
                           where c.IdUsuario == idUsuario
                           select new
                           {
                               c.IdProducto,
                               Nombre = p.Nombre,
                               LinkImagen = p.LinkImagen,
                               c.Cantidad,
                               c.PrecioUnitario
                           }).ToList();

            decimal subtotal = carrito.Sum(c => c.Cantidad * c.PrecioUnitario);
            ivaTotal = subtotal * 0.13m; // Calcular IVA total sobre el subtotal

            // Validar si el envío aplica
            if (idProvincia.HasValue && idTipoEntrega.HasValue && idTipoEntrega == tipoEntregaDomicilio)
            {
                costoEnvio = _elContexto.ProvinciasTabla
                    .Where(p => p.IdProvincia == idProvincia)
                    .Select(p => p.PrecioEntrega)
                    .FirstOrDefault();
            }

            decimal total = subtotal + ivaTotal + costoEnvio; // Agregar el IVA total al cálculo final

            return Json(new { carrito, subtotal, ivaTotal, costoEnvio, total }, JsonRequestBehavior.AllowGet);
        }






        [HttpPost]
        public ActionResult AgregarAlCarrito(int idProducto, int cantidad, decimal precioUnitario)
        {
            string idUsuario = User.Identity.GetUserId();

            var itemExistente = _elContexto.CarritoTemporalTabla
                .FirstOrDefault(c => c.IdUsuario == idUsuario && c.IdProducto == idProducto);

            if (itemExistente != null)
            {
                itemExistente.Cantidad += cantidad;
            }
            else
            {
                _elContexto.CarritoTemporalTabla.Add(new CarritoTemporalTabla
                {
                    IdUsuario = idUsuario,
                    IdProducto = idProducto,
                    Cantidad = cantidad,
                    FechaAgregado = DateTime.Today,
                    PrecioUnitario = precioUnitario
                });
            }
            _elContexto.SaveChanges();

            return Json(new { mensaje = "Producto agregado con éxito" });
        }

        public ActionResult ObtenerCarrito()
        {
            string idUsuario = User.Identity.GetUserId();

            var carrito = (from c in _elContexto.CarritoTemporalTabla
                           join p in _elContexto.ProductosTabla on c.IdProducto equals p.IdProducto
                           where c.IdUsuario == idUsuario
                           select new
                           {
                               c.IdProducto,
                               Nombre = p.Nombre, // Tomamos el nombre de ProductosTabla
                               LinkImagen = p.LinkImagen, // Tomamos la imagen de ProductosTabla
                               c.Cantidad,
                               c.PrecioUnitario
                           }).ToList();

            return Json(carrito, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult VerificarStock(int idSucursal)
        {
            string idUsuario = User.Identity.GetUserId();
            var carrito = _elContexto.CarritoTemporalTabla.Where(c => c.IdUsuario == idUsuario).ToList();

            var productosSinStock = new List<object>();

            foreach (var item in carrito)
            {
                var stockEnSucursalSeleccionada = _elContexto.InventarioSucursalTabla
                    .Where(s => s.IdProducto == item.IdProducto && s.IdSucursal == idSucursal)
                    .Select(s => s.Cantidad)
                    .FirstOrDefault();

                if (stockEnSucursalSeleccionada < item.Cantidad)
                {
                    var producto = _elContexto.ProductosTabla
                        .Where(p => p.IdProducto == item.IdProducto)
                        .Select(p => new { p.Nombre, p.IdProducto })
                        .FirstOrDefault();

                    var stockOtrasSucursales = _elContexto.InventarioSucursalTabla
                        .Where(s => s.IdProducto == item.IdProducto && s.IdSucursal != idSucursal)
                        .Select(s => new
                        {
                            Sucursal = _elContexto.SucursalesTabla
                                .Where(suc => suc.IdSucursal == s.IdSucursal)
                                .Select(suc => suc.Nombre)
                                .FirstOrDefault(),
                            Cantidad = s.Cantidad
                        })
                        .Where(s => s.Cantidad > 0)
                        .ToList();

                    productosSinStock.Add(new
                    {
                        Nombre = producto.Nombre,
                        StockDisponible = stockEnSucursalSeleccionada,
                        Requerido = item.Cantidad,
                        StockOtrasSucursales = stockOtrasSucursales
                    });
                }
            }

            if (productosSinStock.Any())
            {
                return Json(new { success = false, productos = productosSinStock });
            }

            return Json(new { success = true });
        }



        [HttpPost]
        public ActionResult ActualizarCantidad(int idProducto, int cantidad)
        {
            string idUsuario = User.Identity.GetUserId();
            var item = _elContexto.CarritoTemporalTabla.FirstOrDefault(c => c.IdUsuario == idUsuario && c.IdProducto == idProducto);

            if (item != null && cantidad > 0)
            {
                item.Cantidad = cantidad;
                _elContexto.SaveChanges();
            }

            return Json(new { mensaje = "Cantidad actualizada" });
        }

        [HttpPost]
        public ActionResult EliminarDelCarrito(int idProducto)
        {
            string idUsuario = User.Identity.GetUserId();
            var item = _elContexto.CarritoTemporalTabla.FirstOrDefault(c => c.IdUsuario == idUsuario && c.IdProducto == idProducto);

            if (item != null)
            {
                _elContexto.CarritoTemporalTabla.Remove(item);
                _elContexto.SaveChanges();
            }

            return Json(new { mensaje = "Producto eliminado" });
        }
    }
}
