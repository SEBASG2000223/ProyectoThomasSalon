using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Personas.Listar;
using ThomasSalon.Abstracciones.Modelos.Personas;
using ThomasSalon.Abstracciones.Modelos.Proveedores;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.AccesoADatos.Personas.Listar
{
    public class ListarPersonasAD : IListarPersonasAD
    {
        Contexto _elContexto;

        public ListarPersonasAD()
        {
            _elContexto = new Contexto();
        }

        public List<PersonasDto> Listar()
        {
            List<PersonasDto> laListaDePersonas = (from laPersona in _elContexto.PersonasTabla

                                                   select new PersonasDto
                                                   {
                                                       IdPersona = laPersona.IdPersona,
                                                       Nombre = laPersona.Nombre,
                                                       Telefono = laPersona.Telefono,
                                                       Genero = laPersona.Genero,
                                                       Direccion = laPersona.Direccion,
                                                       Edad = laPersona.Edad,
                                                       Identificacion = laPersona.Identificacion
                                                   }).ToList();
            return laListaDePersonas;
        }

        public List<PersonasDto> ListarClientes()
        {
            List<PersonasDto> laListaDePersonas = (from laPersona in _elContexto.PersonasTabla
                                                   join usuario in _elContexto.UsuariosTabla
                                                   on laPersona.IdPersona equals usuario.IdPersona into usuarios
                                                   from u in usuarios.DefaultIfEmpty()
                                                   where                                         
                                                       !_elContexto.ColaboradoresTabla.Any(c => c.IdPersona == laPersona.IdPersona) &&

                                                       (u == null || _elContexto.UserRolesTabla.Any(ru => ru.UserId == u.Id && ru.RoleId == "1"))
                                                   select new PersonasDto
                                                   {
                                                       IdPersona = laPersona.IdPersona,
                                                       Nombre = laPersona.Nombre,
                                                       Telefono = laPersona.Telefono,
                                                       Genero = laPersona.Genero,
                                                       Direccion = laPersona.Direccion,
                                                       Edad = laPersona.Edad,
                                                       Identificacion = laPersona.Identificacion
                                                   }).ToList();

            return laListaDePersonas;
        }








    }
}

