using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThomasSalon.UI.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Correo")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Codigo")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Recordar este buscador?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Correo")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Correo")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Recordarme?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La {0} tiene que ser {2} caracteres de largo", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no son similares")]
        public string ConfirmPassword { get; set; }

      
        [Display(Name = "Rol")]
        public string Rol { get; set; }

        [Required]
        [Display(Name = "Nombre Completo")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Género")]
        public string Genero { get; set; } // "M" o "F"

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Required]
        [Range(0, 120, ErrorMessage = "Ingrese una edad válida.")]
        [Display(Name = "Edad")]
        public int Edad { get; set; }

        [Display(Name = "Identificación")]
        public string Identificacion { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public int IdEstado { get; set; }

        [Display(Name = "Sucursal")]
        public int? IdSucursal { get; set; }

        [Display(Name = "Telefono")]
        public string PhoneNumber { get; set; }
      
    }
    public class EditViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string Email { get; set; }


        [Display(Name = "Rol")]
        public string Rol { get; set; }

        [Required]
        [Display(Name = "Nombre Completo")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Género")]
        public string Genero { get; set; } // "M" o "F"

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Required]
        [Range(0, 120, ErrorMessage = "Ingrese una edad válida.")]
        [Display(Name = "Edad")]
        public int Edad { get; set; }

        [Display(Name = "Identificación")]
        public string Identificacion { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public int IdEstado { get; set; }

        [Display(Name = "Sucursal")]
        public int? IdSucursal { get; set; }

        [Display(Name = "Telefono")]
        public string PhoneNumber { get; set; }
        public string Id { get; set; }
    }


    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La {0} tiene que ser {2} caracteres de largo", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Contraseña", ErrorMessage = "Las contraseñas no son similares")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string Email { get; set; }
    }
}
