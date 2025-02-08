using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasSalon.Abstracciones.ModelosDeBaseDeDatos
{
    public class UsuariosTabla
    {
        [Key]
        public string Id { get; set; }

        public string Email { get; set; }

       
    
    
    
        public string Nombre { get; set; }

        
        public string Genero { get; set; }

     
        public string Direccion { get; set; }

       
        public int Edad { get; set; }

       
        public string Identificacion { get; set; }

        public int IdEstado { get; set; }

       
        public int? IdSucursal { get; set; }

     
        public string PhoneNumber { get; set; }
    }
}
