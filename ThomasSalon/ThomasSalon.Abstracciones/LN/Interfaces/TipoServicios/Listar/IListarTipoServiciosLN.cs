using System.Collections.Generic;
using ThomasSalon.Abstracciones.Modelos.TiposServicios;

namespace ThomasSalon.Abstracciones.LN.Interfaces.TipoServicios.Listar
{
    public interface IListarTipoServiciosLN
    {
        List<TiposServiciosDto> Listar();
    }
}
