using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Personas.ObtenerPorId;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.AccesoADatos.Personas.ObtenerPorId
{
    public class ObtenerPersonasPorIdAD : IObtenerPersonasPorIdAD
    {
        Contexto _elContexto;

        public ObtenerPersonasPorIdAD()
        {
            _elContexto = new Contexto();
        }

        public PersonasTabla Obtener(int IdPersona)
        {
            PersonasTabla laPersonaEnDb = _elContexto.PersonasTabla.Where(laPersona => laPersona.IdPersona == IdPersona).FirstOrDefault();
            return laPersonaEnDb;
        }
    }
}
