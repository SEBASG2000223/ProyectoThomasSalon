using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Colaboradores.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Colaboradores.Listar;
using ThomasSalon.Abstracciones.Modelos.Colaboradores;
using ThomasSalon.AccesoADatos.Colaboradores.Listar;

namespace ThomasSalon.LN.Colaboradores.Listar
{
    public class ListarColaboradoresLN : IListarColaboradoresLN
    {
        IListarColaboradoresAD _listarColaboradoresAD;

        public ListarColaboradoresLN()
        {
            _listarColaboradoresAD = new ListarColaboradoresAD();
        }
        public List<ColaboradoresDto> Listar()
        {
            return _listarColaboradoresAD.Listar();
        }
        public List<ColaboradoresDto> ListarDisponibles()
        {
            return _listarColaboradoresAD.ListarDisponibles();
        }

        public List<ColaboradoresDto> ListarActivos()
        {
            return _listarColaboradoresAD.ListarActivos();
        }


    }
}