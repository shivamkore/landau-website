using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZtherApiIntegration.Common;
using ZtherApiIntegration.Models;
using ZtherApiIntegration.Models.Catalog;

namespace ZtherApiIntegration.API.Managers.Catalog
{
    public class SelectionsManager
    {

        public static CatalogSelectionModel GetSelectionModel(string brand)
        {
            using (var client = new LandauPortalWebAPI())
            {
                var selections = new CatalogSelectionModel();
                selections.WomenCategories = GetCategories(client, brand, Constants.WOMEN_GENDER);
                selections.WomenCollections = GetCollections(client, brand, Constants.WOMEN_GENDER);
                selections.MenCategories = GetCategories(client, brand, Constants.MEN_GENDER);
                selections.MenCollections = GetCollections(client, brand, Constants.MEN_GENDER);
                return selections;
            }
        }

        public static DropDownModel GetCategoryByName(string brand, string name, string gender)
        {
            using (var client = new LandauPortalWebAPI())
            {
                var obj = GetCategories(client, brand, gender, false).Where(c => UrlBuilder.GenerateSlug(c.Value) == name || c.Value.ToLower() == name.ToLower()).FirstOrDefault();

                return obj;
            }
        }

        public static DropDownModel GetCollectionByName(string brand, string name, string gender)
        {
            using (var client = new LandauPortalWebAPI())
            {
                var obj = GetCollections(client, brand, gender).Where(c => UrlBuilder.GenerateSlug(c.Value) == name || c.Value.ToLower() == name.ToLower()).FirstOrDefault();

                return obj;
            }
        }

        private static List<DropDownModel> GetCategories(LandauPortalWebAPI client, string brand, string gender, bool filterDisplay=true)
        {
            var obs = client.Catalogs.GetAllCategoryByBrand(brand, gender);

            return obs.Results.Where(d => !filterDisplay || (d.Display.HasValue && d.Display.Value)).Select(s => new DropDownModel() { Name = s.Key, Value = s.Value }).ToList();
        }

        private static List<DropDownModel> GetCollections(LandauPortalWebAPI client, string brand, string gender)
        {
            var obs = client.Catalogs.GetAllCollectionByBrand(brand, gender);

            return obs.Results.Select(s => new DropDownModel() { Name = s.Key, Value = s.Value }).ToList();
        }
    }
}