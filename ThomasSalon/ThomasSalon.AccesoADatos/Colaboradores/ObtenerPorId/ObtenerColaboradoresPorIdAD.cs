using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Colaboradores.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.Colaboradores.ObtenerPorId;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.AccesoADatos.Colaboradores.ObtenerPorId
{
    public class ObtenerPorIdColaboradoresAD : IObtenerColaboradoresPorIdAD
    {
        Contexto _elContexto;

        public ObtenerPorIdColaboradoresAD()
        {   
            _elContexto = new Contexto();
        }

        public ColaboradoresTabla Obtener(int IdColaborador)
        {
            ColaboradoresTabla elColaboradorEnBD = _elContexto.ColaboradoresTabla.Where(elColaborador => elColaborador.IdColaborador == IdColaborador).FirstOrDefault();
            return elColaboradorEnBD;
        }
    }
}