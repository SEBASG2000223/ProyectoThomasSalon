﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Personas;

namespace ThomasSalon.Abstracciones.Modelos.Colaboradores
{
    public class ColaboradoresDto
    {
        public int IdColaborador { get; set; }

        public decimal SalarioDia { get; set; }

        public int IdEstado { get; set; }

        public int IdPersona { get; set; }

        public string Nombre { get; set; }

        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int Edad { get; set; }
        public string NombreEstado { get; set; }
        public string Genero { get; set; }
        public string Identificacion { get; set; }


        public PersonasDto Persona { get; set; }
        public bool TieneUsuario { get; set; }
    }
}