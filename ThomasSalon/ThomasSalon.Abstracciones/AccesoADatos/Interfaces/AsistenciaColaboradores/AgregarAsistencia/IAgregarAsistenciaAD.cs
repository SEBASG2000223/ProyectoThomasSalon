using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.AsistenciaColaboradores.AgregarAsistencia;
using ThomasSalon.Abstracciones.Modelos.Ventas.RegistrarVentaServicio;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.AsistenciaColaboradores.AgregarAsistencia
{
    public interface IAgregarAsistenciaAD
    {
        Task<int> AgregarAsistencia(AsistenciaColaboradorDTO asistencia);

    }
}
