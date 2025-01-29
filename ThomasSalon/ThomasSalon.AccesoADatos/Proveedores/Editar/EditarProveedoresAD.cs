using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Proveedores.Editar;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.AccesoADatos.Proveedores.Editar
{
    public class EditarProveedoresAD : IEditarProveedoresAD
    {
        Contexto _elContexto;

        public EditarProveedoresAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<int> Editar(ProveedoresTabla elProveedorParaEditar)
        {
            ProveedoresTabla elProveedorEnBD = _elContexto.ProveedoresTabla.Where(elProveedor => elProveedor.IdProveedor == elProveedorParaEditar.IdProveedor).FirstOrDefault();
            elProveedorEnBD.IdProveedor = elProveedorParaEditar.IdProveedor;
            elProveedorEnBD.Nombre = elProveedorParaEditar.Nombre;
            elProveedorEnBD.Descripcion = elProveedorParaEditar.Descripcion;
            elProveedorEnBD.Telefono = elProveedorParaEditar.Telefono;
            elProveedorEnBD.Direccion = elProveedorParaEditar.Direccion;
            elProveedorEnBD.IdEstado = elProveedorParaEditar.IdEstado;
            EntityState estado = _elContexto.Entry(elProveedorEnBD).State = System.Data.Entity.EntityState.Modified;
            int cantidadDeDatosGuardados = await _elContexto.SaveChangesAsync();
            return cantidadDeDatosGuardados;
        }
    }
}