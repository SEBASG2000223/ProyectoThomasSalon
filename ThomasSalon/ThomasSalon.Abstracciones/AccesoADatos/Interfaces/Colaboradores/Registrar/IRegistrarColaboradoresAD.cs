using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Colaboradores.Registrar
{
    public interface IRegistrarColaboradoresAD
    {
        Task<int> Registrar(ColaboradoresTabla elColaboradorAGuardar);
    }
}