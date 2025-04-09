using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Deducciones;

namespace ThomasSalon.Abstracciones.LN.Interfaces.Deducciones.Agregar
{
    public interface IAgregarDeduccionLN
    {
        Task<int> Agregar(DeduccionesDto modelo);
    }
}
