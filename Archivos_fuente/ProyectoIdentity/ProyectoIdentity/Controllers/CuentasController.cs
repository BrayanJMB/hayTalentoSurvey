﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using ProyectoIdentity.Models;
using ProyectoIdentity.Models.ModelsJourney;
using System.Security.Claims;

namespace ProyectoIdentity.Controllers
{
    
    public class CuentasController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IEmailSender _emailSender;

        public CuentasController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }



        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Registro(string returnurl = null)
        {
            ViewBag.Message = "Login";
            ViewData["ReturnUrl"] = returnurl;
            RegistroViewModel registroVM = new RegistroViewModel();
            return View(registroVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registro(RegistroViewModel rgViewModel, string returnurl = null)
        {
            ViewBag.Message = "Login";
            ViewData["ReturnUrl"] = returnurl;
            returnurl = returnurl??Url.Content("~/");
            if (ModelState.IsValid)
            {
                var usuario = new Company { UserName = rgViewModel.Email, Email = rgViewModel.Email, PersonFullName = rgViewModel.Nombre,PhoneNumber= rgViewModel.Telefono,PasswordHash=rgViewModel.Password,Name= rgViewModel.NombreCompania };
                var resultado = await _userManager.CreateAsync(usuario, rgViewModel.Password);

                if (resultado.Succeeded)
                {
                    //Implementación de confirmación de email en el registro
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(usuario);
                    var urlRetorno = Url.Action("ConfirmarEmail", "Cuentas", new { userId = usuario.Id, code = code }, protocol: HttpContext.Request.Scheme);
                    await _emailSender.SendEmailAsync(rgViewModel.Email, "Confirmar su cuenta - Proyecto Identity",
                    "Por favor confirme su cuenta dando click aquí: <a href=\"" + urlRetorno + "\">enlace</a>");


                    await _signInManager.SignInAsync(usuario, isPersistent: false);
                    //return RedirectToAction("Index", "Home");
                    return LocalRedirect(returnurl);
                }

                ValidarErrores(resultado);
            }

            return View(rgViewModel);
        }

        //Manejador de errores
        private void ValidarErrores(IdentityResult resultado)
        {
            foreach (var error in resultado.Errors)
            {
                ModelState.AddModelError(String.Empty, error.Description);
            }
        }

        //Método mostrar fomulario de acceso
        [HttpGet]
        public IActionResult Acceso(string returnurl=null)
        {
            ViewData["ReturnUrl"] = returnurl;
            ViewBag.Message = "Login";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Acceso(AccesoViewModel accViewModel, string returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            returnurl = returnurl??Url.Content("~/");
            if (ModelState.IsValid)
            {
                var resultado = await _signInManager.PasswordSignInAsync(accViewModel.Email, accViewModel.Password, accViewModel.RememberMe, lockoutOnFailure: true);

                if (resultado.Succeeded)
                {
                    
                    return RedirectToAction("Index", "Home");
                }
                if (resultado.IsLockedOut)
                {
                    return View("Bloqueado");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Acceso inválido");
                    ViewBag.Message = "Login";
                    return View(accViewModel);
                }
            }

            return View(accViewModel);
        }

        //Salir o cerrar sesión de la aplicacion (logout)
        [HttpGet]
        public async Task<IActionResult> SalirAplicacion()
        {
            await _signInManager.SignOutAsync();
            ViewBag.Message = "Login";
            return LocalRedirect("~/");
        }

        //[HttpGet]
        //public async Task<IActionResult> SalirAplicacion(int id)
        //{
        //    await _signInManager.SignOutAsync();
            
        //    return View();
        //}

        //Método para olvido de contraseña
        [HttpGet]
        public IActionResult OlvidoPassword()
        {
            ViewBag.Message = "Login";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OlvidoPassword(OlvidoPasswordViewModel opViewModel)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _userManager.FindByEmailAsync(opViewModel.Email);
                if (usuario == null)
                {
                    return RedirectToAction("ConfirmacionOlvidoPassword");
                }

                var codigo = await _userManager.GeneratePasswordResetTokenAsync(usuario);
                var urlRetorno = Url.Action("ResetPassword", "Cuentas", new {userId = usuario.Id, code = codigo}, protocol: HttpContext.Request.Scheme);

                await _emailSender.SendEmailAsync(opViewModel.Email, "Recuperar contraseña - Proyecto Identity",
                    "Por favor recupere su contraseña dando click aquí: <a href=\"" + urlRetorno + "\">enlace</a>");

                return RedirectToAction("ConfirmacionOlvidoPassword");
            }

            return View(opViewModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ConfirmacionOlvidoPassword()
        {
            ViewBag.Message = "Login";
            return View();
        }

        //Funcionalidad para recuperar contraseña
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string code=null)
        {
            ViewBag.Message = "Login";
            return code == null ? View("Error") : View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(RecuperaPasswordViewModel rpViewModel)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _userManager.FindByEmailAsync(rpViewModel.Email);
                if (usuario == null)
                {
                    return RedirectToAction("ConfirmacionRecuperaPassword");
                }

                var resultado = await _userManager.ResetPasswordAsync(usuario, rpViewModel.Code, rpViewModel.Password);
                if (resultado.Succeeded)
                {
                    return RedirectToAction("ConfirmacionRecuperaPassword");
                }


                ValidarErrores(resultado);
            }

            return View(rpViewModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ConfirmacionRecuperaPassword()
        {
            
            ViewBag.Message = "Login";
            return View(); ;
        }

        //Método para confirmación de email en el registro
        [HttpGet]
        public async Task<IActionResult> ConfirmarEmail(string userId, string code)
        {
            ViewBag.Message = "Login";
            if (userId == null || code == null)
            {
                return View("Error");
            }

            var usuario = await _userManager.FindByIdAsync(userId);
            if (usuario == null)
            {
                return View("Error");
            }

            var resultado = await _userManager.ConfirmEmailAsync(usuario, code);
            return View(resultado.Succeeded ? "ConfirmarEmail" : "Error");
        }


        //Configuración de acceso externo: facebook, google, twitter, etc

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult AccesoExterno(string proveedor, string returnurl = null)
        {
            var urlRedireccion = Url.Action("AccesoExternoCallback", "Cuentas", new { ReturnUrl = returnurl });
            var propiedades = _signInManager.ConfigureExternalAuthenticationProperties(proveedor, urlRedireccion);
            return Challenge(propiedades, proveedor);
        }

        [HttpGet]
        [AllowAnonymous]       
        public async Task<IActionResult> AccesoExternoCallback(string returnurl = null, string error = null)
        {
            returnurl = returnurl??Url.Content("~/");
            if (error != null)
            {
                ModelState.AddModelError(string.Empty, $"Error en el acceso externo {error}");
                return View(nameof(Acceso));
            }

            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction(nameof(Acceso));
            }

            //Acceder con el usuario en el proveedor externo
            var resultado = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);
            if (resultado.Succeeded)
            {
                //Actrualizar los tokens de acceso
                await _signInManager.UpdateExternalAuthenticationTokensAsync(info);
                return LocalRedirect(returnurl);
            }
            else
            {
                //Si el usuario no tiene cuenta pregunta si quier crear una
                ViewData["ReturnUrl"] = returnurl;
                ViewData["NombreAMostrarProveedor"] = info.ProviderDisplayName;
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                var nombre = info.Principal.FindFirstValue(ClaimTypes.Name);
                return View("ConfirmacionAccesoExterno", new ConfirmacionAccesoExternoViewModel { Email = email, Name = nombre});
            }
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmacionAccesoExterno(ConfirmacionAccesoExternoViewModel caeViewModel, string returnurl = null)
        {
            ViewBag.Message = "Login";
            returnurl = returnurl??Url.Content("~/");

            if (ModelState.IsValid)
            {
                //Obtener la información del usuario del proveedor externo
                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("Error");
                }

                var usuario = new Company { UserName = caeViewModel.Email, Email = caeViewModel.Email, PersonFullName = caeViewModel.Name };
                var resultado = await _userManager.CreateAsync(usuario);
                if (resultado.Succeeded)
                {
                    resultado = await _userManager.AddLoginAsync(usuario, info);
                    if (resultado.Succeeded)
                    {
                        await _signInManager.SignInAsync(usuario, isPersistent: false);
                        await _signInManager.UpdateExternalAuthenticationTokensAsync(info);
                        return LocalRedirect(returnurl);
                    }
                }
                ValidarErrores(resultado);
            }
            ViewData["ReturnUrl"] = returnurl;
            return View(caeViewModel);
        }

    }
}
