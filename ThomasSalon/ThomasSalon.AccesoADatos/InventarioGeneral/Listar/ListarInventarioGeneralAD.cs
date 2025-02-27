﻿using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.InventarioGeneral;
using ThomasSalon.Abstracciones.Modelos.InventarioGeneral;

namespace ThomasSalon.AccesoADatos.InventarioGeneral.Listar
{
    public class ListarInventarioGeneralAD : IInventarioGeneralAD
    {


        Contexto _elContexto;

        public ListarInventarioGeneralAD()
        {
            _elContexto = new Contexto();
        }
        public List<InventarioGeneralDto> Listar()
        {
            List<InventarioGeneralDto> laListaDeProductos =
                (from elInventario in _elContexto.InventarioGeneralTabla
                 join elProducto in _elContexto.ProductosTabla
                     on elInventario.IdProducto equals elProducto.IdProducto
                 join elProveedor in _elContexto.ProveedoresTabla
                     on elProducto.IdProveedor equals elProveedor.IdProveedor 
                 select new InventarioGeneralDto
                 {
                     IdInventarioGeneral = elInventario.IdInventarioGeneral,
                     IdProducto = elInventario.IdProducto,
                     NombreProducto = elProducto.Nombre,
                     Precio = elProducto.Precio,
                     CantidadTotal = elInventario.CantidadTotal,
                     NombreProveedor = elProveedor.Nombre, 
                     IdEstado = elInventario.IdEstado,
                 }).ToList();

            return laListaDeProductos;
        }

      

    }
}
