using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZtherApiIntegration.API.Managers.Detail;
using ZtherApiIntegration.API.Models;
using ZtherApiIntegration.Models.Favorites;

namespace ZtherApiIntegration.API.Managers.Favorites
{
    public class FavoritesManager
    {
        public static List<FavoriteProduct> GetFavoriteProducts(List<FavoriteProduct> codesAndColors)
        {
            using (var client = new LandauPortalWebAPI())
            {
                var result = new List<FavoriteProduct>();
                var favProducts = client.Products.GetAllByProductCodes(codesAndColors.Select(f => f.ProductCode).Distinct().ToArray()).Results;

                foreach (var aProd in codesAndColors)
                {
                    var inputFav = favProducts.Where(c => c.ProductCode == aProd.ProductCode).FirstOrDefault();
                    if (inputFav != null)
                    {
                        var fav = new FavoriteProduct();

                        fav.ProductCode = aProd.ProductCode;
                        fav.ProductName = inputFav.ProductName;
                        fav.ColorCode = aProd.ColorCode;
                        fav.ColorHex = aProd.ColorHex;
                        fav.ColorName = aProd.ColorName;
                        fav.ColorUrl = aProd.ColorUrl;
                        fav.SizeCategory = aProd.SizeCategory;
                        fav.SizeCode = aProd.SizeCode;                        

                        var image = DetailManager.GetProductImageModelByColor(aProd.ProductCode, aProd.ColorCode);
                        fav.ProductDetailImageUri = image != null && image.Count > 0 ? image.First().DetailImageUri : string.Empty;

                        if (string.IsNullOrEmpty(fav.ProductDetailImageUri))
                            fav.ProductDetailImageUri = inputFav.Image != null ? inputFav.Image.DetailImageUri : string.Empty;


                        result.Add(fav);
                    }
                }

                return result;
            }
        }

        public static bool EmailFavs(FavoritesEmailModel favModel)
        {
            using (var client = new LandauPortalWebAPI())
            {
                var emailFav = new EmailFavorite()
                {

                    Brand = favModel.Brand,
                    EntryDate = DateTime.Now,
                    Message = favModel.Message,
                    RecipientEmail = favModel.RecipientEmail,
                    RecipientName = favModel.RecipientName,
                    SenderName = favModel.FullName,
                    Subject = favModel.Subject,
                    Products = favModel.FavProds != null ? favModel.FavProds.Distinct().ToList() : null
                };

                try
                {
                    client.EmailFavorites.Create(favModel.Brand, emailFav);
                    return true;
                }
                catch (Exception e)
                {
                    if (e is HttpOperationException)
                    {
                        var httpEx = (HttpOperationException)e;
                        return httpEx.Response.IsSuccessStatusCode;
                    }
                }
                return false;
            }
        }
    }
}