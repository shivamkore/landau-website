using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZtherApiIntegration.Models.WhereToBuy;

namespace ZtherApiIntegration.Models
{
    public class RetailListModel
    {
        public List<RetailModel> Retailers { get; set; }
        public PaginationModel Pagination { get; set; }
        public SeoModel Seo { get; set; }

        public RetailListModel()
        {
            this.Retailers = new List<RetailModel>();
            this.Pagination = new PaginationModel();
            this.Seo = new SeoModel();
        }
    }
}