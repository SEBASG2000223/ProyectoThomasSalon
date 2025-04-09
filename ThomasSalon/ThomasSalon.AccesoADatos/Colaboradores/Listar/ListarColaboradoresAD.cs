using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Colaboradores.Listar;
using ThomasSalon.Abstracciones.Modelos.Colaboradores;

namespace ThomasSalon.AccesoADatos.Colaboradores.Listar
{
    public class ListarColaboradoresAD : IListarColaboradoresAD
    {
        Contexto _elContexto;

        public ListarColaboradoresAD()
        {
            _elContexto = new Contexto();
        }

        public List<ColaboradoresDto> Listar()
        {
            List<ColaboradoresDto> laListaDeColaboradores = (from c in _elContexto.ColaboradoresTabla
                                                             join p in _elContexto.PersonasTabla
                                                             on c.IdPersona equals p.IdPersona
                                                             join e in _elContexto.EstadoDisponibilidadTabla
                                                             on c.IdEstado equals e.IdEstado
                                                             join u in _elContexto.UsuariosTabla
                                                             on c.IdPersona equals u.IdPersona into usuarios
                                                             from u in usuarios.DefaultIfEmpty()  // Incluye el colaborador incluso si no tiene usuario
                                                             select new ColaboradoresDto
                                                             {
                                                                 IdColaborador = c.IdColaborador,
                                                                 IdPersona = p.IdPersona,
                                                                 IdEstado = c.IdEstado,
                                                                 NombreEstado = e.Nombre,
                                                                 Nombre = p.Nombre,
                                                                 SalarioDia = c.SalarioDia,
                                                                 Telefono = p.Telefono,
                                                                 Genero = p.Genero,
                                                                 Direccion = p.Direccion,
                                                                 Edad = p.Edad,
                                                                 Identificacion = p.Identificacion,
                                                                 TieneUsuario = u != null // Si existe un usuario, tiene usuario = true
                                                             }).ToList();
            return laListaDeColaboradores;
        }
        public List<ColaboradoresDto> ListarDisponibles()
        {
            List<ColaboradoresDto> laListaDeColaboradores = (from c in _elContexto.ColaboradoresTabla
                                                             join p in _elContexto.PersonasTabla
                                                             on c.IdPersona equals p.IdPersona
                                                             join e in _elContexto.EstadoDisponibilidadTabla
                                                             on c.IdEstado equals e.IdEstado
                                                             join u in _elContexto.UsuariosTabla
                                                             on c.IdPersona equals u.IdPersona into usuarios
                                                             from u in usuarios.DefaultIfEmpty()
                                                             where c.IdEstado == 1
                                                             select new ColaboradoresDto
                                                             {
                                                                 IdColaborador = c.IdColaborador,
                                                                 IdPersona = p.IdPersona,
                                                                 IdEstado = c.IdEstado,
                                                                 NombreEstado = e.Nombre,
                                                                 Nombre = p.Nombre,
                                                                 SalarioDia = c.SalarioDia,
                                                                 Telefono = p.Telefono,
                                                                 Genero = p.Genero,
                                                                 Direccion = p.Direccion,
                                                                 Edad = p.Edad,
                                                                 Identificacion = p.Identificacion,
                                                                 TieneUsuario = u != null
                                                             }).ToList();

            return laListaDeColaboradores;
        }


        public List<ColaboradoresDto> ListarActivos()
        {
            var colaboradoresConPagos = (from c in _elContexto.ColaboradoresTabla
                                         join p in _elContexto.PersonasTabla
                                             on c.IdPersona equals p.IdPersona
                                         join e in _elContexto.EstadoDisponibilidadTabla
                                             on c.IdEstado equals e.IdEstado
                                         join u in _elContexto.UsuariosTabla
                                             on c.IdPersona equals u.IdPersona into usuarios
                                         from u in usuarios.DefaultIfEmpty()
                                         join pa in _elContexto.PagosTabla
                                             on c.IdColaborador equals pa.IdColaborador into pagos
                                         from pa in pagos.OrderByDescending(p => p.FechaPago).Take(1).DefaultIfEmpty()
                                         where c.IdEstado == 1
                                         select new ColaboradoresDto
                                         {
                                             IdColaborador = c.IdColaborador,
                                             IdPersona = p.IdPersona,
                                             IdEstado = c.IdEstado,
                                             NombreEstado = e.Nombre,
                                             Nombre = p.Nombre,
                                             SalarioDia = c.SalarioDia,
                                             Telefono = p.Telefono,
                                             Genero = p.Genero,
                                             Direccion = p.Direccion,
                                             Edad = p.Edad,
                                             Identificacion = p.Identificacion,
                                             TieneUsuario = u != null,
                                             FechaUltimoPago = pa != null ? (DateTime?)pa.FechaPago : null
                                         }).ToList();

            return colaboradoresConPagos;
        }








    }
}