using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.InventarioGeneral;

namespace ThomasSalon.Abstracciones.LN.Interfaces.InventarioGeneral
{
    public interface IInventarioGeneralLN
    {
        List<InventarioGeneralDto> Listar();
    }
}
