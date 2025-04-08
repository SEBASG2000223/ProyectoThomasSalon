using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Colaboradores;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Colaboradores.Listar
{
    public interface IListarColaboradoresAD
    {
        List<ColaboradoresDto> Listar();
        List<ColaboradoresDto> ListarDisponibles();
        //List<ColaboradoresDto> ObtenerColaboradores();
    }
}

