using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Personas.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.Personas.ObtenerPorId;
using ThomasSalon.Abstracciones.Modelos.Personas;
using ThomasSalon.Abstracciones.Modelos.Proveedores;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;
using ThomasSalon.AccesoADatos.Personas.ObtenerPorId;

namespace ThomasSalon.LN.Personas.ObtenerPorId
{
    public class ObtenerPersonasPorIdLN : IObtenerPersonasPorIdLN
    {
        IObtenerPersonasPorIdAD _obtenerPorIdAD;

        public ObtenerPersonasPorIdLN()
        {
            _obtenerPorIdAD = new ObtenerPersonasPorIdAD();
        }
        public PersonasDto Obtener(int IdPersona)
        {
            PersonasTabla laPersonaEnDb = _obtenerPorIdAD.Obtener(IdPersona);
            PersonasDto laPersonaAMostrar = ConvertirAPersonasAMostrar(laPersonaEnDb);
            return laPersonaAMostrar;
        }
        private PersonasDto ConvertirAPersonasAMostrar(PersonasTabla laPersonaEnDb)
        {
            return new PersonasDto
            {
                IdPersona = laPersonaEnDb.IdPersona,
                Nombre = laPersonaEnDb.Nombre,
                Telefono = laPersonaEnDb.Telefono,
                Genero = laPersonaEnDb.Genero,
                Direccion = laPersonaEnDb.Direccion,
                Edad = laPersonaEnDb.Edad,
                Identificacion = laPersonaEnDb.Identificacion
            };
        }
    }
}
