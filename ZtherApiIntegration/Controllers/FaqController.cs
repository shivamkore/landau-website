using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZtherApiIntegration.Models.Faq;
using ZtherApiIntegration.API.Managers.Faq;
using ZtherApiIntegration.Common;

namespace ZtherApiIntegration.Controllers
{
    public class FaqController : BaseController
    {
        // GET: Faq
        [Route(UrlBuilder.FAQ)]
        public ActionResult Index()
        {
            InitController();
            FaqModel faqModel = new FaqModel();

            faqModel.Brand = this.CurrentBrand;
            return View(PathFromView("Faq"), faqModel);
        }


        [HttpPost]
        [Route(UrlBuilder.FAQ)]
        public ActionResult Index(FaqModel faqModel)
        {
            InitController();

            if (ModelState.IsValid)
            {
                faqModel.Brand = this.CurrentBrand;

                var ok = FaqManager.Create(faqModel);
                if (ok)
                    return RedirectToAction("ThankYou");
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [Route(UrlBuilder.FAQ_THANK_YOU)]
        public ActionResult ThankYou()
        {
            ViewBag.HasNoFollow = true;
            this.FillSeoInformation("Faq");
            return View(PathFromView("FaqThankYou"));
        }

        private void InitController()
        {
            this.FillSeoInformation("Faq");

            ViewBag.Scripts = new List<string>() { "faq.js" };
        }
    }
}
