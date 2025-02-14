using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Productos.Registrar;
using ThomasSalon.Abstracciones.LN.Interfaces.General.Conversiones.Productos;
using ThomasSalon.Abstracciones.LN.Interfaces.Productos.Registrar;
using ThomasSalon.Abstracciones.Modelos.Productos;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;
using ThomasSalon.AccesoADatos.Productos.Registrar;

namespace ThomasSalon.LN.Productos.Registrar
{
    public class RegistrarProductosLN : IRegistrarProductosLN
    {
        IRegistrarProductosAD _registrarProductosAD;
        IConvertirAProductosTabla _convertir;

        public RegistrarProductosLN()
        {
            _registrarProductosAD = new RegistrarProductosAD();
        }
        public async Task<int> Registrar(ProductosDto modelo)
        {
            modelo.IdEstado = 1;
            int cantidadDeDatosGuardados = await _registrarProductosAD.Registrar(ConvertirObjetoAProductosTabla(modelo));
            return cantidadDeDatosGuardados;
        }
        private ProductosTabla ConvertirObjetoAProductosTabla(ProductosDto elProducto)
        {
            return new ProductosTabla
            {
                Nombre = elProducto.Nombre,
                Descripcion = elProducto.Descripcion,
                Precio = elProducto.Precio,
                IdProveedor = elProducto.IdProveedor,
                UnidadMedida = elProducto.UnidadMedida,
                IdEstado = elProducto.IdEstado
            };
        }
    }
}