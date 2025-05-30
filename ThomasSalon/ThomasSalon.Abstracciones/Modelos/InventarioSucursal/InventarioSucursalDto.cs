﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ThomasSalon.Abstracciones.Modelos.InventarioSucursal
{
    public class InventarioSucursalDto
    {

        [Display(Name = "Id Inventario", Description = "Id Inventario")]
        [Required]
        public Guid IdInventarioSucursal { get; set; }

        [Display(Name = "Identificador sucursal", Description = "Id Sucursal")]
        [Required]
        public int IdSucursal { get; set; }

        [Display(Name = "Identificador producto", Description = "Id del producto")]
        [Required]
        public int IdProducto { get; set; }

        [Display(Name = "Cantidad", Description = "Cantidad del producto")]
        [Required]
        public int Cantidad { get; set; }

        [Display(Name = "Estado", Description = "Estado")]
        [Required]
        public int IdEstado { get; set; }

        [Display(Name = "Precio", Description = "Precio del producto")]
        public decimal Precio { get; set; }

        [Display(Name = "Descripción", Description = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Nombre del producto", Description = "Nombre del producto")]
        public string NombreProducto { get; set; }
        [Display(Name = "Nombre del proveedor", Description = "Nombre del proveedor")]
        public string NombreProveedor { get; set; }

        [Display(Name = "Unidad de Medida", Description = "Unidad de Medida")]
        public int UnidadMedida { get; set; }


    }
}
