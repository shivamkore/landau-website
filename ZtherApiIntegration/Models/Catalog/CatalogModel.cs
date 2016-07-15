using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZtherApiIntegration.Models.Catalog
{
 
    public class CatalogModel
    {                
        public FilterModel Filters { get; set; }
        public CatalogSelectionModel Selections { get; set; }
        public ProductListModel ProductList { get; set; }

        public CatalogModel()
        {            
            this.Filters = new FilterModel();
            this.Selections = new CatalogSelectionModel();
            this.ProductList = new ProductListModel();
        }
    }
}