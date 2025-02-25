using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Servicios.Listar;
using ThomasSalon.Abstracciones.Modelos.Servicios;

namespace ThomasSalon.AccesoADatos.Servicios.Listar
{
    public class ListarServiciosAD : IListarServiciosAD
    {
        Contexto _elContexto;

        public ListarServiciosAD()
        {
            _elContexto = new Contexto();
        }
        public List<ServiciosDto> Listar()
        {
            var listaDeServicios = (from servicio in _elContexto.ServiciosTabla
                                    join estado in _elContexto.EstadoDisponibilidadTabla
                                    on servicio.IdEstado equals estado.IdEstado
                                    select new ServiciosDto
                                    {
                                        IdServicio = servicio.IdServicio,
                                        Nombre = servicio.Nombre,
                                        Descripcion = servicio.Descripcion,
                                        Precio = servicio.Precio,
                                        LinkImagen= servicio.LinkImagen,
                                        Duracion = servicio.Duracion,
                                        IdEstado = servicio.IdEstado,
                                        NombreEstado = estado.Nombre
                                    }).ToList();
            return listaDeServicios;
        }
    }
}