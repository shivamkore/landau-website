using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZtherApiIntegration.Common;


namespace ZtherApiIntegration.Models.Catalog
{
    public class CatalogSelectionModel
    {
        public List<DropDownModel> Genders { get; set; }
        public List<DropDownModel> MenCollections { get; set; }
        public List<DropDownModel> MenCategories { get; set; }
        public List<DropDownModel> WomenCollections { get; set; }
        public List<DropDownModel> WomenCategories { get; set; }
        public BreadcrumbModel Breadcrumb { get; set; }

        public CatalogSelectionModel()
        {
            this.Genders = new List<DropDownModel>();
            this.WomenCollections = new List<DropDownModel>();
            this.WomenCategories = new List<DropDownModel>();
            this.MenCollections = new List<DropDownModel>();
            this.MenCategories = new List<DropDownModel>();
            this.Breadcrumb = new BreadcrumbModel();
        }

        public List<DropDownModel> CategoriesByGender(string gender)
        {
            if (gender.ToLower() == Constants.MEN_GENDER)
                return MenCategories;
            else
                return WomenCategories;
        }

        public List<DropDownModel> CollectionsByGender(string gender)
        {
            if (gender.ToLower() == Constants.MEN_GENDER)
                return MenCollections;
            else
                return WomenCollections;
        }
    }
}