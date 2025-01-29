using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Productos.Editar;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.AccesoADatos.Productos.Editar
{
    public class EditarProductosAD : IEditarProductosAD
    {
        Contexto _elContexto;

        public EditarProductosAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<int> Editar(ProductosTabla elProductoParaEditar)
        {
            ProductosTabla elProductoEnBD = _elContexto.ProductosTabla.Where(elProducto => elProducto.IdProducto == elProductoParaEditar.IdProducto).FirstOrDefault();
            elProductoEnBD.IdProducto = elProductoParaEditar.IdProducto;
            elProductoEnBD.Nombre = elProductoParaEditar.Nombre;
            elProductoEnBD.Descripcion = elProductoParaEditar.Descripcion;
            elProductoEnBD.Precio = elProductoParaEditar.Precio;
            elProductoEnBD.IdProveedor = elProductoParaEditar.IdProveedor;
            elProductoEnBD.UnidadMedida = elProductoParaEditar.UnidadMedida;
            elProductoEnBD.IdEstado = elProductoParaEditar.IdEstado;
            EntityState estado = _elContexto.Entry(elProductoEnBD).State = System.Data.Entity.EntityState.Modified;
            int cantidadDeDatosGuardados = await _elContexto.SaveChangesAsync();
            return cantidadDeDatosGuardados;
        }
    }
}