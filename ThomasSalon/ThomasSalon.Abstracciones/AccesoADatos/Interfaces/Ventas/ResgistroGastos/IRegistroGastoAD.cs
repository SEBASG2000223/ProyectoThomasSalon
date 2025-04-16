using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Ventas.RegistrarVentaServicio;
using ThomasSalon.Abstracciones.Modelos.Ventas.ResgistroGastos;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Ventas.ResgistroGastos
{
    public interface IRegistroGastoAD
    {
        Task<int> RegistroGasto(RegistroGastoDTO registroGasto);

    }
}
