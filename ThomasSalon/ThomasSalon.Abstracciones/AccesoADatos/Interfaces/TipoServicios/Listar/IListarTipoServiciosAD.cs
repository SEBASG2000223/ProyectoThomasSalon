using System.Collections.Generic;
using ThomasSalon.Abstracciones.Modelos.TiposServicios;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.TipoServicios
{
    public interface IListarTipoServiciosAD
    {
        List<TiposServiciosDto> Listar();
    }
}
