using System.Collections.Generic;
using System.Linq;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Citas;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Servicios.ObtenerPorId;
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
                                           join persona in _elContexto.PersonasTabla
                                           on cita.IdPersona equals persona.IdPersona
                                           join colaborador in _elContexto.ColaboradoresTabla
                                           on cita.IdColaborador equals colaborador.IdColaborador into colabGroup
                                           from colaborador in colabGroup.DefaultIfEmpty() 
                                           join colaboradorPersona in _elContexto.PersonasTabla
                                           on colaborador.IdPersona equals colaboradorPersona.IdPersona into colabPersonaGroup
                                           from colaboradorPersona in colabPersonaGroup.DefaultIfEmpty() 
                                           join estado in _elContexto.EstadoCitaTabla
                                           on cita.IdEstadoCita equals estado.IdEstadoCita
                                           where cita.IdSucursal == idSucursal && estado.Nombre != "Cancelada"

                                           select new CitasDto
                                           {
                                               IdCita = cita.IdCita,
                                               IdServicio = cita.IdServicio,
                                               IdSucursal = cita.IdSucursal,
                                               IdPersona = cita.IdPersona,
                                               IdColaborador = cita.IdColaborador,
                                               IdEstadoCita = cita.IdEstadoCita,
                                               FechaHora = cita.FechaHora,
                                               Comentario = cita.Comentario,
                                               nombreServicio = servicio.Nombre,
                                               nombrePersona = persona.Nombre,
                                               nombreEstadoCita = estado.Nombre,
                                               nombreColaborador = colaboradorPersona.Nombre,
                                               DuracionServicio = servicio.Duracion
                                           }).ToList();

            return laListaCitas;
        }


        public List<CitasDto> ListarCitasUsuario(int idPersona)
        {
            List<CitasDto> laListaCitas = (from cita in _elContexto.CitasTabla
                                           join sucursal in _elContexto.SucursalesTabla
                                           on cita.IdSucursal equals sucursal.IdSucursal
                                           join servicio in _elContexto.ServiciosTabla
                                           on cita.IdServicio equals servicio.IdServicio
                                           join persona in _elContexto.PersonasTabla
                                           on cita.IdPersona equals persona.IdPersona
                                           join colaborador in _elContexto.ColaboradoresTabla
                                           on cita.IdColaborador equals colaborador.IdColaborador into colabGroup
                                           from colaborador in colabGroup.DefaultIfEmpty()
                                           join colaboradorPersona in _elContexto.PersonasTabla
                                           on colaborador.IdPersona equals colaboradorPersona.IdPersona into colabPersonaGroup
                                           from colaboradorPersona in colabPersonaGroup.DefaultIfEmpty()
                                           join estado in _elContexto.EstadoCitaTabla
                                           on cita.IdEstadoCita equals estado.IdEstadoCita
                                           where cita.IdPersona == idPersona

                                           select new CitasDto
                                           {
                                               IdCita = cita.IdCita,
                                               IdServicio = cita.IdServicio,
                                               IdSucursal = cita.IdSucursal,
                                               IdPersona = cita.IdPersona,
                                               IdColaborador = cita.IdColaborador,
                                               IdEstadoCita = cita.IdEstadoCita,
                                               FechaHora = cita.FechaHora,
                                               Comentario = cita.Comentario,
                                               nombreServicio = servicio.Nombre,
                                               nombrePersona = persona.Nombre,
                                               nombreEstadoCita = estado.Nombre,
                                               nombreColaborador = colaboradorPersona.Nombre,
                                               DuracionServicio = servicio.Duracion
                                           }).ToList();

            return laListaCitas;
        }

    }
}
