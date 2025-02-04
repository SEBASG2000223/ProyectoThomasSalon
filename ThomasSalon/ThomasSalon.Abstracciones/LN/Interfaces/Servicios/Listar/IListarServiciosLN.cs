using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Servicios;

namespace ThomasSalon.Abstracciones.LN.Interfaces.Servicios.Listar
{
    public interface IListarServiciosLN
    {
        List<ServiciosDto> Listar();
    }
}
