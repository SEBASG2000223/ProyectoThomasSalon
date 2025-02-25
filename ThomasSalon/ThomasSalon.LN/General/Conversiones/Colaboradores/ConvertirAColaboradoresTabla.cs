using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.LN.Interfaces.General.Conversiones.Colaboradores;
using ThomasSalon.Abstracciones.Modelos.Colaboradores;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.LN.General.Conversiones.Colaboradores
{
    internal class ConvertirAColaboradoresTabla : IConvertirAColaboradoresTabla
    {
        public ColaboradoresTabla ConvertirObjetoAColaboradoresTabla(ColaboradoresDto elColaborador)
        {
            return new ColaboradoresTabla
            {
                IdColaborador = elColaborador.IdColaborador,
                IdPersona= elColaborador.IdPersona,
                SalarioDia = elColaborador.SalarioDia,
                IdEstado = elColaborador.IdEstado
            };
        }
    }
}