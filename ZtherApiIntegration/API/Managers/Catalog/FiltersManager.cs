using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZtherApiIntegration.Models;
using ZtherApiIntegration.API;
using ZtherApiIntegration.Models.Catalog;

namespace ZtherApiIntegration.API.Managers.Catalog
{
    public class FiltersManager
    {
        public static FilterModel GetFilterModel(string brand, string gender)
        {
            using (var client = new LandauPortalWebAPI())
            {
                var filter = new FilterModel();
                filter.Sizes = GetSizes(client, gender);
                filter.FitTypes = GetFitTypes(client, brand);
                filter.Colors = GetColors(client, brand);
                filter.SortBy = GetSortOptions(client, brand);
                return filter;
            }
        }

        private static List<DropDownModel> GetSizes(LandauPortalWebAPI client, string gender)
        {
            var obs = client.Catalogs.GetAllSizeByGender(gender);

            return obs.Results.Select(s => new DropDownModel() { Name = s.Key, Value = s.Value }).ToList();
        }

        private static List<DropDownModel> GetFitTypes(LandauPortalWebAPI client, string brand)
        {
            var obs = client.Catalogs.GetAllPantFitTypeByBrand(brand);

            return obs.Results.Select(s => new DropDownModel() { Name = s.Key, Value = s.Value }).ToList();
        }

        private static List<DropDownModel> GetColors(LandauPortalWebAPI client, string brand)
        {
            var obs = client.Catalogs.GetAllColorByBrand(brand);

            return obs.Results.Select(s => new DropDownModel() { Name = s.Key, Value = s.Value }).ToList();
        }

        private static List<DropDownModel> GetSortOptions(LandauPortalWebAPI client, string brand)
        {
            var obs = client.Catalogs.GetAllSortByByBrand(brand);

            return obs.Results.Select(s => new DropDownModel() { Name = s.Key, Value = s.Value }).ToList();
        }
    }
}