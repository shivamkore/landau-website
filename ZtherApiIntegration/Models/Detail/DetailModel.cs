using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZtherApiIntegration.Models.Catalog;
using ZtherApiIntegration.Models.WhereToBuy;

namespace ZtherApiIntegration.Models.Detail
{
    public class DetailModel
    {
        public PaginationModel Pagination { get; set; }
        
        public ProductDetailModel ProductDetail { get; set; }
        public List<ProductImageModel> ProductImages { get; set; }
        public List<ProductVideoModel> ProductVideos { get; set; }
        public List<OnlineRetailModel> OnlineRetailers { get; set; }

        public ColorsAndSizesModel ColorsAndSizes { get; set; }        

        public List<ProductCoordinateModel> ProductCoordinates { get; set; }
        public ProductReviewModelList ProductReviews { get; set; }

        public BreadcrumbModel Breadcrumb { get; set; }

        public string NextProductUrl { get; set; }
        public string PreviousProductUrl { get; set; }

        /// <summary>
        /// Used only for keeping the previous selection in Solids or Prints page before going to prod detail
        /// </summary>
        public ProductColorModel SelectedColor { get; set; }

        public bool IsCanonicalUrl { get; set; }

        public DetailModel() {

            this.Pagination = new PaginationModel();
            this.Pagination.CurrentPage = 0;
            this.Pagination.PageCount = 0;
            this.Pagination.PageSize = 0;
            this.IsCanonicalUrl = false;
        }

        public bool HasVideo()
        {
            return (this.ProductVideos == null || this.ProductVideos.Count == 0 ? false : true);
        }

    }
}