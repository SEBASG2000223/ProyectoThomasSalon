using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Productos.Registrar;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.AccesoADatos.Productos.Registrar
{
    public class RegistrarProductosAD : IRegistrarProductosAD
    {
        Contexto _elContexto;

        public RegistrarProductosAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<int> Registrar(ProductosTabla elProductoAGuardar)
        {
            try
            {
                _elContexto.ProductosTabla.Add(elProductoAGuardar);
                EntityState estado = _elContexto.Entry(elProductoAGuardar).State = System.Data.Entity.EntityState.Added;
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