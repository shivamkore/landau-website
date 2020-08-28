using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZtherApiIntegration.Models
{
    public enum Vendor : int
    {
        AllHeart = 1,
        ScrubsAndBeyond = 2,
        ScrubsOnCall = 3,
        A1Scrubs = 4
    }

    public class VendorProductPageModel
    {
        private List<ProductPageModel> _ProductPages = new List<ProductPageModel>();

        public VendorProductPageModel()
        {

        }

        public VendorProductPageModel(List<ProductPageModel> entities)
        {
            _ProductPages = entities;
        }

        public bool HasProductPage(Vendor vendor)
        {
            var page = this.GetVendorProductPage(vendor);

            return (page == null ? false : true);
        }

        public void AddProductPage(ProductPageModel model)
        {
            if (model != null)
            {
                if (model.VendorId > 0 && (!string.IsNullOrEmpty(model.ProductUrl)))
                    _ProductPages.Add(model);
            }
        }

        public ProductPageModel GetVendorProductPage(Vendor vendor)
        {
            return _ProductPages.Where(x => x.VendorId == (int)vendor).SingleOrDefault();
        }
    }

    public class ProductPageModel
    {
        public int VendorId { get; set; }
        public string ProductCode { get; set; }
        public string ColorCode { get; set; }
        public string ProductUrl { get; set; }
    }
}