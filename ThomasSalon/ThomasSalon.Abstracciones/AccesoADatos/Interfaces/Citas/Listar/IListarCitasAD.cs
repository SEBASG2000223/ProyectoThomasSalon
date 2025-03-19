using System.Collections.Generic;
using ThomasSalon.Abstracciones.Modelos.Citas;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Citas
{
    public interface IListarCitasAD
    {
        List<CitasDto> ListarAgendas(int idSucursal);
    }
}
