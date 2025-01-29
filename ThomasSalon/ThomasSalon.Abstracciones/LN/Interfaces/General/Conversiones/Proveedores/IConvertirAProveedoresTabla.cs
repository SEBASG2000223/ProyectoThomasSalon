using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Productos;
using ThomasSalon.Abstracciones.Modelos.Proveedores;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.Abstracciones.LN.Interfaces.General.Conversiones.Proveedores
{
    public interface IConvertirAProveedoresTabla
    {

        ProveedoresTabla ConvertirObjetoAProveedoresTabla(ProveedoresDto elProveedor);
    }
}
