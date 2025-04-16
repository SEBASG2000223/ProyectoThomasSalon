using System.Collections.Generic;
using System.Linq;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Deducciones.Listar;
using ThomasSalon.Abstracciones.Modelos.Deducciones;

namespace ThomasSalon.AccesoADatos.Deducciones.Listar
{
    public class ListarDeduccionesAD : IListarDeduccionesAD
    {
        Contexto _elContexto;

        public ListarDeduccionesAD()
        {
            _elContexto = new Contexto();
        }
        public List<DeduccionesDto> ListarDeduccionesUsuario(int idColaborador)
        {
            var deducciones = (from d in _elContexto.DeduccionesTabla
                               join elColaborador in _elContexto.ColaboradoresTabla
                               on d.IdColaborador equals elColaborador.IdColaborador
                               join laPersona in _elContexto.PersonasTabla
                               on elColaborador.IdPersona equals laPersona.IdPersona
                               where d.IdColaborador == idColaborador
                               select new DeduccionesDto
                               {
                                   IdDeduccion = d.IdDeduccion,
                                   IdColaborador = d.IdColaborador,
                                   MontoSemanal = d.MontoSemanal,
                                   TotalSaldo = d.TotalSaldo,
                                   nombreColaborador = laPersona.Nombre  
                               }).ToList();

            return deducciones;
        }


    }
}
