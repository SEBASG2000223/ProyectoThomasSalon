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
            UsuariosTabla elUsuarioEnBD = _elContexto.UsuariosTabla.Where(elUsuario => elUsuario.Id == elUsuarioParaEditar.Id).FirstOrDefault();
            elUsuarioEnBD.Id = elUsuarioParaEditar.Id;
            elUsuarioEnBD.Email = elUsuarioParaEditar.Email;
            elUsuarioEnBD.Nombre = elUsuarioParaEditar.Nombre;
            elUsuarioEnBD.Genero = elUsuarioParaEditar.Genero;
            elUsuarioEnBD.Direccion = elUsuarioParaEditar.Direccion;
            elUsuarioEnBD.Edad = elUsuarioParaEditar.Edad;
            elUsuarioEnBD.Identificacion = elUsuarioParaEditar.Identificacion;
            elUsuarioEnBD.IdEstado = elUsuarioParaEditar.IdEstado;
            elUsuarioEnBD.IdSucursal = elUsuarioParaEditar.IdSucursal;
            elUsuarioEnBD.PhoneNumber = elUsuarioParaEditar.PhoneNumber;

            EntityState estado = _elContexto.Entry(elUsuarioEnBD).State = System.Data.Entity.EntityState.Modified;
            int cantidadDeDatosGuardados = await _elContexto.SaveChangesAsync();
            return cantidadDeDatosGuardados;
        }
    }
    }

