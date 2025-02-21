using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Personas.Registrar;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Proveedores.Registrar;
using ThomasSalon.Abstracciones.LN.Interfaces.General.Conversiones.Personas;
using ThomasSalon.Abstracciones.LN.Interfaces.Personas.Registrar;
using ThomasSalon.Abstracciones.Modelos.Personas;
using ThomasSalon.Abstracciones.Modelos.Proveedores;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;
using ThomasSalon.AccesoADatos.Personas.Registrar;
using ThomasSalon.AccesoADatos.Proveedores.Registrar;

namespace ThomasSalon.LN.Personas.Registrar
{
    public class RegistrarPersonasLN : IRegistrarPersonasLN
    {
        IRegistrarPersonasAD _registrarPersonasAD;
        public RegistrarPersonasLN()
        {
            _registrarPersonasAD = new RegistrarPersonasAD();
        }
        public async Task<int> Registrar(PersonasDto modelo)
        {
            int cantidadDeDatosGuardados = await _registrarPersonasAD.Registrar(ConvertirObjetoAPersonasTabla(modelo));
            return cantidadDeDatosGuardados;
        }
        private PersonasTabla ConvertirObjetoAPersonasTabla(PersonasDto laPersona)
        {
            return new PersonasTabla
            {
              
                Nombre = laPersona.Nombre,
                Telefono = laPersona.Telefono,
                Genero = laPersona.Genero,
                Direccion = laPersona.Direccion,
                Edad = laPersona.Edad,
                Identificacion = laPersona.Identificacion
            };
        }
    }
}
