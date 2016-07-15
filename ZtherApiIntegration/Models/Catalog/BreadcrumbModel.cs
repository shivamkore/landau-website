using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZtherApiIntegration.Models.Catalog
{
    public class BreadcrumbModel
    {
        public string GenderFilter { get; set; }
        public string Gender { get; set; }
        public DropDownModel Collection { get; set; }
        public DropDownModel Category { get; set; }

        public bool IsCategoryForNewProds { get; set; }

        public BreadcrumbModel()
        {
            IsCategoryForNewProds = false;        
        }

    }
}