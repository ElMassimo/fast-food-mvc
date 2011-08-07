using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using FastFood.Front.Models;
using FastFood.Core.Security;
using FastFood.Core.Services;
using FastFood.Core.Models;

namespace FastFood.Front.Controllers
{
    public class AccountController : BaseController
    {
        private ISecurity clientSecurity = new ClientSecurity();
        private IClientServices clientServices = new ClientServices();
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
                if (clientSecurity.ValidateUser(model.Email,
                    FormsAuthentication.HashPasswordForStoringInConfigFile(model.Password, "sha1")))
                {
                    FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    else
                        return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");

            return View(model);
        }
        
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
        
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterClientModel model)
        {
            if (ModelState.IsValid) try{
                ClientModel client = model;
                client.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(client.Password, "sha1");
                client.Address.DependentLocalityName = GetLocalityName(client.Address.ToString());
                clientServices.Add(client);
                FormsAuthentication.SetAuthCookie(model.Email, false);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }
            return View(model);
        }
        
        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            bool changePasswordSucceeded;
            if (ModelState.IsValid)
            {
                try
                {
                    changePasswordSucceeded = clientSecurity.ChangePassword
                        (FormsAuthentication.HashPasswordForStoringInConfigFile(model.OldPassword, "sha1")
                        , FormsAuthentication.HashPasswordForStoringInConfigFile(model.NewPassword, "sha1")
                        , User.Identity.Name);
                }
                catch
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                    return RedirectToAction("ChangePasswordSuccess");
                else
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
            }
            return View(model);
        }
        
        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        public ActionResult Unauthorized()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");
            return RedirectToAction("Login", "Account");
        }
    }
}
