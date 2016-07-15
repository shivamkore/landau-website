using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZtherApiIntegration.Models.Favorites
{
    public class FavoritesModel
    {
        public List<FavoriteProduct> FavoriteProducts { get; set; }

        public FavoritesModel()
        {
            this.FavoriteProducts = new List<FavoriteProduct>();
        }
    }
}