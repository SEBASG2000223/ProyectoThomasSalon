using System;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Colaboradores.ObtenerPorId;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Personas.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.Colaboradores.ObtenerPorId;
using ThomasSalon.Abstracciones.Modelos.Colaboradores;
using ThomasSalon.Abstracciones.Modelos.Personas;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;
using ThomasSalon.AccesoADatos.Colaboradores.ObtenerPorId;
using ThomasSalon.AccesoADatos.Personas.ObtenerPorId;

namespace ThomasSalon.LN.Colaboradores.ObtenerPorId
{
    public class ObtenerColaboradoresPorIdLN : IObtenerColaboradoresPorIdLN
    {
        IObtenerColaboradoresPorIdAD _obtenerPorIdAD;
        IObtenerPersonasPorIdAD _obtenerPersonas;

        public ObtenerColaboradoresPorIdLN()
        {
            _obtenerPorIdAD = new ObtenerPorIdColaboradoresAD();
            _obtenerPersonas = new ObtenerPersonasPorIdAD();
        }

        public ColaboradoresDto Obtener(int IdColaborador)
        {
            ColaboradoresTabla elColaboradorEnDb = _obtenerPorIdAD.Obtener(IdColaborador);

            if (elColaboradorEnDb == null)
            {
                return null;
            }

         
            PersonasTabla laPersonaEnDb = _obtenerPersonas.Obtener(elColaboradorEnDb.IdPersona);

          
            return new ColaboradoresDto
            {
                IdColaborador = elColaboradorEnDb.IdColaborador,
                SalarioDia = elColaboradorEnDb.SalarioDia,
                IdEstado = elColaboradorEnDb.IdEstado,
                IdPersona = elColaboradorEnDb.IdPersona,
                Persona = laPersonaEnDb != null ? new PersonasDto
                {
                    IdPersona = elColaboradorEnDb.IdPersona,
                    Nombre = laPersonaEnDb.Nombre,
                    Genero = laPersonaEnDb.Genero,
                    Telefono = laPersonaEnDb.Telefono,
                    Identificacion = laPersonaEnDb.Identificacion,
                    Direccion = laPersonaEnDb.Direccion,
                    Edad = laPersonaEnDb.Edad
                } : null
            };
        }
    }
}
