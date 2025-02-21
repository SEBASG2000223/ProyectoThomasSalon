using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Usuarios.Listar;
using ThomasSalon.Abstracciones.Modelos.Sucursales;
using ThomasSalon.Abstracciones.Modelos.Usuarios;

namespace ThomasSalon.AccesoADatos.Usuarios.Listar
{
    public class ListarUsuariosAD : IListarUsuariosAD
    {
        Contexto _elContexto;


        public ListarUsuariosAD()
        {
            _elContexto = new Contexto();
        }
        public List<UsuariosDto> Listar()
        {
            List<UsuariosDto> laListaDeUsuarios = (from elUsuario in _elContexto.UsuariosTabla
                                                   join laPersona in _elContexto.PersonasTabla
                                                   on elUsuario.IdPersona equals laPersona.IdPersona
                                                   join elEstado in _elContexto.EstadoDisponibilidadTabla
                                                   on elUsuario.IdEstado equals elEstado.IdEstado
                                                   join usuarioRol in _elContexto.UserRolesTabla
                                                   on elUsuario.Id equals usuarioRol.UserId into userRolesGroup
                                                   from usuarioRol in userRolesGroup.DefaultIfEmpty()
                                                   join rol in _elContexto.RolesTabla
                                                   on usuarioRol.RoleId equals rol.Id into rolesGroup
                                                   from rol in rolesGroup.DefaultIfEmpty()
                                                   select new UsuariosDto
                                                   {
                                                       Id = elUsuario.Id,
                                                       Email = elUsuario.Email,
                                                       Nombre = laPersona.Nombre,
                                                       Telefono = laPersona.Telefono,
                                                       Genero = laPersona.Genero,
                                                       Direccion = laPersona.Direccion,
                                                       Edad = laPersona.Edad,
                                                       Identificacion = laPersona.Identificacion,
                                                       NombreEstado = elEstado.Nombre,
                                                       NombreRol = rol != null ? rol.Name : "Sin Rol"
                                                   }).ToList();
            return laListaDeUsuarios;
        }

        public List<UsuariosDto> ListarAdministradores()
        {
            List<UsuariosDto> laListaDeUsuarios = (from elUsuario in _elContexto.UsuariosTabla
                                                   join laPersona in _elContexto.PersonasTabla
                                                   on elUsuario.IdPersona equals laPersona.IdPersona
                                                   join elEstado in _elContexto.EstadoDisponibilidadTabla
                                                   on elUsuario.IdEstado equals elEstado.IdEstado
                                                   join usuarioRol in _elContexto.UserRolesTabla
                                                   on elUsuario.Id equals usuarioRol.UserId into userRolesGroup
                                                   from usuarioRol in userRolesGroup.DefaultIfEmpty()
                                                   join rol in _elContexto.RolesTabla
                                                   on usuarioRol.RoleId equals rol.Id into rolesGroup
                                                   from rol in rolesGroup.DefaultIfEmpty()
                                                   where rol.Id == 2.ToString()
                                                   select new UsuariosDto
                                                   {
                                                       Id = elUsuario.Id,
                                                       Email = elUsuario.Email,
                                                       Nombre = laPersona.Nombre,
                                                       Telefono = laPersona.Telefono,
                                                       Genero = laPersona.Genero,
                                                       Direccion = laPersona.Direccion,
                                                       Edad = laPersona.Edad,
                                                       Identificacion = laPersona.Identificacion,
                                                       NombreRol = rol.Name
                                                   }).ToList();
            return laListaDeUsuarios;
        }
        public List<UsuariosDto> ListarGerentes()
        {
            List<UsuariosDto> laListaDeUsuarios = (from elUsuario in _elContexto.UsuariosTabla
                                                   join laPersona in _elContexto.PersonasTabla
                                                   on elUsuario.IdPersona equals laPersona.IdPersona
                                                   join elEstado in _elContexto.EstadoDisponibilidadTabla
                                                   on elUsuario.IdEstado equals elEstado.IdEstado
                                                   join usuarioRol in _elContexto.UserRolesTabla
                                                   on elUsuario.Id equals usuarioRol.UserId into userRolesGroup
                                                   from usuarioRol in userRolesGroup.DefaultIfEmpty()
                                                   join rol in _elContexto.RolesTabla
                                                   on usuarioRol.RoleId equals rol.Id into rolesGroup
                                                   from rol in rolesGroup.DefaultIfEmpty()
                                                   where rol.Id == 3.ToString()
                                                   select new UsuariosDto
                                                   {
                                                       Id = elUsuario.Id,
                                                       Email = elUsuario.Email,
                                                       Nombre = laPersona.Nombre,
                                                       Telefono = laPersona.Telefono,
                                                       Genero = laPersona.Genero,
                                                       Direccion = laPersona.Direccion,
                                                       Edad = laPersona.Edad,
                                                       Identificacion = laPersona.Identificacion,
                                                       NombreRol = rol.Name
                                                   }).ToList();
            return laListaDeUsuarios;
        }

        public List<UsuariosDto> ListarUsuarios()
        {
            List<UsuariosDto> laListaDeUsuarios = (from elUsuario in _elContexto.UsuariosTabla
                                                   join laPersona in _elContexto.PersonasTabla
                                                   on elUsuario.IdPersona equals laPersona.IdPersona
                                                   join elEstado in _elContexto.EstadoDisponibilidadTabla
                                                   on elUsuario.IdEstado equals elEstado.IdEstado
                                                   join usuarioRol in _elContexto.UserRolesTabla
                                                   on elUsuario.Id equals usuarioRol.UserId into userRolesGroup
                                                   from usuarioRol in userRolesGroup.DefaultIfEmpty()
                                                   join rol in _elContexto.RolesTabla
                                                   on usuarioRol.RoleId equals rol.Id into rolesGroup
                                                   from rol in rolesGroup.DefaultIfEmpty()
                                                   where rol.Id == 1.ToString()
                                                   select new UsuariosDto
                                                   {
                                                       Id = elUsuario.Id,
                                                       Email = elUsuario.Email,
                                                       Nombre = laPersona.Nombre,
                                                       Telefono = laPersona.Telefono,
                                                       Genero = laPersona.Genero,
                                                       Direccion = laPersona.Direccion,
                                                       Edad = laPersona.Edad,
                                                       Identificacion = laPersona.Identificacion,
                                                       NombreRol = rol.Name
                                                   }).ToList();
            return laListaDeUsuarios;
        }

    }
}

