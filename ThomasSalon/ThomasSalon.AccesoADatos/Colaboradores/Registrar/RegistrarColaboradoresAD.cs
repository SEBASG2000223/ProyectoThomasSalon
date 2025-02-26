using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

        public async Task<int> Inactivar(int IdPersona)
        {
            try
            {
                var colaborador = await _elContexto.ColaboradoresTabla
                    .FirstOrDefaultAsync(c => c.IdPersona == IdPersona);

                if (colaborador == null)
                {
                    return 0; // No se encontró el colaborador
                }

                // Opción 1: Inactivar (Recomendado)
                colaborador.IdEstado = 2; // Asegúrate de que tu tabla tenga un campo 'Estado' (bit o boolean)
                _elContexto.Entry(colaborador).State = EntityState.Modified;

                return await _elContexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al inactivar colaborador: {ex.Message}");
                throw new Exception("Hubo un error al inactivar el colaborador.", ex);
            }
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
