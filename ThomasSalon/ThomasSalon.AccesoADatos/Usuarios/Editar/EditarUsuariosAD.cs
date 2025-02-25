using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Usuarios.Editar;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.AccesoADatos.Usuarios.Editar
{
    public class EditarUsuariosAD : IEditarUsuariosAD
    {
        Contexto _elContexto;

        public EditarUsuariosAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Editar(UsuariosTabla elUsuarioParaEditar)
        {
            // Buscar el usuario en la base de datos
            UsuariosTabla elUsuarioEnBD = await _elContexto.UsuariosTabla
                .Where(elUsuario => elUsuario.Id == elUsuarioParaEditar.Id)
                .FirstOrDefaultAsync();

            if (elUsuarioEnBD == null)
            {
                return 0; // Si el usuario no existe, retorna 0
            }

            // Buscar la persona asociada al usuario
            PersonasTabla laPersonaEnBD = await _elContexto.PersonasTabla
                .Where(laPersona => laPersona.IdPersona == elUsuarioEnBD.IdPersona)
                .FirstOrDefaultAsync();

            if (laPersonaEnBD != null)
            {
                // Actualizar los datos de la persona
                laPersonaEnBD.Nombre = elUsuarioParaEditar.Persona.Nombre;
                laPersonaEnBD.Telefono = elUsuarioParaEditar.Persona.Telefono;
                laPersonaEnBD.Genero = elUsuarioParaEditar.Persona.Genero;
                laPersonaEnBD.Direccion = elUsuarioParaEditar.Persona.Direccion;
                laPersonaEnBD.Edad = elUsuarioParaEditar.Persona.Edad;
                laPersonaEnBD.Identificacion = elUsuarioParaEditar.Persona.Identificacion;

                _elContexto.Entry(laPersonaEnBD).State = EntityState.Modified;
            }

            // Actualizar los datos del usuario
            elUsuarioEnBD.Email = elUsuarioParaEditar.Email;
          
            elUsuarioEnBD.IdEstado = elUsuarioParaEditar.IdEstado;
            elUsuarioEnBD.IdSucursal = elUsuarioParaEditar.IdSucursal;

            _elContexto.Entry(elUsuarioEnBD).State = EntityState.Modified;

            // Guardar los cambios en la base de datos
            int cantidadDeDatosGuardados = await _elContexto.SaveChangesAsync();
            return cantidadDeDatosGuardados;
        }

    }
}

