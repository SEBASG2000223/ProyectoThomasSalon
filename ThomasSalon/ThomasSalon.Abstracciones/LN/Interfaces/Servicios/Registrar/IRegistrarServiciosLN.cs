using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Servicios;

namespace ThomasSalon.Abstracciones.LN.Interfaces.Servicios.Registrar
{
    public interface IRegistrarServiciosLN
    {
        Task<int> Registrar(ServiciosDto modelo);
    }
}
