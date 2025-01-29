using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Sucursales.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Sucursales.Listar;
using ThomasSalon.Abstracciones.Modelos.Sucursales;
using ThomasSalon.AccesoADatos.Sucursales.Listar;

namespace ThomasSalon.LN.Sucursales.Listar
{
    public class ListarSucursalesLN : IListarSucursalesLN
    {
        IListarSucursalesAD _listarSucursalesAD;
      

        public ListarSucursalesLN()
        {
            _listarSucursalesAD = new ListarSucursalesAD();
        }
        public List<SucursalesDto> Listar()
        {
            List<SucursalesDto> laListaDeSucursales = _listarSucursalesAD.Listar();
            return laListaDeSucursales;
        }
    }
}
