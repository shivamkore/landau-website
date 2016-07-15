using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using ZtherApiIntegration.API.Managers.SignUps;
using ZtherApiIntegration.Common;
using ZtherApiIntegration.Models;

namespace ZtherApiIntegration.Controllers
{
    public class FooterController : BaseController
    {
        [HttpPost]
        public ActionResult SignUp(string email)
        {
            var isValid = new EmailAddressAttribute();
            if (isValid.IsValid(email))
            {
                var model = new SignupModel()
                {
                    Brand = this.CurrentBrand,
                    Email = email,
                    EntryDate = DateTimeOffset.UtcNow
                };

                var ok = SignUpManager.SignUp(model);
                if (ok)
                    return RedirectToAction("ThankYou");
                return new EmptyResult();
            }
            else { return new EmptyResult(); }
        }

        [Route(UrlBuilder.SIGNUP_THANK_YOU)]
        public ActionResult ThankYou()
        {
            ViewBag.HasNoFollow = true;
            return View(PathFromView("SignupThankYou"));
        }

    }
}
