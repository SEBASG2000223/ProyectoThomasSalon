using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Proveedores.Registrar;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.AccesoADatos.Proveedores.Registrar
{
    public class RegistrarProveedoresAD : IRegistrarProveedoresAD
    {
        Contexto _elContexto;

        public RegistrarProveedoresAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<int> Registrar(ProveedoresTabla elProveedorAGuardar)
        {
            try
            {
                bool existe = await VerficarExistenciaPorNombre(elProveedorAGuardar);

                if (existe)
                {
                    return 0;
                }

                _elContexto.ProveedoresTabla.Add(elProveedorAGuardar);
                _elContexto.Entry(elProveedorAGuardar).State = System.Data.Entity.EntityState.Added;
                int cantidadDeDatosGuardados = await _elContexto.SaveChangesAsync();
                return cantidadDeDatosGuardados;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        private async Task<bool> VerficarExistenciaPorNombre(ProveedoresTabla elProveedorAGuardar)
        {
            return await _elContexto.ProveedoresTabla
                .AnyAsync(p => p.Nombre == elProveedorAGuardar.Nombre);
        }
    }
}