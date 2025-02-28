using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.InventarioSucursal;
using ThomasSalon.Abstracciones.Modelos.Pedidos;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Pedidos.Listar
{
    public interface IListarPedidosAD
    {
        List<PedidosDto> Listar();

    }
}
