﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Productos;
using ThomasSalon.Abstracciones.Modelos.Sucursales;

namespace ThomasSalon.Abstracciones.LN.Interfaces.Productos.ObtenerPorId
{
    public interface IObtenerProductosPorIdLN
    {
        ProductosDto Obtener(int IdProducto);
    }
}
