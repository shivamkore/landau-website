using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZtherApiIntegration.Models.WhereToBuy;

namespace ZtherApiIntegration.API.Managers.WhereToBuy
{
    public class CountryManager
    {
        public static List<CountryModel> GetCountries()
        {
            using (var client = new LandauPortalWebAPI())
            {
                var countries = client.Countries.GetAll();
                return countries.Results.Select(x => new CountryModel() { Code = x.CountryCode, Name = x.CountryName }).ToList();
            }
        }
    }     
}