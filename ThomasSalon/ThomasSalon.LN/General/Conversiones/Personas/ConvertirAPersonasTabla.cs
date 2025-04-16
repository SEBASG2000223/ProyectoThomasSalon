using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.LN.Interfaces.General.Conversiones.Personas;
using ThomasSalon.Abstracciones.Modelos.Personas;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.LN.General.Conversiones.Personas
{
    public class ConvertirAPersonasTabla : IConvertirAPersonasTabla
    {
        public PersonasTabla ConvertirObjetoAPersonasTabla(PersonasDto laPersona)
        {
            return new PersonasTabla
            {
                IdPersona = laPersona.IdPersona,
                Nombre = laPersona.Nombre,
                Telefono = laPersona.Telefono,
                Identificacion=laPersona.Identificacion,
                Genero = laPersona.Genero,
                Direccion = laPersona.Direccion,
                Edad = laPersona.Edad,
              
            };
        }
    }
}
