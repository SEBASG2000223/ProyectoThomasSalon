using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Personas.Registrar;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.AccesoADatos.Personas.Registrar
{
    public class RegistrarPersonasAD : IRegistrarPersonasAD
    {
        Contexto _elContexto;

        public RegistrarPersonasAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<int> Registrar(PersonasTabla laPersonaAGuardar)
        {
            try
            {
                _elContexto.PersonasTabla.Add(laPersonaAGuardar);
                _elContexto.Entry(laPersonaAGuardar).State = EntityState.Added;
                int cantidadDeDatosGuardados = await _elContexto.SaveChangesAsync();
                return laPersonaAGuardar.IdPersona;
            }
            catch (Exception ex)
            {
                return 0;
            }
       
    }
    }
}
