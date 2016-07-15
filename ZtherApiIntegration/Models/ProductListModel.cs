using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZtherApiIntegration.Common;
using ZtherApiIntegration.Models.Catalog;

namespace ZtherApiIntegration.Models
{
    public class ProductListModel
    {
        public List<ProductModel> Products { get; set; }
        public PaginationModel Pagination { get; set; }
        public SliderTextModel SliderText { get; set; }
        public bool DisplaySlider { get; set; }
        public SeoModel Seo { get; set; }
        public FilterDisplayModel FilterDisplay { get; set; }

        private string _image;
        public string CatalogImage
        {
            get
            {
                if (string.IsNullOrEmpty(_image))
                    return Constants.IMAGE_NOT_FOUND;
                return _image;
            }
            set
            {
                _image = value;
            }
        }        

        public ProductListModel()
        {
            this.Products = new List<ProductModel>();            
            this.Pagination = new PaginationModel();
            this.SliderText = new SliderTextModel();
            this.Seo = new SeoModel();
            this.FilterDisplay = new FilterDisplayModel();
            this.DisplaySlider = true;
        }
    }
}