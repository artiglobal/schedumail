using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using ScheduMail.WebMvc2.Models;

namespace ScheduMail.WebMvc2.Controllers
{
    /// <summary>
    /// Authentication provider interface.
    /// </summary>
    [HandleError]
    public class AccountController : Controller
    {
        /// <summary>
        /// Gets or sets the forms service.
        /// </summary>
        /// <value>The forms service.</value>
        public IFormsAuthenticationService FormsService { get; set; }

        /// <summary>
        /// Gets or sets the membership service.
        /// </summary>
        /// <value>The membership service.</value>
        public IMembershipService MembershipService { get; set; }

        /// <summary>
        /// Initializes data that might not be available when the constructor is called.
        /// </summary>
        /// <param name="requestContext">The HTTP context and route data.</param>
        protected override void Initialize(RequestContext requestContext)
        {
            if (this.FormsService == null) 
            { 
                this.FormsService = new FormsAuthenticationService(); 
            }

            if (this.MembershipService == null) 
            { 
                this.MembershipService = new AccountMembershipService(); 
            }

            base.Initialize(requestContext);
        }

        /// <summary>
        /// Logs the on.
        /// </summary>
        /// <returns>The view instance.</returns>
        public ActionResult LogOn()
        {
            return View();
        }

        /// <summary>
        /// Logs the on.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns>The Action result.</returns>
        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (this.MembershipService.ValidateUser(model.UserName, model.Password))
                {
                    this.FormsService.SignIn(model.UserName, model.RememberMe);
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        /// <summary>
        /// Logs the off.
        /// </summary>
        /// <returns>A Redirection to the Index Page.</returns>
        public ActionResult LogOff()
        {
           this.FormsService.SignOut();

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Registers this instance.
        /// </summary>
        /// <returns>The veiw instance.</returns>
        public ActionResult Register()
        {
            ViewData["PasswordLength"] = this.MembershipService.MinPasswordLength;
            return View();
        }

        /// <summary>
        /// Registers the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Teh view instance.</returns>
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus = this.MembershipService.CreateUser(model.UserName, model.Password, model.Email);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    this.FormsService.SignIn(model.UserName, false /* createPersistentCookie */);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(String.Empty, AccountValidation.ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = this.MembershipService.MinPasswordLength;
            return View(model);
        }

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <returns>The logged on view instance.</returns>
        [Authorize]
        public ActionResult ChangePassword()
        {
            ViewData["PasswordLength"] = this.MembershipService.MinPasswordLength;
            return View();
        }

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>The view instance.</returns>
        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if (this.MembershipService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword))
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = this.MembershipService.MinPasswordLength;
            return View(model);
        }

        /// <summary>
        /// Changes the password success.
        /// </summary>
        /// <returns>The instance view.</returns>
        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }
    }
}
