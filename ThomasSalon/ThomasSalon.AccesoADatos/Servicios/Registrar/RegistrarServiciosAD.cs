using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Servicios.Registrar;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.AccesoADatos.Servicios.Registrar
{
    public class RegistrarServiciosAD : IRegistrarServiciosAD
    {
        Contexto _elContexto;

        public RegistrarServiciosAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<int> Registrar(ServiciosTabla elServicioAGuardar)
        {
            try
            {
                _elContexto.ServiciosTabla.Add(elServicioAGuardar);
                _elContexto.Entry(elServicioAGuardar).State = EntityState.Added;
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