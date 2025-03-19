using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Citas.ObtenerPorId;
using ThomasSalon.Abstracciones.Modelos.Citas;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.AccesoADatos.Citas.ObtenerPorId
{
    public class ObtenerCitaPorIdAD : IObtenerCitaPorIdAD
    {
        Contexto _elContexto;

        public ObtenerCitaPorIdAD()
        {
            _elContexto = new Contexto();
        }

        public List<CitasDto> DetallesCita(Guid IdCita)
        {
            List<CitasDto> laListaCitas = (from cita in _elContexto.CitasTabla
                                           join sucursal in _elContexto.SucursalesTabla
                                           on cita.IdSucursal equals sucursal.IdSucursal
                                           join servicio in _elContexto.ServiciosTabla
                                           on cita.IdServicio equals servicio.IdServicio
                                           join persona in _elContexto.PersonasTabla
                                           on cita.IdPersona equals persona.IdPersona
                                           join estado in _elContexto.EstadoCitaTabla
                                           on cita.IdEstadoCita equals estado.IdEstadoCita
                                           where cita.IdCita == IdCita
                                           select new CitasDto
                                           {
                                               IdCita = cita.IdCita,
                                               IdServicio = cita.IdServicio,
                                               IdSucursal = cita.IdSucursal,
                                               IdPersona = cita.IdPersona,
                                               IdEstadoCita = cita.IdEstadoCita,
                                               FechaHora = cita.FechaHora,
                                               Comentario = cita.Comentario,
                                               nombreServicio = servicio.Nombre,
                                               nombrePersona = persona.Nombre,
                                               DuracionServicio = servicio.Duracion
                                           }).ToList();
            return laListaCitas;
        }
    }
}
