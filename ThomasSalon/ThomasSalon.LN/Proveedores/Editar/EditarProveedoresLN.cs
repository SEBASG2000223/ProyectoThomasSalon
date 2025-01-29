using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Proveedores.Editar;
using ThomasSalon.Abstracciones.LN.Interfaces.General.Conversiones.Proveedores;
using ThomasSalon.Abstracciones.LN.Interfaces.Proveedores.Editar;
using ThomasSalon.Abstracciones.Modelos.Proveedores;
using ThomasSalon.AccesoADatos.Proveedores.Editar;
using ThomasSalon.LN.General.Conversiones.Proveedores;

namespace ThomasSalon.LN.Proveedores.Editar
{
    public class EditarProveedoresLN : IEditarProveedoresLN
    {
        IEditarProveedoresAD _editarProveedoresAD;
        IConvertirAProveedoresTabla _convertirAProveedoresTabla;
        public EditarProveedoresLN()
        {
            _editarProveedoresAD = new EditarProveedoresAD();
            _convertirAProveedoresTabla = new ConvertirAProveedoresTabla();
        }
        public async Task<int> Editar(ProveedoresDto elProveedorEnVista)
        {
            int cantidadDeDatosGuardados = await _editarProveedoresAD.Editar(_convertirAProveedoresTabla.ConvertirObjetoAProveedoresTabla(elProveedorEnVista));
            return cantidadDeDatosGuardados;
        }
    }
}