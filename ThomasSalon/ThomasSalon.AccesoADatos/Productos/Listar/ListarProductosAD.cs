﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Productos.Listar;
using ThomasSalon.Abstracciones.Modelos.Productos;

namespace ThomasSalon.AccesoADatos.Productos.Listar
{
    public class ListarProductosAD : IListarProductosAD
    {
        Contexto _elContexto;

        public ListarProductosAD()
        {
            _elContexto = new Contexto();
        }
        public List<ProductosDto> Listar()
        {

            List<ProductosDto> laListaDeProductos = (from elProducto in _elContexto.ProductosTabla
                                                     join elProveedor in _elContexto.ProveedoresTabla
                                                     on elProducto.IdProveedor equals elProveedor.IdProveedor
                                                     join elEstado in _elContexto.EstadoDisponibilidadTabla
                                                     on elProducto.IdEstado equals elEstado.IdEstado
                                                     select new ProductosDto
                                                     {
                                                         IdProducto = elProducto.IdProducto,
                                                         Nombre = elProducto.Nombre,
                                                         Descripcion = elProducto.Descripcion,
                                                         Precio = elProducto.Precio,
                                                         IdProveedor = elProducto.IdProveedor,
                                                         NombreProveedor = elProveedor.Nombre,
                                                         UnidadMedida = elProducto.UnidadMedida,
                                                         IdEstado = elProducto.IdEstado,
                                                         NombreEstado = elEstado.Nombre 
                                                     }).ToList();
            return laListaDeProductos;


        }
    }
}