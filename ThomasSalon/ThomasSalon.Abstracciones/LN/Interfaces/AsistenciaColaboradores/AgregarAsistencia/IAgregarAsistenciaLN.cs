using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.AsistenciaColaboradores.AgregarAsistencia;
using ThomasSalon.Abstracciones.Modelos.Ventas.RegistrarVentaServicio;

namespace ThomasSalon.Abstracciones.LN.Interfaces.AsistenciaColaboradores.AgregarAsistencia
{
    public interface IAgregarAsistenciaLN
    {
        Task<int> AgregarAsistencia(AsistenciaColaboradorDTO asistenciaColaborador);

    }
}
