using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Productos.Editar;
using ThomasSalon.Abstracciones.LN.Interfaces.General.Conversiones.Productos;
using ThomasSalon.Abstracciones.LN.Interfaces.Productos.Editar;
using ThomasSalon.Abstracciones.Modelos.Productos;
using ThomasSalon.AccesoADatos.Productos.Editar;
using ThomasSalon.LN.General.Conversiones.Productos;

namespace ThomasSalon.LN.Productos.Editar
{
    public class EditarProductosLN : IEditarProductosLN
    {
        IEditarProductosAD _editarProductosAD;
        IConvertirAProductosTabla _convertirAProductosTabla;
        public EditarProductosLN()
        {
            _editarProductosAD = new EditarProductosAD();
            _convertirAProductosTabla = new ConvertirAProductosTabla();
        }
        public async Task<int> Editar(ProductosDto elProductoEnVista)
        {
            int cantidadDeDatosGuardados = await _editarProductosAD.Editar(_convertirAProductosTabla.ConvertirObjetoAProductosTabla(elProductoEnVista));
            return cantidadDeDatosGuardados;
        }
    }
}