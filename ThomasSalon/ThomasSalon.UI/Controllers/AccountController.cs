using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Colaboradores.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Colaboradores.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.Colaboradores.Registrar;
using ThomasSalon.Abstracciones.LN.Interfaces.Personas.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.Personas.Registrar;
using ThomasSalon.Abstracciones.LN.Interfaces.Sucursales.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Usuarios.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.Usuarios.QuitarUsuarios;
using ThomasSalon.Abstracciones.Modelos.Colaboradores;
using ThomasSalon.Abstracciones.Modelos.Personas;
using ThomasSalon.AccesoADatos;
using ThomasSalon.AccesoADatos.Colaboradores.Listar;
using ThomasSalon.LN.Colaboradores.ObtenerPorId;
using ThomasSalon.LN.Colaboradores.Registrar;
using ThomasSalon.LN.Personas.ObtenerPorId;
using ThomasSalon.LN.Personas.Registrar;
using ThomasSalon.LN.Sucursales.Listar;
using ThomasSalon.LN.Usuarios.ObtenerPorId;
using ThomasSalon.LN.Usuarios.QuitarUsuarios;
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
        IRegistrarPersonasLN _registrarPersonas;
        IRegistrarColaboradoresLN _registrarColaboradores;
        IObtenerColaboradoresPorIdLN _obtener;
        IObtenerPersonasPorIdLN _obtenerp;
        IQuitarUsuariosLN _quitarUsuariosLN;
        IListarColaboradoresAD listarRoles;


        public AccountController()
        {

            _elContexto = new Contexto();
            _listarSucursales = new ListarSucursalesLN();
            _registrarPersonas = new RegistrarPersonasLN();
            _registrarColaboradores = new RegistrarColaboradoresLN();
            _obtener = new ObtenerColaboradoresPorIdLN();
            _obtenerp = new ObtenerPersonasPorIdLN();
            _quitarUsuariosLN = new QuitarUsuariosLN();
            listarRoles = new ListarColaboradoresAD();
        }




        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
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
        public async Task<ActionResult> QuitarUsuario(int idUsuario)
        {
            int resultado = await _quitarUsuariosLN.EliminarUsuario(idUsuario);

            if (resultado == 1)
            {
                var userId = User.Identity.GetUserId();

                if (userId == idUsuario.ToString())
                {

                    return RedirectToAction("LogOff", "Account");
                }
            }

            return RedirectToAction("ListarColaboradores", "Colaboradores");
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
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
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
        // GET: /Account/RegisterUsuarioColaborador
        [AllowAnonymous]
        public async Task<ActionResult> RegisterUsuarioColaborador(int? id)
        {

            if (id.HasValue)
            {
                var persona = _obtenerp.Obtener(id.Value);
                if (persona != null)
                {
                    var model = new RegisterViewModel
                    {
                        IdPersona = persona.IdPersona,
                        Persona = persona
                    };

                    var rolesDisponibles = await _elContexto.RolesTabla
                        .Where(r => r.Name == "Administrador" || r.Name == "Gerente")
                        .Select(r => r.Name)
                        .ToListAsync();

                    ViewBag.Roles = new SelectList(rolesDisponibles, model.Rol);



                    var sucursales = _listarSucursales.Listar();
                    ViewBag.Sucursales = new SelectList(sucursales, "IdSucursal", "Nombre");

                    return View(model);
                }
            }


            return View(new RegisterViewModel());
        }

        // POST: /Account/RegisterUsuarioColaborador
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterUsuarioColaborador(RegisterViewModel model, int? id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (id.HasValue && model.IdPersona == 0)
                    {
                        model.IdPersona = id.Value;
                    }


                    if (model.Persona != null && model.IdPersona == 0)
                    {

                        int idPersona = await _registrarPersonas.Registrar(model.Persona);
                        model.IdPersona = idPersona;
                    }


                    var user = new ApplicationUser
                    {
                        UserName = model.Email,
                        Email = model.Email,
                        IdEstado = 1,
                        IdSucursal = model.IdSucursal,
                        IdPersona = model.IdPersona
                    };


                    var result = await UserManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {

                        string rolAsignado = string.IsNullOrEmpty(model.Rol) ? "Administrador" : model.Rol;
                        await UserManager.AddToRoleAsync(user.Id, rolAsignado);


                        return RedirectToAction("ListarColaboradores", "Colaboradores");
                    }
                    else
                    {

                        AddErrors(result);
                    }
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", "Ocurrió un error al registrar el usuario.");
                }
            }

            return View(model);
        }

        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

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

                    if (model.Persona != null)
                    {

                        int idPersona = await _registrarPersonas.Registrar(model.Persona);
                        model.IdPersona = idPersona;

                    }

                    var user = new ApplicationUser
                    {
                        UserName = model.Email,
                        Email = model.Email,
                        IdEstado = 1,
                        IdSucursal = null,
                        IdPersona = model.IdPersona

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
                    if (model.Persona != null)
                    {

                        int idPersona = await _registrarPersonas.Registrar(model.Persona);
                        model.IdPersona = idPersona;

                    }


                    var user = new ApplicationUser
                    {
                        UserName = model.Email,
                        Email = model.Email,
                        IdPersona = model.IdPersona,
                        IdEstado = 1,
                        IdSucursal = model.IdSucursal,

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
            // Obtener detalles del colaborador si existe
            var colaborador = await _elContexto.ColaboradoresTabla
                .FirstOrDefaultAsync(c => c.IdPersona == user.IdPersona);
            // Obtener detalles de la persona relacionada
            var persona = await _elContexto.PersonasTabla
                .FirstOrDefaultAsync(p => p.IdPersona == user.IdPersona);

            if (persona == null)
            {
                return HttpNotFound();
            }

            var model = new EditViewModel
            {
                Email = user.Email,
                IdEstado = user.IdEstado,
                IdSucursal = user.IdSucursal,
                Rol = (await UserManager.GetRolesAsync(user.Id)).FirstOrDefault(), 
                IdPersona = user.IdPersona,
                Persona = new PersonasDto

                {
                    Nombre = persona.Nombre,
                    Genero = persona.Genero,
                    Direccion = persona.Direccion,
                    Telefono = persona.Telefono,
                    Edad = persona.Edad,
                    Identificacion = persona.Identificacion
                },
                Salario = colaborador?.SalarioDia ?? 0
            };

            // Obtener lista de sucursales con Id y Nombre
            var sucursales = _listarSucursales.Listar()
                .Select(s => new SelectListItem
                {
                    Value = s.IdSucursal.ToString(),
                    Text = s.Nombre
                }).ToList();

            ViewBag.Sucursales = new SelectList(sucursales, "Value", "Text", model.IdSucursal);
            if (ViewBag.Sucursales == null)
            {
                throw new Exception("ViewBag.Sucursales está llegando nulo.");
            }
            var rolesDisponibles = await _elContexto.RolesTabla
                       .Where(r => r.Name == "Administrador" || r.Name == "Gerente")
                       .Select(r => r.Name)
                       .ToListAsync();

            ViewBag.Roles = new SelectList(rolesDisponibles, model.Rol);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAdmin(EditViewModel model)
        {
            if (model == null)
            {
                ModelState.AddModelError("", "El modelo no llegó al servidor.");
                return View(model);
            }

            Console.WriteLine($"EditAdmin - IdPersona recibido: {model.IdPersona}");

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await UserManager.FindByIdAsync(model.Id.ToString());
                    if (user == null) return HttpNotFound();

                    var rolesActuales = await UserManager.GetRolesAsync(user.Id);
                    bool esAdminActual = rolesActuales.Contains("Administrador");

                    // Actualizar datos básicos del usuario
                    user.Email = model.Email;
                    user.UserName = model.Email;
                    user.IdEstado = model.IdEstado;
                    user.IdSucursal = model.IdSucursal;


                    var persona = await _elContexto.PersonasTabla.FirstOrDefaultAsync(p => p.IdPersona == model.IdPersona);
                    if (persona != null)
                    {
                        persona.Nombre = model.Persona.Nombre;
                        persona.Genero = model.Persona.Genero;
                        persona.Telefono = model.Persona.Telefono;
                        persona.Direccion = model.Persona.Direccion;
                        persona.Edad = model.Persona.Edad;
                        persona.Identificacion = model.Persona.Identificacion;
                    }
                    else
                    {
                        ModelState.AddModelError("", "La persona asociada no existe.");
                        return View(model);
                    }


                    // Actualizar usuario en la base de datos
                    var result = await UserManager.UpdateAsync(user);
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("", "Error al actualizar el usuario.");
                        return View(model);
                    }

                    // Manejo de roles
                    if (rolesActuales.Any())
                        await UserManager.RemoveFromRolesAsync(user.Id, rolesActuales.ToArray());

                    var rolAsignado = string.IsNullOrEmpty(model.Rol) ? "Usuario" : model.Rol;
                    await UserManager.AddToRoleAsync(user.Id, rolAsignado);


                    bool esAdminNuevo = model.Rol == "Administrador";

                    // 📌 Manejo de colaboradores (crear, inactivar o reactivar)
                    var colaboradorExistente = await _elContexto.ColaboradoresTabla
                        .FirstOrDefaultAsync(c => c.IdPersona == model.IdPersona);

                    if (!esAdminActual && esAdminNuevo) // Si antes no era admin y ahora sí
                    {
                        if (colaboradorExistente != null)
                        {
                            // Si el colaborador existe y está inactivo, solo se reactiva sin cambiar el salario
                            Console.WriteLine("Reactivando colaborador sin cambiar salario...");
                            colaboradorExistente.IdEstado = 1;
                        }
                        else
                        {
                            // Si no existe, se crea un nuevo colaborador
                            Console.WriteLine("Creando colaborador...");
                            var resultRegistrar = await _registrarColaboradores.Registrar(new ColaboradoresDto
                            {
                                IdPersona = model.IdPersona,
                                SalarioDia = model.Salario,
                                IdEstado = 1
                            });

                            Console.WriteLine($"Resultado de Registrar: {resultRegistrar}");
                        }
                    }
                    else if (esAdminActual && !esAdminNuevo) // Si era admin y ahora no lo es
                    {
                        // Si el usuario deja de ser administrador pero se convierte en gerente, no se inactiva ni cambia el salario
                        if (colaboradorExistente != null && model.Rol != "Gerente")
                        {
                            Console.WriteLine("Inactivando colaborador porque dejó de ser Administrador y no es Gerente...");
                            colaboradorExistente.IdEstado = 2;
                        }
                    }

                    await _elContexto.SaveChangesAsync();
                    return RedirectToAction("ListarUsuarios", "Usuarios");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error: " + ex.Message);
                    Console.WriteLine($"Error en EditAdmin: {ex.Message}");
                }
            }

            return View(model);
        }




        
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