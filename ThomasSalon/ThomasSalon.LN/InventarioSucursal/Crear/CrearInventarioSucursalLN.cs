using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.InventarioSucursal.Crear;
using ThomasSalon.Abstracciones.LN.Interfaces.General.Conversiones.InventarioSucursal;
using ThomasSalon.Abstracciones.LN.Interfaces.InventarioSucursal.Crear;
using ThomasSalon.Abstracciones.Modelos.InventarioSucursal;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;
using ThomasSalon.AccesoADatos.InventarioSucursal.Crear;

namespace ThomasSalon.LN.InventarioSucursal.Crear
{
    public class CrearInventarioSucursalLN : ICrearInventarioSucursalLN
    {

        ICrearInventarioSucursalAD _crearInventarioAD;
        IConvertirAInventarioSucursalTabla _convertir;

        public CrearInventarioSucursalLN()
        {
            _crearInventarioAD = new CrearInventarioSucursalAD();
        }
        public async Task<int> Agregar(InventarioSucursalDto modelo)
        {
            int cantidadDeDatosGuardados = await _crearInventarioAD.Agregar(ConvertirObjetoAProductosTabla(modelo));
            return cantidadDeDatosGuardados;
        }
        private InventarioSucursalTabla ConvertirObjetoAProductosTabla(InventarioSucursalDto elInventario)
        {
            return new InventarioSucursalTabla
            {
                IdProducto = elInventario.IdProducto,
                IdSucursal = elInventario.IdSucursal,
                Cantidad = elInventario.Cantidad
            };
        }
    }
}
