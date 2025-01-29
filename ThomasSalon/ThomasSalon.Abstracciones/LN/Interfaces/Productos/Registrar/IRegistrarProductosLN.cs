using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Productos;
using ThomasSalon.Abstracciones.Modelos.Sucursales;

namespace ThomasSalon.Abstracciones.LN.Interfaces.Productos.Registrar
{
    public interface IRegistrarProductosLN
    {
        Task<int> Registrar(ProductosDto modelo);
    }
}
