using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZtherApiIntegration.API.Managers.Favorites;
using ZtherApiIntegration.Common;
using ZtherApiIntegration.Filters;
using ZtherApiIntegration.Models.Detail;
using ZtherApiIntegration.Models.Favorites;

namespace ZtherApiIntegration.Controllers
{
    public class FavoritesController : BaseController
    {
        // GET: Favorites
        [Route(UrlBuilder.FAVS)]
        public ActionResult Index()
        {
            this.FillSeoInformation(UrlBuilder.FAVS);

            var model = new FavoritesModel();
            return View(PathFromView("Favorites"), model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [AjaxOnly]
        public ActionResult GetProducts(List<FavoriteProduct> favoritesModel)
        {
            var model = new FavoritesModel();
            if (favoritesModel != null)            
                model.FavoriteProducts  = FavoritesManager.GetFavoriteProducts(favoritesModel);                
            

            return PartialView(PathFromView("Partials/Favorites/_FavoriteItemPartial"), model);
        }

        [Route(UrlBuilder.FAVS_EMAIL)]
        public ActionResult Email()
        {
            this.FillSeoInformation(UrlBuilder.FAVS_EMAIL);

            var model = new FavoritesEmailModel();
            return View(PathFromView("FavoritesEmail"), model);
        }

        [HttpPost]
        [Route(UrlBuilder.FAVS_EMAIL)]
        public ActionResult Email(FavoritesEmailModel model)
        {
            if (ModelState.IsValid)
            {
                model.Brand = this.CurrentBrand;
                model.FavProds = string.IsNullOrEmpty(model.FavCodes) ? new List<String>() : model.FavCodes.Split(',').Where(f => !string.IsNullOrEmpty(f)).ToList();
                FavoritesManager.EmailFavs(model);

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

    }
}