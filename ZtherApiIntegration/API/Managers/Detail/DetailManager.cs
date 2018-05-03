using System;
using System.Collections.Generic;
using System.Linq;
using ZtherApiIntegration.API.Managers.Review;
using ZtherApiIntegration.API.Managers.WhereToBuy;
using ZtherApiIntegration.Models;
using ZtherApiIntegration.Models.Detail;


namespace ZtherApiIntegration.API.Managers.Detail
{
    public class DetailManager
    {
        private const int COORDINATE_NUMBERS = 3;

        public static DetailModel GetModel(String brand, String code)
        {
            var model = new DetailModel();
            using (var client = new LandauPortalWebAPI())
            {
                model.ProductDetail = GetProductDetailModel(code, client);
                model.ColorsAndSizes = GetColorsAndSizes(code, model.ProductDetail.DefaultColorCode, client);
                model.ProductCoordinates = GetProductCoordinateModel(code, client);
                model.ProductImages = GetProductImageModelByColor(code, model.ProductDetail.DefaultColorCode, client);
                model.ProductVideos = GetProductVideoModel(code, client);
                model.OnlineRetailers = OnlineRetailManager.GetAllBuyNow(brand, code);
            }

            return model;
        }

        public static ProductDetailModel GetProductDetailModel(String code)
        {
            using (var client = new LandauPortalWebAPI())
            {
                return GetProductDetailModel(code, client);
            }
        }

        public static List<ProductSizeModel> GetSizesByColorAndSizeCategory(String code, String color, String category)
        {
            using (var client = new LandauPortalWebAPI())
            {
                return GetSizesByColorAndSizeCategory(code, color, category, client);
            }
        }

        private static List<ProductSizeModel> GetSizesByColorAndSizeCategory(String code, String color, String category, LandauPortalWebAPI client)
        {
            try
            {
                var obs = client.Products.GetAllSizeByProductAndColor(code, color);
                return obs.Results.Where(s => s.SizeCategory.ToLower() == category.ToLower()).OrderBy(s => s.SortOrder).Select(s => new ProductSizeModel() { SizeCategory = s.SizeCategory, SizeCode = s.SizeCode }).ToList();
            }
            catch { return new List<ProductSizeModel>(); }
        }

        private static ProductDetailModel GetProductDetailModel(String code, LandauPortalWebAPI client)
        {
            var prod = client.Products.GetByProduct(code);

            var detail = new ProductDetailModel(prod.ProductCode, prod.ProductName, prod.ProductDescription, prod.Image != null ? prod.Image.CatalogImageUri : null, prod.Image != null ? prod.Image.ColorCode : null, prod.Breadcrumb != null ? prod.Breadcrumb.Gender : null, prod.Breadcrumb != null && prod.Breadcrumb.Category != null ? prod.Breadcrumb.Collection : null, prod.Breadcrumb != null ? prod.Breadcrumb.Category : null, prod.Seo.PageTitle, prod.Seo.MetaDescription, prod.FitRiseWaist);

            return detail;
        }

        private static List<ProductSizeModel> GetProductSizeModel(String code)
        {
            using (var client = new LandauPortalWebAPI())
            {
                var obs = client.Products.GetAllSizeByProduct(code);
                return obs.Results.Select(s => new ProductSizeModel() { SizeCategory = s.SizeCategory, SizeCode = s.SizeCode }).ToList();
            }
        }

        private static Dictionary<String, List<String>> GetProductCategorySizeModel(String code, LandauPortalWebAPI client)
        {
            var obs = client.Products.GetAllSizeByProduct(code);
            List<ProductSizeModel> ProductSizeModelList = obs.Results.Select(s => new ProductSizeModel() { SizeCategory = s.SizeCategory, SizeCode = s.SizeCode }).ToList();
            Dictionary<string, List<string>> dictionary = ProductSizeModelList.GroupBy(x => x.SizeCategory).ToDictionary(g => g.Key, g => g.Select(x => x.SizeCode).ToList());

            return dictionary;
        }

        private static List<ProductColorModel> GetProductColorModel(String code, LandauPortalWebAPI client)
        {
            var obs = client.Products.GetAllColorByProduct(code);
            return obs.Results.Select(s => new ProductColorModel() {
                ColorCode = s.ColorCode, 
                ColorName = s.ColorName,
                PrimaryHex = s.PrimaryHex,                 
                SecondaryHex = s.SecondaryHex,
                SwatchType = s.SwatchType,
                ColorImageUrl = s.PrintImageUri 
            }).ToList();
        }

        private static List<ProductCoordinateModel> GetProductCoordinateModel(String code, LandauPortalWebAPI client)
        {
            var obs = client.Products.GetAllCoordinateByProduct(code);

            List<ProductCoordinateModel> ProductCoordinateModelList =
                obs.Results.Select(s => new ProductCoordinateModel()
                {
                    Code = s.ProductCode,
                    Name = s.ProductName,
                    ImageUri = s.ImageUri
                }).Take(COORDINATE_NUMBERS).ToList();
            return ProductCoordinateModelList;
        }

        private static List<ProductImageModel> GetProductImageModel(String code, LandauPortalWebAPI client)
        {

            List<ProductImageModel> list;
            try
            {
                var obs = client.ProductImages.GetAllByProduct(code);
                list = obs.Results.Select(s => new ProductImageModel()
                {
                    DetailImageUri = s.DetailImageUri,
                    ThumbnailImageUri = s.ThumbnailImageUri,
                    ZoomImageUri = s.ZoomImageUri
                }).ToList();

            }
            catch
            {
                list = new List<ProductImageModel>();
            }
            return list;
        }

        public static List<ProductVideoModel> GetProductVideoModel(String code)
        {
            using (var client = new LandauPortalWebAPI())
            {
                return GetProductVideoModel(code, client);
            }
        }

        private static List<ProductVideoModel> GetProductVideoModel(String code, LandauPortalWebAPI client)
        {

            List<ProductVideoModel> list;
            try
            {
                var obs = client.Products.GetAllVideoByProduct(code);
                list = obs.Results.OrderBy(x => x.SortOrder).Select(s => new ProductVideoModel()
                {
                    VideoName = s.VideoName,
                    SortOrder = (s.SortOrder.HasValue ? (int)s.SortOrder.Value : 0)
                }).ToList();

            }
            catch
            {
                list = new List<ProductVideoModel>();
            }
            return list;
        }

        public static List<ProductImageModel> GetProductImageModelByColor(String code, String color)
        {
            using (var client = new LandauPortalWebAPI())
            {
                return GetProductImageModelByColor(code, color, client);
            }
        }

        private static List<ProductImageModel> GetProductImageModelByColor(String code, String color, LandauPortalWebAPI client)
        {
            List<ProductImageModel> list;
            try
            {
                var obs = client.ProductImages.GetAllByProductAndColor(code, color);
                list = obs.Results.Select(s => new ProductImageModel()
                {
                    DetailImageUri = s.DetailImageUri,
                    ThumbnailImageUri = s.ThumbnailImageUri,
                    ZoomImageUri = s.ZoomImageUri
                }).ToList();

            }
            catch
            {
                list = new List<ProductImageModel>();
            }
            return list;
        }        

        public static List<ProductReviewModel> GetProductReviewModel(String code)
        {
            using (var client = new LandauPortalWebAPI())
            {
                var obs = client.ProductReviews.GetAllByProduct(code);
                List<ProductReviewModel> ProductReviewModelList;
                ProductReviewModelList = obs.Results.Select(s => new ProductReviewModel() {   
                                                                Comments    = s.Comments ,
                                                                FirstName   = s.FirstName ,
                                                                LastName    = s.LastName ,
                                                                Rating      =  s.Rating  ?? 0 ,
                                                                EntryDate   = (DateTimeOffset)s.EntryDate }).ToList();                                
                
                return ProductReviewModelList;
            }
        }

        public static ProductReviewModelList GetProductReviewModel(ReviewFilter reviewFilter)
        {
            using (var client = new LandauPortalWebAPI())
            {
                var reviews = client.ProductReviews.GetAllByProduct(reviewFilter.Code, reviewFilter.PageNumber, reviewFilter.Size);

                ProductReviewModelList productReviewModelList = new ProductReviewModelList();
                productReviewModelList.List = reviews.Results.Select(s => new ProductReviewModel()
                    {
                        Comments = s.Comments,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Rating = s.Rating ?? 0,
                        EntryDate = (DateTimeOffset)s.EntryDate
                    }).ToList();

                PaginationModel pagination = new PaginationModel();
                pagination.CurrentPage = reviews.Pagination.CurrentPage ?? 0;
                pagination.PageCount = reviews.Pagination.TotalPages ?? 0;
                pagination.PageSize = reviews.Pagination.PageSize ?? 0;
                pagination.TotalCount = reviews.Pagination.TotalCount ?? 0;

                productReviewModelList.Pagination = pagination;
                productReviewModelList.Average = reviews.Average ?? 0;
                return productReviewModelList;
            }
        }

        public static Double GetProductReviewAverage(String code)
        {
            using (var client = new LandauPortalWebAPI())
            {
                var reviews = client.ProductReviews.GetAllByProduct(code, 1, 1);

                return reviews.Average ?? 0;
            }
        }


        private static ColorsAndSizesModel GetColorsAndSizes(String code, String color, LandauPortalWebAPI client)
        {
            var result = new ColorsAndSizesModel();

            var sizes = client.Products.GetAllSizeByProduct(code).Results;
            result.ProductCategorySizes = sizes.OrderBy(o => o.SortOrder).Select(s => s.SizeCategory).Distinct().ToList();

            result.Sizes = GetSizesByColorAndSizeCategory(code, color, result.ProductCategorySizes.Count > 0 ? result.ProductCategorySizes[0] : "", client);

            result.AvailableColorsPerSizeCategory = new Dictionary<string, List<ProductColorModel>>();
           
            foreach (var aSizeCategory in result.ProductCategorySizes)
            {
                var colors = client.Products.GetAllColorByProductAndSizeCategory(code, aSizeCategory).Results.Select(c => new ProductColorModel() 
                { 
                    ColorCode = c.ColorCode, 
                    ColorName = c.ColorName,
                    PrimaryHex = c.PrimaryHex,
                    SecondaryHex = c.SecondaryHex,
                    SwatchType = c.SwatchType,
                    ColorImageUrl = c.PrintImageUri
                }).ToList();
                result.AvailableColorsPerSizeCategory.Add(aSizeCategory, colors);                
            }

            return result;
        }

    }
}