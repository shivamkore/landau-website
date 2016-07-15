using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZtherApiIntegration.Models.Catalog
{
    public class FilterModel
    {
        public List<DropDownModel> Sizes { get; set; }
        public List<DropDownModel> FitTypes { get; set; }
        public List<DropDownModel> SortBy { get; set; }
        public List<DropDownModel> Colors { get; set; }
        public FilterDisplayModel FilterDisplay { get; set; }

        public FilterModel()
        {
            this.Sizes = new List<DropDownModel>();
            this.FitTypes = new List<DropDownModel>();
            this.SortBy = new List<DropDownModel>();
            this.Colors = new List<DropDownModel>();
        }
    }
}