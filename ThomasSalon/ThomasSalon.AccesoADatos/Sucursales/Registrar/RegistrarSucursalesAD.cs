using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Sucursales.Registrar;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.AccesoADatos.Sucursales.Registrar
{
    public class RegistrarSucursalesAD : IRegistrarSucursalesAD
    {
        Contexto _elContexto;

        public RegistrarSucursalesAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<int> Registrar(SucursalesTabla laSucursalAGuardar)
        {
            try
            {
                _elContexto.SucursalesTabla.Add(laSucursalAGuardar);
                EntityState estado = _elContexto.Entry(laSucursalAGuardar).State = System.Data.Entity.EntityState.Added;
                int cantidadDeDatosGuardados = await _elContexto.SaveChangesAsync();
                return cantidadDeDatosGuardados;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
