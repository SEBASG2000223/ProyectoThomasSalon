using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Servicios;

namespace ThomasSalon.Abstracciones.LN.Interfaces.Servicios.Editar
{
    public interface IEditarServiciosLN
    {
        Task<int> Editar(ServiciosDto elServicioEnVista);
    }
}
