using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Colaboradores;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.Abstracciones.LN.Interfaces.General.Conversiones.Colaboradores
{
    public interface IConvertirAColaboradoresTabla
    {
        ColaboradoresTabla ConvertirObjetoAColaboradoresTabla(ColaboradoresDto elColaborador);
    }
}
