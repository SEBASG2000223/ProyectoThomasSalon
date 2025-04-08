using System.Collections.Generic;
using ThomasSalon.Abstracciones.Modelos.Deducciones;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Deducciones.Listar
{
    public interface IListarDeduccionesAD
    {
        List<DeduccionesDto> ListarDeduccionesUsuario(int idColaborador);
    }
}
