using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Sucursales.Editar;
using ThomasSalon.Abstracciones.LN.Interfaces.General.Conversiones.Sucursales;
using ThomasSalon.Abstracciones.LN.Interfaces.Sucursales.Editar;
using ThomasSalon.Abstracciones.Modelos.Sucursales;
using ThomasSalon.AccesoADatos.Sucursales.Editar;
using ThomasSalon.LN.General.Conversiones.Sucursales;

namespace ThomasSalon.LN.Sucursales.Editar
{
    public class EditarSucursalesLN : IEditarSucursalesLN
    {
        IEditarSucursalesAD _editarSucursalesAD;
        IConvertirASucursalesTabla _convertirASucursalesTabla;
        public EditarSucursalesLN()
        {
            _editarSucursalesAD = new EditarSucursalesAD();
            _convertirASucursalesTabla = new ConvertirASucursalesTabla();
        }
        public async Task<int> Editar(SucursalesDto laSucursalEnVista)
        {
            int cantidadDeDatosGuardados = await _editarSucursalesAD.Editar(_convertirASucursalesTabla.ConvertirObjetoASucursalesTabla(laSucursalEnVista));
            return cantidadDeDatosGuardados;
        }
    }
}
