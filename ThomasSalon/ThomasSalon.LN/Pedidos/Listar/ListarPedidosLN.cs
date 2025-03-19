using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Colaboradores.Listar;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Pedidos.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Pedidos.Listar;
using ThomasSalon.Abstracciones.Modelos.Pedidos;
using ThomasSalon.Abstracciones.Modelos.Productos;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;
using ThomasSalon.AccesoADatos.Colaboradores.Listar;
using ThomasSalon.AccesoADatos.Pedidos.Listar;

namespace ThomasSalon.LN.Pedidos.Listar
{
    public class ListarPedidosLN : IListarPedidosLN
    {
        IListarPedidosAD _listarPedidosAD;
        public ListarPedidosLN()
        {
            _listarPedidosAD = new ListarPedidosAD();
        }
        public List<PedidosDto> Listar()
        {
            return _listarPedidosAD.Listar();
        }

        public List<PedidosDto> ListarPedidosCliente(string idUsuario)
        {
            return _listarPedidosAD.ListarPedidosCliente(idUsuario);
        }
    }
}
