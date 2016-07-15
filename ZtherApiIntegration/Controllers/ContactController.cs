using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZtherApiIntegration.Models.Contact;
using ZtherApiIntegration.API.Managers.Contact;
using ZtherApiIntegration.API.Managers.State;
using ZtherApiIntegration.Common;
using Recaptcha.Web;
using Recaptcha.Web.Mvc;

namespace ZtherApiIntegration.Controllers
{
    public class ContactController : BaseController
    {
        // GET: Contact
        [Route(UrlBuilder.CONTACT)]
        public ActionResult Index()
        {
            InitController();

            ContactModel contactModel = new ContactModel();
            contactModel.StateModelList=StateManager.GetStateModelList();
            return View(PathFromView("Contact"), contactModel);
        }

        [HttpPost]
        [Route(UrlBuilder.CONTACT)]
        public ActionResult Index(ContactModel contactModel)
        {
            RecaptchaVerificationHelper recaptchaHelper = this.GetRecaptchaVerificationHelper();

            if (String.IsNullOrEmpty(recaptchaHelper.Response))
            {
                ModelState.AddModelError("", "Captcha answer cannot be empty.");
                return Index();
            }

            if (ModelState.IsValid)
            {
                contactModel.Brand = this.CurrentBrand;
                var ok = ContactManager.Create(contactModel);
                if (ok)
                    return RedirectToAction("ThankYou");
                else
                    return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [Route(UrlBuilder.CONTACT_THANK_YOU)]
        public ActionResult ThankYou()
        {
            ViewBag.HasNoFollow = true;
            return View(PathFromView("ContactThankYou"));
        }

        private void InitController()
        {
            this.FillSeoInformation(UrlBuilder.CONTACT);

            ViewBag.Scripts = new List<string>() { "form.js" };
            ViewBag.IsContactOrGroup = true;
        }
    }
}
