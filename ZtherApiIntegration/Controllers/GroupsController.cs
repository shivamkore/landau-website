using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZtherApiIntegration.Models.Groups;
using ZtherApiIntegration.API.Managers.Groups;
using ZtherApiIntegration.API.Managers.State;
using ZtherApiIntegration.Common;

namespace ZtherApiIntegration.Controllers
{
    public class GroupsController : BaseController
    {
        // GET: Groups
        [Route(UrlBuilder.GROUPS)]
        public ActionResult Index()
        {
            // Redirecting to the new Landau Group site.
            return RedirectPermanent("https://groups.landau.com");

            this.FillSeoInformation("Group Order");

            ViewBag.Scripts = new List<string>() { "form.js" };
            ViewBag.IsContactOrGroup = true;

            GroupModel groupModel = new GroupModel();
            groupModel.Brand = this.CurrentBrand;
            groupModel.Inquiry.IndustryList = GroupManager.GetIndustryList(groupModel.Brand);
            groupModel.Inquiry.StateList = StateManager.GetStateModelList();
            groupModel.Purchase.OutfittedList = GroupManager.GetOutfittedList(groupModel.Brand);

            return View(PathFromView("Groups"), groupModel);
        }

        // GET: Groups
        [Route(UrlBuilder.GROUP_THANK_YOU)]
        public ActionResult ThankYou()
        {
            this.FillSeoInformation("Group Order");
            ViewBag.HasNoFollow = true;

            return View(PathFromView("GroupsThankYou"));
        }

        [HttpPost]
        public ActionResult Create(GroupModel groupModel)
        {
            this.FillSeoInformation("Group Order");

            ViewBag.Scripts = new List<string>() { "form.js" };
            ViewBag.IsContactOrGroup = true;

            groupModel.Brand = this.CurrentBrand;
            groupModel.Inquiry.IndustryList = GroupManager.GetIndustryList(groupModel.Brand);
            groupModel.Inquiry.StateList = StateManager.GetStateModelList();
            groupModel.Purchase.OutfittedList = GroupManager.GetOutfittedList(groupModel.Brand);

            if (ModelState.IsValid)
            {
                var ok = GroupManager.Create(groupModel);
                if (ok)
                    return RedirectToAction("ThankYou");
                return RedirectToAction("Index");
                //return Redirect("/Index#");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

    }
}
