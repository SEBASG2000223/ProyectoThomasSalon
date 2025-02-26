using System.Collections.Generic;
using System.Linq;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Citas;
using ThomasSalon.Abstracciones.Modelos.Citas;

namespace ThomasSalon.AccesoADatos.Citas.Listar
{
    public class ListarCitasAD : IListarCitasAD
    {
        Contexto _elContexto;

        public ListarCitasAD()
        {
            _elContexto = new Contexto();
        }

        public List<CitasDto> ListarAgendas(int idSucursal)
        {
            List<CitasDto> laListaCitas = (from cita in _elContexto.CitasTabla
                                           join sucursal in _elContexto.SucursalesTabla
                                           on cita.IdSucursal equals sucursal.IdSucursal
                                           join servicio in _elContexto.ServiciosTabla
                                           on cita.IdServicio equals servicio.IdServicio
                                           join usuario in _elContexto.UsuariosTabla
                                           on cita.IdUsuario equals usuario.Id
                                           join estado in _elContexto.EstadoCitaTabla
                                           on cita.IdEstadoCita equals estado.IdEstadoCita
                                           where cita.IdSucursal == idSucursal
                                           select new CitasDto
                                           {
                                               IdCita = cita.IdCita,
                                               IdServicio = cita.IdServicio,
                                               IdSucursal = cita.IdSucursal,
                                               IdUsuario = cita.IdUsuario,
                                               IdEstadoCita = cita.IdEstadoCita,
                                               FechaHora = cita.FechaHora,
                                               Comentario = cita.Comentario,
                                               nombreServicio = servicio.Nombre, // Nuevo campo agregado
                                               nombreUsuario = usuario.Email // Nuevo campo agregado
                                           }).ToList();
            return laListaCitas;
        }
    }
}
