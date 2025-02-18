using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Sucursales.Listar;
using ThomasSalon.Abstracciones.Modelos.Productos;
using ThomasSalon.Abstracciones.Modelos.Sucursales;

namespace ThomasSalon.AccesoADatos.Sucursales.Listar
{
    public class ListarSucursalesAD : IListarSucursalesAD
    {
        Contexto _elContexto;

        public ListarSucursalesAD()
        {
            _elContexto = new Contexto();
        }
        public List<SucursalesDto> Listar()
        {
            List<SucursalesDto> laListaDeSucursales = (from laSucursal in _elContexto.SucursalesTabla
                                                       join elEstado in _elContexto.EstadoDisponibilidadTabla
                                                    on laSucursal.IdEstado equals elEstado.IdEstado
                                                       select new SucursalesDto
                                                   {
                                                       IdSucursal = laSucursal.IdSucursal,
                                                       Nombre = laSucursal.Nombre,
                                                       LinkDireccion = laSucursal.LinkDireccion,
                                                       LinkImagen = laSucursal.LinkImagen,
                                                       Telefono = laSucursal.Telefono,
                                                       IdEstado = laSucursal.IdEstado,
                                                       NombreEstado = elEstado.Nombre

                                                       }).ToList();
            return laListaDeSucursales;
        }

        public List<SucursalesDto> ListarSucursalesActivas()
        {
            List<SucursalesDto> laListaDeSucursalesActivos = (from laSucursal in _elContexto.SucursalesTabla
                                                            join elEstado in _elContexto.EstadoDisponibilidadTabla
                                                               on laSucursal.IdEstado equals elEstado.IdEstado
                                                            where laSucursal.IdEstado == 1
                                                            select new SucursalesDto
                                                            {
                                                                IdSucursal = laSucursal.IdSucursal,
                                                                Nombre = laSucursal.Nombre,
                                                            }).ToList();
            return laListaDeSucursalesActivos;
        }
    }
}
