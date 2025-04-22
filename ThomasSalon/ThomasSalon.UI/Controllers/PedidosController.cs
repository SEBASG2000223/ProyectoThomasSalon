using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThomasSalon.Abstracciones.LN.Interfaces.Pedidos.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Productos.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Sucursales.Listar;
using ThomasSalon.Abstracciones.Modelos.Colaboradores;
using ThomasSalon.Abstracciones.Modelos.Pedidos;
using ThomasSalon.AccesoADatos;
using ThomasSalon.LN.Pedidos.Listar;
using ThomasSalon.LN.Productos.Listar;
using ThomasSalon.LN.Sucursales.Listar;

namespace ThomasSalon.UI.Controllers
{
    [Authorize(Roles = "Gerente,Administrador, Usuario")]
    public class PedidosController : Controller
    {
        private readonly Contexto _elContexto;
        IListarPedidosLN _listarPedidos;
     

        public PedidosController()
        {
            _elContexto = new Contexto();
            _listarPedidos = new ListarPedidosLN();


        }
        // GET: Pedidos

        [Authorize(Roles = "Gerente,Administrador")]
        public ActionResult ListarPedidos()
        {
            List<PedidosDto> laListaDePedidos = _listarPedidos.Listar();
            return View(laListaDePedidos);
        }
        [Authorize(Roles = "Usuario")]
        public ActionResult ListarPedidosCliente()
        {
            String idUsuario = User.Identity.GetUserId();
            List<PedidosDto> laListaDePedidos = _listarPedidos.ListarPedidosCliente(idUsuario);
            return View(laListaDePedidos);
        }
        [Authorize(Roles = "Gerente,Administrador")]
        [HttpPost]
        public ActionResult RechazarPedido(Guid idPedido)
        {
            var pedido = _elContexto.PedidosTabla.FirstOrDefault(p => p.IdPedido == idPedido);

            if (pedido == null)
            {
                return Json(new { success = false, message = "Pedido no encontrado." });
            }

            if (pedido.IdEstadoPedido == 3)
            {
                return Json(new { success = false, message = "El pedido ya está rechazado." });
            }

            var detallesPedido = _elContexto.DetallePedidoTabla.Where(d => d.IdPedido == idPedido).ToList();

            foreach (var detalle in detallesPedido)
            {
                var stockProducto = _elContexto.InventarioSucursalTabla
                    .FirstOrDefault(s => s.IdProducto == detalle.IdProducto && s.IdSucursal == pedido.IdSucursal);

                if (stockProducto != null)
                {
                    stockProducto.Cantidad += detalle.Cantidad; // Restaurar stock
                }
            }

            pedido.IdEstadoPedido = 3; // Estado 'Rechazado'
            _elContexto.SaveChanges();

            return Json(new { success = true, message = "Pedido rechazado y stock restaurado correctamente." });
        }
        [Authorize(Roles = "Gerente,Administrador")]
        [HttpPost]
        public ActionResult AceptarPedido(Guid idPedido)
        {
            var pedido = _elContexto.PedidosTabla.FirstOrDefault(p => p.IdPedido == idPedido);

            if (pedido == null)
            {
                return Json(new { success = false, message = "Pedido no encontrado." });
            }

            pedido.IdEstadoPedido = 2; // Estado 'Aceptado'
            _elContexto.SaveChanges();

            return Json(new { success = true, message = "Pedido aceptado correctamente." });
        }


        public ActionResult ObtenerImagen(Guid idPedido)
        {
            try
            {
                // Buscar el pedido con su IdAdjuntos
                var pedido = _elContexto.PedidosTabla
                    .Where(p => p.IdPedido == idPedido)
                    .Select(p => p.IdAdjuntos)
                    .FirstOrDefault();

                if (pedido == null)
                {
                    return Json(null, JsonRequestBehavior.AllowGet); // No hay adjunto asociado
                }

                // Buscar el adjunto en la tabla ADJUNTOS_PEDIDOS
                var adjunto = _elContexto.AdjuntosPedidosTabla
                    .Where(a => a.IdAdjuntos == pedido)
                    .Select(a => a.Adjunto)
                    .FirstOrDefault();

                if (adjunto == null || adjunto.Length == 0)
                {
                    return Json(null, JsonRequestBehavior.AllowGet); // Si no hay imagen, devolver null
                }

                // Convertir la imagen en Base64
                string base64String = Convert.ToBase64String(adjunto);

                return Json(base64String, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = "Error al obtener la imagen: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }



        [Authorize(Roles = "Gerente,Administrador")]
        [HttpPost]
        public ActionResult EntregarPedido(Guid idPedido)
        {
            var pedido = _elContexto.PedidosTabla.FirstOrDefault(p => p.IdPedido == idPedido);

            if (pedido == null)
            {
                return Json(new { success = false, message = "Pedido no encontrado." });
            }

            pedido.IdEstadoPedido = 4; // Estado 'Entregado'
            _elContexto.SaveChanges();

            return Json(new { success = true, message = "Pedido entregado correctamente." });
        }
        // GET: Pedidos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pedidos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pedidos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pedidos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pedidos/Edit/5
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

        // GET: Pedidos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pedidos/Delete/5
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
