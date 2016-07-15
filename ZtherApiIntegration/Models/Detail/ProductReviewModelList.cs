using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZtherApiIntegration.Models.Detail
{
    public class ProductReviewModelList
    {

        public List<ProductReviewModel> List { get; set; }
        public PaginationModel Pagination { get; set; }
        public Double Average { get; set; }

        public ProductReviewModelList()
        {
            this.List = new List<ProductReviewModel>();            
            this.Pagination = new PaginationModel();
        }

    }
}