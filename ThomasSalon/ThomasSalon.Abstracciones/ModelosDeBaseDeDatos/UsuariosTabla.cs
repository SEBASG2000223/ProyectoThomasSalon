using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThomasSalon.Abstracciones.Modelos.Personas;

namespace ThomasSalon.Abstracciones.ModelosDeBaseDeDatos
{
    public class UsuariosTabla
    {
        [Key]
        public string Id { get; set; }

        public string Email { get; set; }

        public int IdEstado { get; set; }

        public int? IdSucursal { get; set; }

        public int IdPersona { get; set; }

        // Propiedad de navegación para la tabla PersonasTabla
        public virtual PersonasTabla Persona { get; set; }
    }

}
