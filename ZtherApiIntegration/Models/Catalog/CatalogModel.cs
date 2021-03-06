﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZtherApiIntegration.Common;

namespace ZtherApiIntegration.Models.Catalog
{
 
    public class CatalogModel
    {                
        public FilterModel Filters { get; set; }
        public CatalogSelectionModel Selections { get; set; }
        public ProductListModel ProductList { get; set; }
        public PowerReviewModel PowerReview { get; private set; }

        public CatalogModel()
        {            
            this.Filters = new FilterModel();
            this.Selections = new CatalogSelectionModel();
            this.ProductList = new ProductListModel();

            // Building and assigning Power Review Model.
            this.PowerReview = CommonService.GetPowerReviewModel(string.Empty);
        }
    }
}