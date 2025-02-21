using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.InventarioSucursal.Editar;
using ThomasSalon.Abstracciones.LN.Interfaces.General.Conversiones.InventarioSucursal;
using ThomasSalon.Abstracciones.LN.Interfaces.InventarioSucursal.Editar;
using ThomasSalon.Abstracciones.Modelos.InventarioSucursal;
using ThomasSalon.Abstracciones.Modelos.Productos;
using ThomasSalon.AccesoADatos.InventarioSucursal.Editar;
using ThomasSalon.LN.General.Conversiones.InventarioSucursal;

namespace ThomasSalon.LN.InventarioSucursal.Editar
{
    public class EditarInventarioSucursalLN  : IEditarInventarioSucursalLN
    {

        IEditarInventarioSucursalAD _editarInventarioSucursalAD;
        IConvertirAInventarioSucursalTabla _convertirAInventarioSucursalTabla;
        public EditarInventarioSucursalLN()
        {
            _editarInventarioSucursalAD = new EditarInventarioSucursalAD();
            _convertirAInventarioSucursalTabla = new ConvertirAInventarioSucursalTabla();
        }
        public async Task<int> Editar(InventarioSucursalDto elInventarioSucursalEnVista)
        {
            int cantidadDeDatosGuardados = await _editarInventarioSucursalAD.EditarInventarioSucursal(_convertirAInventarioSucursalTabla.ConvertirObjetoAInventarioSucursalTabla(elInventarioSucursalEnVista));
            return cantidadDeDatosGuardados;
        }
    }
}
