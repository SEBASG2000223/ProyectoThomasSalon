﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.ModelosDeBaseDeDatos
{
    public class EstadoDisponibilidadTabla
    {
        [Key]
        public int IdEstado { get; set; }
        public string Nombre { get; set; }
    }
}
