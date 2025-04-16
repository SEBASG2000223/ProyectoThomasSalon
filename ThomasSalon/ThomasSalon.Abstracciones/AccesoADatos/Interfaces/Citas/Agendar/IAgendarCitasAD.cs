using System;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Citas;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Citas.Agendar
{
    public interface IAgendarCitasAD
    {
        Task<int> AgendarCitaPresencial(CitasDto modelo, int idSucursal);
        Task<int> AgendarCitaLinea(CitasDto modelo, string idUsuario);
    }
}
