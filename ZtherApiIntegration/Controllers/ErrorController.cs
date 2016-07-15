using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZtherApiIntegration.Common;

namespace ZtherApiIntegration.Controllers
{
    public class ErrorController : BaseController
    {
        [Route(UrlBuilder.ERROR)]
        public ViewResult Error404()
        {
            ViewBag.HasNoFollow = true;
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View(PathFromView("Error404"));
        }

        public ActionResult HTTP404()
        {
            throw Utility.Exception404();
        }

        public ActionResult PageNotFound()
        {
            ViewBag.HasNoFollow = true;
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View(PathFromView("Error404"));
        }

        public ActionResult ServerError(Exception ex)
        {
            ViewBag.HasNoFollow = true;
            Response.StatusCode = 500;
            Response.TrySkipIisCustomErrors = true;
            return View(PathFromView("Error404"));
        }

        public ActionResult BadRequest(Exception ex)
        {
            ViewBag.HasNoFollow = true;
            Response.StatusCode = 400;
            Response.TrySkipIisCustomErrors = true;
            return View(PathFromView("Error404"));
        }
    }
}
