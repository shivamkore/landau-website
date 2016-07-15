using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZtherApiIntegration.Models;
using ZtherApiIntegration.Models.Collections;

namespace ZtherApiIntegration.API.Managers.Collections
{
    public class CollectionsManager
    {
        public static List<CollectionModel> SeasonalCollections(string brand)
        {
            using (var client = new LandauPortalWebAPI())
            {
                var colls = client.Banners.GetAllSeasonalByBrandAsync(brand);

                var result = colls.Results.Select(c => new CollectionModel() { Gender = c.Gender, Image = c.ImageUri, Code = c.Collection, Name = c.Name, Products = c.Products.Select(p => new ProductModel() { ColorCode = p.ColorCode, Code = p.ProductCode, Image = p.ImageUri, Name = p.ProductName }).ToList() }).ToList();
                
                //sortorder should have this value
                for (int i = 0; i < result.Count; i++)
                    result[i].Index = i + 1;

                return result;
            }
        }
    }
}