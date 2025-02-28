using System.Collections.Generic;
using System.Linq;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.TipoServicios;
using ThomasSalon.Abstracciones.Modelos.TiposServicios;

namespace ThomasSalon.AccesoADatos.TiposServicios
{
    public class ListarTipoServiciosAD : IListarTipoServiciosAD
    {

        Contexto _elContexto;

        public ListarTipoServiciosAD()
        {
            _elContexto = new Contexto();
        }
        public List<TiposServiciosDto> Listar()
        {
            List<TiposServiciosDto> laListaDeTipos = (from elTipo in _elContexto.TipoServiciosTabla
                                                       select new TiposServiciosDto
                                                       {
                                                           IdTipoServicios = elTipo.IdTipoServicios,
                                                           Nombre = elTipo.Nombre,

                                                       }).ToList();
            return laListaDeTipos;
        }
    }
}
