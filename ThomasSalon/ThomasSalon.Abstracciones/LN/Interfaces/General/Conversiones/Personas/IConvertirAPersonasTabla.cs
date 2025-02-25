using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Personas;
using ThomasSalon.Abstracciones.Modelos.Productos;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.Abstracciones.LN.Interfaces.General.Conversiones.Personas
{
    public interface IConvertirAPersonasTabla
    {
        PersonasTabla ConvertirObjetoAPersonasTabla(PersonasDto laPersona);

    }
}
