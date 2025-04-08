using System.Collections.Generic;
using ThomasSalon.Abstracciones.Modelos.Citas;

namespace ThomasSalon.Abstracciones.LN.Interfaces.Citas
{
    public interface IListarCitasLN
    {
        List<CitasDto> ListarAgendas(int idSucursal);
        List<CitasDto> ListarCitasUsuario(int idPersona);
    }
}
