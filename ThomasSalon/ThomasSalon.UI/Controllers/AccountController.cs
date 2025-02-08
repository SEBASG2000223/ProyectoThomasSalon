using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ThomasSalon.Abstracciones.LN.Interfaces.Sucursales.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Usuarios.ObtenerPorId;
using ThomasSalon.AccesoADatos;
using ThomasSalon.LN.Sucursales.Listar;
using ThomasSalon.LN.Usuarios.ObtenerPorId;
using ThomasSalon.UI.Models;

namespace ThomasSalon.UI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        Contexto _elContexto;
        IListarSucursalesLN _listarSucursales;


        public AccountController()
        {

            _elContexto = new Contexto();
            _listarSucursales = new ListarSucursalesLN();
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager )
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

    
        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            try
            {
                var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
                switch (result)
                {
                    case SignInStatus.Success:
                        return RedirectToLocal(returnUrl);
                    case SignInStatus.LockedOut:
                        return View("Lockout");
                    case SignInStatus.RequiresVerification:
                        return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                    default:
                        ModelState.AddModelError("", "Credenciales incorrectas.");
                        return View(model);
                }
            }
            catch (Exception ex)
            {
                // Loguear error
                ModelState.AddModelError("", "Ocurrió un error inesperado al iniciar sesión.");
                return View(model);
            }
        }

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent:  model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = new ApplicationUser
                    {
                        UserName = model.Email,
                        Email = model.Email,
                        Nombre = model.Nombre,
                        Genero = model.Genero,
                        Direccion = model.Direccion,
                        Edad = model.Edad,
                        Identificacion = model.Identificacion,
                        IdEstado = 1,
                        IdSucursal = null,
                        PhoneNumber = model.PhoneNumber
                       
                    };

                    var result = await UserManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        
                        string rolAsignado = string.IsNullOrEmpty(model.Rol) ? "Usuario" : model.Rol;

                        await UserManager.AddToRoleAsync(user.Id, rolAsignado);
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToAction("Index", "Home");
                    }
                    AddErrors(result);
                }
                catch (Exception ex)
                {
                    // Loguear error
                    ModelState.AddModelError("", "Ocurrió un error al registrar el usuario.");
                }
            }

            return View(model);
        }   
        
        

        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult RegisterAdmin()
        {
            var sucursales = _listarSucursales.Listar();
            var rolesDisponibles = new List<SelectListItem>
    {
        new SelectListItem { Value = "Usuario", Text = "Usuario" },
        new SelectListItem { Value = "Gerente", Text = "Gerente" },
        new SelectListItem { Value = "Administrador", Text = "Administrador" }
    };

            ViewBag.Roles = new SelectList(rolesDisponibles, "Value", "Text");
            ViewBag.Sucursales = new SelectList(sucursales, "IdSucursal", "Nombre");
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterAdmin(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {

                   

                    var user = new ApplicationUser
                    {
                        UserName = model.Email,
                        Email = model.Email,
                        Nombre = model.Nombre,
                        Genero = model.Genero,
                        Direccion = model.Direccion,
                        Edad = model.Edad,
                        Identificacion = model.Identificacion,
                        IdEstado = 1,
                        IdSucursal = model.IdSucursal,
                        PhoneNumber = model.PhoneNumber
                    };

                    var result = await UserManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        string rolAsignado = string.IsNullOrEmpty(model.Rol) ? "Usuario" : model.Rol;

                        await UserManager.AddToRoleAsync(user.Id, rolAsignado);
                        return RedirectToAction("ListarUsuarios", "Usuarios"); // Redirige sin iniciar sesión
                    }
                    AddErrors(result);
                }
              
                    // Loguear error
                  catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error: " + ex.Message);
                }

            
        }

            return View(model);
        }

        // If we got this far, something failed, redisplay form

        // GET: /Account/EditAdmin
        public async Task<ActionResult> EditAdmin(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("ListarUsuarios", "Usuarios");
            }

            var user = await UserManager.FindByIdAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            var model = new EditViewModel
            {
                Id = id,
                Email = user.Email,
                Nombre = user.Nombre,
                Genero = user.Genero,
                Direccion = user.Direccion,
                Edad = user.Edad,
                Identificacion = user.Identificacion,
                IdEstado = user.IdEstado,
                IdSucursal = user.IdSucursal,
                PhoneNumber = user.PhoneNumber,
                Rol = (await UserManager.GetRolesAsync(user.Id)).FirstOrDefault() // Obtener el rol actual
            };

            // Obtener lista de sucursales con Id y Nombre
            var sucursales = _listarSucursales.Listar()
                .Select(s => new SelectListItem
                {
                    Value = s.IdSucursal.ToString(), // ID de la sucursal
                    Text = s.Nombre // Nombre de la sucursal
                }).ToList();

            ViewBag.Sucursales = new SelectList(sucursales, "Value", "Text", model.IdSucursal);

            var rolesDisponibles = await _elContexto.RolesTabla.Select(r => r.Name).ToListAsync();
            ViewBag.Roles = new SelectList(rolesDisponibles, model.Rol); // Selecciona el rol actual
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAdmin(EditViewModel model)
        {
            // Verifica si el modelo está llegando vacío
            if (model == null)
            {
                ModelState.AddModelError("", "El modelo no llegó al servidor.");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Buscar el usuario por su Id
                    var user = await UserManager.FindByIdAsync(model.Id);
                    if (user == null)
                    {
                        return HttpNotFound();
                    }

                    // Actualiza los campos del usuario
                    user.Email = model.Email;
                    user.UserName = model.Email;  // Asegúrate de actualizar el nombre de usuario
                    user.Nombre = model.Nombre;
                    user.Genero = model.Genero;
                    user.Direccion = model.Direccion;
                    user.Edad = model.Edad;
                    user.Identificacion = model.Identificacion;
                    user.IdEstado = model.IdEstado;
                    user.IdSucursal = model.IdSucursal;
                    user.PhoneNumber = model.PhoneNumber;

                    // Actualiza el usuario en la base de datos
                    var result = await UserManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        // Elimina los roles anteriores del usuario
                        var rolesActuales = await UserManager.GetRolesAsync(user.Id);
                        if (rolesActuales.Any())
                        {
                            // Elimina los roles anteriores
                            await UserManager.RemoveFromRolesAsync(user.Id, rolesActuales.ToArray());
                        }

                        // Asigna el nuevo rol al usuario
                        if (!string.IsNullOrEmpty(model.Rol))
                        {
                            await UserManager.AddToRoleAsync(user.Id, model.Rol);
                        }

                        // Redirige a la lista de usuarios
                        return RedirectToAction("ListarUsuarios", "Usuarios");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Error al actualizar el usuario.");
                    }
                }
                catch (Exception ex)
                {
                    // Captura cualquier excepción y agrega un mensaje de error
                    ModelState.AddModelError("", "Error: " + ex.Message);
                }
            }
            else
            {
                // Si el modelo no es válido, muestra los errores en la consola
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            // Si el modelo no es válido, redirige a la vista con los errores
            return View(model);
        }


        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await UserManager.FindByNameAsync(model.Email);
                    if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                    {
                        return View("ForgotPasswordConfirmation");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Ocurrió un error al procesar la solicitud de recuperación.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null)
                {
                    return RedirectToAction("ResetPasswordConfirmation", "Account");
                }
                var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("ResetPasswordConfirmation", "Account");
                }
                AddErrors(result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al restablecer la contraseña.");
            }

            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            try
            {
                var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (loginInfo == null)
                {
                    return RedirectToAction("Login");
                }

                var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
                switch (result)
                {
                    case SignInStatus.Success:
                        return RedirectToLocal(returnUrl);
                    case SignInStatus.LockedOut:
                        return View("Lockout");
                    case SignInStatus.RequiresVerification:
                        return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                    default:
                        ViewBag.ReturnUrl = returnUrl;
                        ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                        return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error al procesar el inicio de sesión externo.");
                return View("Error");
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    _userManager?.Dispose();
                    _signInManager?.Dispose();
                }
            }
            catch (Exception ex)
            {
                // Loguear error si ocurre al liberar recursos
                ModelState.AddModelError("", "Error al liberar recursos.");
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}