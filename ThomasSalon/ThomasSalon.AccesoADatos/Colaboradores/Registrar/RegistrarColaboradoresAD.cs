using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Colaboradores.Registrar;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.AccesoADatos.Colaboradores.Registrar
{
    public class RegistrarColaboradoresAD : IRegistrarColaboradoresAD
    {
        Contexto _elContexto;

        public RegistrarColaboradoresAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Registrar(ColaboradoresTabla elColaboradorAGuardar)
        {
            try
            {
                _elContexto.ColaboradoresTabla.Add(elColaboradorAGuardar);
                _elContexto.Entry(elColaboradorAGuardar).State = EntityState.Added;
                int cantidadDeDatosGuardados = await _elContexto.SaveChangesAsync();
                return cantidadDeDatosGuardados;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
