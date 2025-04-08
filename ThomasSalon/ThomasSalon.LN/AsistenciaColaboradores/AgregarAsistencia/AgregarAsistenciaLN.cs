using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.AsistenciaColaboradores.AgregarAsistencia;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Ventas.RegistrarVentaServicio;
using ThomasSalon.Abstracciones.LN.Interfaces.AsistenciaColaboradores.AgregarAsistencia;
using ThomasSalon.Abstracciones.Modelos.AsistenciaColaboradores.AgregarAsistencia;
using ThomasSalon.AccesoADatos.AsistenciaColaboradores.AgregarAsistencia;
using ThomasSalon.AccesoADatos.Ventas.RegistrarVentaServicio;

namespace ThomasSalon.LN.AsistenciaColaboradores.AgregarAsistencia
{
    public class AgregarAsistenciaLN : IAgregarAsistenciaLN
    {
        IAgregarAsistenciaAD _asistenciaAD;

        public AgregarAsistenciaLN()
        {
            _asistenciaAD = new AgregarAsistenciaAD();
        }
        public async Task<int> AgregarAsistencia(AsistenciaColaboradorDTO asistenciaColaborador)
        {
            return await _asistenciaAD.AgregarAsistencia(asistenciaColaborador);
        }
    }
}
