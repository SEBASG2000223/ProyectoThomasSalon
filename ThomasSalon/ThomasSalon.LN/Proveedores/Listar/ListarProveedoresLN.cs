using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Proveedores.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Proveedores.Listar;
using ThomasSalon.Abstracciones.Modelos.Proveedores;
using ThomasSalon.AccesoADatos.Proveedores.Listar;

namespace ThomasSalon.LN.Proveedores.Listar
{
    public class ListarProveedoresLN : IListarProveedoresLN
    {
        IListarProveedoresAD _listarProveedoresAD;

        public ListarProveedoresLN()
        {
            _listarProveedoresAD = new ListarProveedoresAD();
        }
        public List<ProveedoresDto> Listar()
        {
            List<ProveedoresDto> laListaDeProveedores = _listarProveedoresAD.Listar();
            return laListaDeProveedores;
        }

        //public List<ProveedoresDto> ObtenerProveedores()
        //{
        //    return _listarProveedoresAD.ObtenerProveedores();
        //}
    }
}