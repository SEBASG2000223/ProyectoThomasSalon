using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Colaboradores.CambiarEstado;
using ThomasSalon.Abstracciones.LN.Interfaces.Colaboradores.CambiarEstado;
using ThomasSalon.AccesoADatos.Colaboradores.CambiarEstado;
using ThomasSalon.LN.General.Conversiones;

namespace ThomasSalon.LN.Colaboradores.CambiarEstado
{
    public class CambiarEstadoColaboradoresLN : ICambiarEstadoColaboradoresLN
    {
        ICambiarEstadoColaboradoresAD _cambiarEstado;

        public CambiarEstadoColaboradoresLN()
        {
            _cambiarEstado = new CambiarEstadoColaboradoresAD();
        }
        public async Task<int> CambiarEstado(int IdColaborador, int nuevoEstado)
        {
            return await _cambiarEstado.CambiarEstado(IdColaborador, nuevoEstado);
        }
    }
}