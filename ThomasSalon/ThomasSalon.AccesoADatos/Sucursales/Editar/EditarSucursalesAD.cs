using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Sucursales.Editar;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.AccesoADatos.Sucursales.Editar
{
    public class EditarSucursalesAD : IEditarSucursalesAD
    {
        Contexto _elContexto;

        public EditarSucursalesAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<int> Editar(SucursalesTabla laSucursalParaEditar)
        {
            SucursalesTabla laSucursalEnBD = _elContexto.SucursalesTabla.Where(laSucursal => laSucursal.IdSucursal == laSucursalParaEditar.IdSucursal).FirstOrDefault();
            laSucursalEnBD.IdSucursal = laSucursalParaEditar.IdSucursal;
            laSucursalEnBD.Nombre = laSucursalParaEditar.Nombre;
            laSucursalEnBD.LinkDireccion = laSucursalParaEditar.LinkDireccion;
            laSucursalEnBD.LinkImagen = laSucursalParaEditar.LinkImagen;
            laSucursalEnBD.Telefono = laSucursalParaEditar.Telefono;
            EntityState estado = _elContexto.Entry(laSucursalEnBD).State = System.Data.Entity.EntityState.Modified;
            int cantidadDeDatosGuardados = await _elContexto.SaveChangesAsync();
            return cantidadDeDatosGuardados;
        }
    }
}
