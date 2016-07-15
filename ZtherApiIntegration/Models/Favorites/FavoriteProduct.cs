using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZtherApiIntegration.Models.Favorites
{
    public class FavoriteProduct
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDetailImageUri { get; set; }
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public string ColorUrl { get; set; }
        public string ColorHex { get; set; }
        public string SizeCode { get; set; }
        public string SizeCategory { get; set; }

    }
}