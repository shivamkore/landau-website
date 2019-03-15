using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZtherApiIntegration.API.Models;
using ZtherApiIntegration.Models;
using ZtherApiIntegration.Models.Catalog;

namespace ZtherApiIntegration.API.Managers.Catalog
{
    public class ProductListFilter
    {
        public string Brand { get; set; }
        public bool ViewAll { get; set; }
        public int PageNumber { get; set; }
        public string Collection { get; set; }
        public string Gender { get; set; }
        public string Category { get; set; }
        public List<string> Fit { get; set; }
        public List<string> Size { get; set; }
        public string Sort { get; set; }
        public List<string> Color { get; set; }
        public string SearchKey { get; set; }
        public string IsNew { get; set; }
    }

    public class ProductSearchResult
    {
        public ProductListFilter Filter { get; set; }
        public ProductListModel Result { get; set; }
    }

    public class ProductsManager
    {
        private const int PAGE_SIZE = 16;
        private const string CATALOG_SEARCH_PRODS = "CatalogSearchProducts";

        public static ProductListModel GetProducts(HttpSessionStateBase session, ProductListFilter filter)
        {
            using (var client = new LandauPortalWebAPI())
            {
                var prods = client.Catalogs.GetProductsAsync(filter.Brand,
                    filter.Gender,                    
                    filter.Collection,
                    filter.Category,
                    filter.IsNew,
                    filter.Fit,
                    filter.Size,
                    filter.Color,
                    filter.Sort,
                    filter.PageNumber,
                    filter.ViewAll ? 999999 : new int?(PAGE_SIZE));

                var prdList = new ProductListModel();
                prdList.Products = prods.Results.Select(p => new ProductModel() { Code = p.ProductCode, Image = p.ImageUri, Name = p.ProductName, IsNew = p.IsNew ?? false, HasNewColors = p.HasNewColor ?? false }).ToList();
                prdList.Pagination.CurrentPage = prods.Pagination.CurrentPage ?? 0;
                prdList.Pagination.PageCount = prods.Pagination.TotalPages ?? 0;
                prdList.Pagination.PageSize = prods.Pagination.PageSize ?? 0;
                prdList.CatalogImage = prods.CatalogImageUri;

                if (prods.TextSlider != null)
                {
                    prdList.SliderText.Title = prods.TextSlider.Title;
                    prdList.SliderText.Descriptions = prods.TextSlider.Descriptions.OrderBy(o => o.SortOrder).Select(d => d.Description).ToList();
                }

                if (prods.Seo != null)
                {
                    prdList.Seo.PageDescription = prods.Seo.MetaDescription;
                    prdList.Seo.PageTitle = prods.Seo.PageTitle;
                }

                if (prods.Filters != null)
                {
                    var ftls = prods.Filters.Select(f => f.ToLower()).ToList();
                    prdList.FilterDisplay.DisplaySizeFilter = ftls.Contains("size");
                    prdList.FilterDisplay.DisplayColorFilter = ftls.Contains("color");
                    prdList.FilterDisplay.DisplaySort = ftls.Contains("sort by");
                    prdList.FilterDisplay.DisplayFitFilter = ftls.Contains("fit type");
                }
                
                var result = new ProductSearchResult() { Filter = filter, Result = prdList };

                session[CATALOG_SEARCH_PRODS] = result;

                return prdList;
            }
        }
        
        public static ProductModel NextProductCode(HttpSessionStateBase session, string currentCode)
        {
            var model = (ProductSearchResult)session[CATALOG_SEARCH_PRODS];

            if (model != null && model.Result.Products != null)
            {
                var index = model.Result.Products.FindIndex(p => p.Code == currentCode);

                if (index < model.Result.Products.Count - 1)
                    return model.Result.Products[index + 1];
                else if (model.Result.Pagination.CurrentPage < model.Result.Pagination.PageCount) 
                {
                    //if this is the last element of current pagination -> get next page
                    model.Filter.PageNumber++;
                    var prods = GetProducts(session, model.Filter);
                    
                    if (prods.Products.Count > 0)
                        return prods.Products[0];
                }
            }

            return null;
        }

        public static ProductModel PreviousProductCode(HttpSessionStateBase session, string currentCode)
        {
            var model = (ProductSearchResult)session[CATALOG_SEARCH_PRODS];

            if (model != null && model.Result.Products != null)
            {
                var index = model.Result.Products.FindIndex(p => p.Code == currentCode);

                if (index > 0)
                    return model.Result.Products[index - 1];
                else if (model.Result.Pagination.CurrentPage > 1)
                {
                    //if this is the first element of current pagination -> get previous page
                    model.Filter.PageNumber--;
                    var prods = GetProducts(session, model.Filter);

                    if (prods.Products.Count > 0)
                        return prods.Products[prods.Products.Count - 1];
                }
            }

            return null;
        }

        public static ProductListModel Search(ProductListFilter filter)
        {
            using (var client = new LandauPortalWebAPI())
            {
                var prods = client.Catalogs.Search(filter.Brand, filter.SearchKey, filter.ViewAll ? 1 : filter.PageNumber, filter.ViewAll ? int.MaxValue : PAGE_SIZE);
                var prdList = new ProductListModel();
                prdList.Products = prods.Results.Select(p => new ProductModel() { Code = p.ProductCode, Image = p.ImageUri, Name = p.ProductName }).ToList();
                prdList.Pagination.CurrentPage = prods.Pagination.CurrentPage ?? 0;
                prdList.Pagination.PageCount = prods.Pagination.TotalPages ?? 0;
                prdList.Pagination.PageSize = prods.Pagination.PageSize ?? 0;
                prdList.Pagination.TotalCount = prods.Pagination.TotalCount ?? 0;

                var result = new ProductSearchResult() { Filter = filter, Result = prdList };

                return prdList;
            }

        }
        public static Product FindProduct(string code)
        {
            using (var client = new LandauPortalWebAPI())
            {
                try
                {
                    var result = client.Products.GetByProduct(code);
                    return result;
                }
                catch(Exception)
                {
                    return null;
                }
            }
        }
    }
}