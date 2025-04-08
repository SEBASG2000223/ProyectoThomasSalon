using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Colaboradores;


namespace ThomasSalon.Abstracciones.LN.Interfaces.Colaboradores.Listar
{
    public interface IListarColaboradoresLN
    {
        List<ColaboradoresDto> Listar();
        List<ColaboradoresDto> ListarDisponibles();

        //List<ColaboradoresDto> ObtenerColaboradores();
    }
}
