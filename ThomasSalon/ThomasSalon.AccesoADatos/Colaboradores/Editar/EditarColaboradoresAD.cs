using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Colaboradores.Editar;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.AccesoADatos.Colaboradores.Editar
{
    public class EditarColaboradoresAD : IEditarColaboradoresAD
    {
        Contexto _elContexto;

        public EditarColaboradoresAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Editar(ColaboradoresTabla elColaboradorParaEditar)
        {
            ColaboradoresTabla elColaboradorEnBD = _elContexto.ColaboradoresTabla
                .Where(c => c.IdColaborador == elColaboradorParaEditar.IdColaborador)
                .FirstOrDefault();

            elColaboradorEnBD.Nombre = elColaboradorParaEditar.Nombre;
            elColaboradorEnBD.Telefono = elColaboradorParaEditar.Telefono;
            elColaboradorEnBD.SalarioDia = elColaboradorParaEditar.SalarioDia;
            elColaboradorEnBD.IdEstado = elColaboradorParaEditar.IdEstado;

            _elContexto.Entry(elColaboradorEnBD).State = EntityState.Modified;
            int cantidadDeDatosGuardados = await _elContexto.SaveChangesAsync();
            return cantidadDeDatosGuardados;
        }
    }
}