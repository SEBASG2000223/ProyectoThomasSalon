using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Proveedores.Registrar
{
    public interface IRegistrarProveedoresAD
    {
        Task<int> Registrar(ProveedoresTabla elProveedorAGuardar);
    }
}
