using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Ventas.RegistrarVentaServicio;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;

namespace ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Ventas.RegistrarVentaServicio
{
    public interface IRegistrarVentaServicioAD
    {
        Task<int> RegistrarVentaServicio(RegistrarVentaServicioDTO ventaServicio);

    }
}
