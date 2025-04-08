using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Deducciones.Agendar;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.InventarioSucursal.Crear;
using ThomasSalon.Abstracciones.LN.Interfaces.Deducciones.Agregar;
using ThomasSalon.Abstracciones.Modelos.Deducciones;
using ThomasSalon.Abstracciones.Modelos.InventarioSucursal;
using ThomasSalon.AccesoADatos.Deducciones.Agregar;
using ThomasSalon.AccesoADatos.InventarioSucursal.Crear;

namespace ThomasSalon.LN.Deducciones.Agregar
{
    public class AgregarDeduccionLN : IAgregarDeduccionLN
    {

        IAgregarDeduccion _agregarDeduccionAD;

        public AgregarDeduccionLN()
        {
            _agregarDeduccionAD = new AgregarDeduccionAD();
        }
        public async Task<int> Agregar(DeduccionesDto modelo)
        {
            int cantidadDeDatosGuardados = await _agregarDeduccionAD.AgregarDeduccionConDetalle(modelo);
            return cantidadDeDatosGuardados;
        }
    }
}
