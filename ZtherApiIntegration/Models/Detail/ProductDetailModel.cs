using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZtherApiIntegration.Common;

namespace ZtherApiIntegration.Models.Detail
{
    public class ProductDetailModel
    {
        public String Code { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String DefaultGender { get; set; }
        public String DefaultCategory { get; set; }
        public String DefaultCollection { get; set; }               
        public String DefaultColorCode { get; set; }
        public String DefaultCategorySize { get; set; }
        public SeoModel Seo { get; set; }

        private String _image;
        public String Image
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

        public ProductDetailModel(String code, String name, String description, String image, String defaultColorCode, String defaultGender, String defaultCollection, String defaultCategory, String seoPageTitle, String seoDescription)
        {
            this.Code = code;
            this.Name = name;
            this.Description = description;
            this.Image = image;
            this.DefaultColorCode = defaultColorCode;
            this.DefaultCategory = defaultCategory;
            this.DefaultCollection = defaultCollection;
            this.DefaultGender = defaultGender;
            this.Seo = new SeoModel() { PageDescription = seoDescription, PageTitle = seoPageTitle };
        }
    }
}