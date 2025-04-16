using System.Collections.Generic;
using ThomasSalon.Abstracciones.Modelos.Deducciones;

namespace ThomasSalon.Abstracciones.LN.Interfaces.Deducciones
{
    public interface IListarDeduccionesLN
    {
        List<DeduccionesDto> ListarDeduccionesUsuario(int idColaborador);
    }
}
