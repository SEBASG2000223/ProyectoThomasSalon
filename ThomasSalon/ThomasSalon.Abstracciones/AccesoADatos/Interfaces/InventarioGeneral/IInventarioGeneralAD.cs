using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.InventarioGeneral;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.InventarioGeneral
{
    public interface IInventarioGeneralAD
    {
        List<InventarioGeneralDto> Listar();
    }
}
