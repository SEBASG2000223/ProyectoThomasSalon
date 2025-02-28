using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Pedidos.Listar;
using ThomasSalon.Abstracciones.Modelos.Colaboradores;
using ThomasSalon.Abstracciones.Modelos.Pedidos;

namespace ThomasSalon.AccesoADatos.Pedidos.Listar
{
    public class ListarPedidosAD : IListarPedidosAD
    {
        Contexto _elContexto;

        public ListarPedidosAD()
        {
            _elContexto = new Contexto();
        }
        public List<PedidosDto> Listar()
        {
            var listaDePedidos = (from p in _elContexto.PedidosTabla
                                  join e in _elContexto.EstadoDePedidoTabla on p.IdEstadoPedido equals e.IdEstadoPedido
                                  join s in _elContexto.SucursalesTabla on p.IdSucursal equals s.IdSucursal
                                  join u in _elContexto.UsuariosTabla on p.IdUsuario equals u.Id
                                  join mp in _elContexto.MetodosDePagoTabla on p.IdMetodoPago equals mp.IdMetodoPago
                                  join te in _elContexto.TipoDeEntregaTabla on p.IdTipoEntrega equals te.IdTipoEntrega
                                  join pr in _elContexto.ProvinciasTabla on p.IdProvincia equals pr.IdProvincia into provinciaGroup
                                  from pr in provinciaGroup.DefaultIfEmpty()
                                  select new PedidosDto
                                  {
                                      IdPedido = p.IdPedido,
                                      EstadoPedido = e.Nombre,
                                      Sucursal = s.Nombre,
                                      Usuario = u.Email,
                                      MetodoPago = mp.Nombre,
                                      TipoEntrega = te.Nombre,
                                      Provincia = pr != null ? pr.Nombre : "N/A",
                                      DireccionExacta = p.DireccionExacta,
                                      Comentario = p.Comentario,
                                      Fecha = p.Fecha,
                                      MontoTotal = p.MontoTotal
                                     
                                  }).ToList();

            return listaDePedidos;
        }

    }
}

