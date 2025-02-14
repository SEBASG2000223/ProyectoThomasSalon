using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.InventarioSucursal;

namespace ThomasSalon.Abstracciones.LN.Interfaces.InventarioSucursal.Crear
{
    public interface ICrearInventarioSucursalLN
    {
    Task<int> Agregar(InventarioSucursalDto modelo);

    }
}
