using System.Collections.Generic;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.TipoServicios;
using ThomasSalon.Abstracciones.LN.Interfaces.TipoServicios.Listar;
using ThomasSalon.Abstracciones.Modelos.TiposServicios;
using ThomasSalon.AccesoADatos.TiposServicios;

namespace ThomasSalon.LN.TipoServicios.Listar
{
    public class ListarTipoServiciosLN : IListarTipoServiciosLN
    {
        IListarTipoServiciosAD _listarTipoServiciosAD;

        public ListarTipoServiciosLN()
        {
            _listarTipoServiciosAD = new ListarTipoServiciosAD();
        }
        public List<TiposServiciosDto> Listar()
        {
            List<TiposServiciosDto> laListaDeTiposDeServicios = _listarTipoServiciosAD.Listar();
            return laListaDeTiposDeServicios;
        }
    }
}
