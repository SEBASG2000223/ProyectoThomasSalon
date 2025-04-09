using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Deducciones;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Deducciones.Agendar
{
    public interface IAgregarDeduccion
    {
        Task<int> AgregarDeduccionConDetalle(DeduccionesDto deduccion);
    }
}
