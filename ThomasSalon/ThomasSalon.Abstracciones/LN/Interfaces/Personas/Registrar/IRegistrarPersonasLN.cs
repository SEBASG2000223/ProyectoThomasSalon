﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Colaboradores;
using ThomasSalon.Abstracciones.Modelos.Personas;

namespace ThomasSalon.Abstracciones.LN.Interfaces.Personas.Registrar
{
    public interface IRegistrarPersonasLN
    {
        Task<int> Registrar(PersonasDto modelo);
    }
}
