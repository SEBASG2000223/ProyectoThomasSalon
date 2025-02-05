using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Servicios.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.Servicios.ObtenerPorId;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.AccesoADatos.Servicios.ObtenerPorId
{
    public class ObtenerServiciosPorIdAD : IObtenerServiciosPorIdAD
    {
        Contexto _elContexto;

        public ObtenerServiciosPorIdAD()
        {
            _elContexto = new Contexto();
        }
        public ServiciosTabla Obtener(int IdServicio)
        {
            return _elContexto.ServiciosTabla.Where(s => s.IdServicio == IdServicio).FirstOrDefault();
        }
    }
}