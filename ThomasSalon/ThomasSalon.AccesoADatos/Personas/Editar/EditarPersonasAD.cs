using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Personas.Editar;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.AccesoADatos.Personas.Editar
{
    public class EditarPersonasAD : IEditarPersonasAD
    {
        Contexto _elContexto;

        public EditarPersonasAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Editar(PersonasTabla laPersonaParaEditar)
        {
            PersonasTabla laPersonaEnDB = _elContexto.PersonasTabla.Where(laPersona => laPersona.IdPersona == laPersonaParaEditar.IdPersona).FirstOrDefault();
            laPersonaEnDB.IdPersona = laPersonaParaEditar.IdPersona;
            laPersonaEnDB.Nombre = laPersonaParaEditar.Nombre;
            laPersonaEnDB.Telefono = laPersonaParaEditar.Telefono;
            laPersonaEnDB.Genero = laPersonaParaEditar.Genero;
            laPersonaEnDB.Direccion = laPersonaParaEditar.Direccion;
            laPersonaEnDB.Edad = laPersonaParaEditar.Edad;
            laPersonaEnDB.Identificacion = laPersonaParaEditar.Identificacion;

            EntityState estado = _elContexto.Entry(laPersonaEnDB).State = System.Data.Entity.EntityState.Modified;
            int cantidadDeDatosGuardados = await _elContexto.SaveChangesAsync();
            return cantidadDeDatosGuardados;
        }
    }
    }

