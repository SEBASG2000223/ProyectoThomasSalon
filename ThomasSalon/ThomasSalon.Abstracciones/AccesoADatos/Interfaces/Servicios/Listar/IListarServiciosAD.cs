using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Servicios;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Servicios.Listar
{
    public interface IListarServiciosAD
    {
        List<ServiciosDto> Listar();
    }
}
