﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Sucursales;

namespace ThomasSalon.Abstracciones.LN.Interfaces.Sucursales.Editar
{
    public interface IEditarSucursalesLN
    {
        Task<int> Editar(SucursalesDto laSucursalEnVista);
    }
}
