using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZtherApiIntegration.API.Managers.Catalog;
using ZtherApiIntegration.Models.Catalog;

namespace ZtherApiIntegration.Controllers
{
    public class HeaderController : BaseController
    {
        // GET: Header
        public ActionResult RenderHeader()
        {
            var model = SelectionsManager.GetSelectionModel(this.CurrentBrand);
            return PartialView(PathFromView("Partials/_HeaderPartial"), model);
        }
    }
}