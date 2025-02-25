using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Proveedores.Listar;
using ThomasSalon.Abstracciones.Modelos.Proveedores;
using ThomasSalon.Abstracciones.ModelosDeBaseDeDatos;




namespace ThomasSalon.AccesoADatos.Proveedores.Listar
{
    public class ListarProveedoresAD : IListarProveedoresAD
    {
        Contexto _elContexto;

        public ListarProveedoresAD()
        {
            _elContexto = new Contexto();
        }
        public List<ProveedoresDto> Listar()
        {
            List<ProveedoresDto> laListaDeProveedores = (from elProveedor in _elContexto.ProveedoresTabla
                                                         join elEstado in _elContexto.EstadoDisponibilidadTabla
                                                            on elProveedor.IdEstado equals elEstado.IdEstado
                                                         select new ProveedoresDto
                                                         {
                                                             IdProveedor = elProveedor.IdProveedor,
                                                             Nombre = elProveedor.Nombre,
                                                             Descripcion = elProveedor.Descripcion,
                                                             Telefono = elProveedor.Telefono,
                                                             Direccion = elProveedor.Direccion,
                                                             IdEstado = elProveedor.IdEstado,
                                                             NombreEstado = elEstado.Nombre
                                                         }).ToList();
            return laListaDeProveedores;
        }

        public List<ProveedoresDto> ListarActivos()
        {
            List<ProveedoresDto> laListaDeProveedores = (from elProveedor in _elContexto.ProveedoresTabla
                                                         join elEstado in _elContexto.EstadoDisponibilidadTabla
                                                            on elProveedor.IdEstado equals elEstado.IdEstado
                                                         where elProveedor.IdEstado == 1
                                                         select new ProveedoresDto
                                                         {
                                                             IdProveedor = elProveedor.IdProveedor,
                                                             Nombre = elProveedor.Nombre,
                                                             Descripcion = elProveedor.Descripcion,
                                                             Telefono = elProveedor.Telefono,
                                                             Direccion = elProveedor.Direccion,
                                                             IdEstado = elProveedor.IdEstado,
                                                             NombreEstado = elEstado.Nombre
                                                         }).ToList();
            return laListaDeProveedores;
        }

    }
}