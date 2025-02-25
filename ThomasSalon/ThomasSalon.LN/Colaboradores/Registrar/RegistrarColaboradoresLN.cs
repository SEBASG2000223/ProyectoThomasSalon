using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Colaboradores.Registrar;
using ThomasSalon.Abstracciones.LN.Interfaces.Colaboradores.Registrar;
using ThomasSalon.Abstracciones.Modelos.Colaboradores;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;
using ThomasSalon.AccesoADatos.Colaboradores.Registrar;
using ThomasSalon.LN.General.Conversiones;
using ThomasSalon.LN.General.Conversiones.Colaboradores;

namespace ThomasSalon.LN.Colaboradores.Registrar
{
    public class RegistrarColaboradoresLN : IRegistrarColaboradoresLN
    {
        IRegistrarColaboradoresAD _registrarColaboradoresAD;

        public RegistrarColaboradoresLN()
        {
            _registrarColaboradoresAD = new RegistrarColaboradoresAD();
        }

        public async Task<int> Inactivar(int IdPersona)
        {
            return await _registrarColaboradoresAD.Inactivar(IdPersona);
        }


        public async Task<int> Registrar(ColaboradoresDto modelo)
        {
            modelo.IdEstado = 1;
            return await _registrarColaboradoresAD.Registrar(new ColaboradoresTabla
            {
                IdPersona = modelo.IdPersona,
                SalarioDia = modelo.SalarioDia,
                IdEstado = modelo.IdEstado,
                
            });
        }
    }
}