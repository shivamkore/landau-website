using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZtherApiIntegration.Models.Swatch;

namespace ZtherApiIntegration.API.Managers.Swatch
{
    public class SwatchManager
    {

        public static SwatchListModel Prints(string brand)
        {
            var result = new SwatchListModel();
            if(!string.IsNullOrEmpty(brand))
            {
                using (var client = new LandauPortalWebAPI())
                {
                    var prints = client.Swatches.GetAllPrintByBrand(brand);
                    result.NewList = prints.Results.Select(x =>
                            new SwatchItemModel()
                            {
                                Brand = x.Brand,
                                ColorCode = x.ColorCode,
                                ColorName = x.ColorName,
                                ImageURI = x.PrintImageUri,
                                IsNew = x.IsNew == null ? false : (bool)x.IsNew,
                                IsPopular = x.IsPopular == null ? false : (bool)x.IsPopular,
                                PrimaryHex = x.PrimaryHex,
                                SecondaryHex = x.SecondaryHex
                            }).Where(p => p.IsNew).ToList();

                    result.PopularList = prints.Results.Select(x => 
                            new SwatchItemModel() { 
                                Brand = x.Brand,
                                ColorCode = x.ColorCode,
                                ColorName = x.ColorName,
                                ImageURI = x.PrintImageUri,
                                IsNew = x.IsNew == null ? false : (bool)x.IsNew,
                                IsPopular = x.IsPopular == null ? false : (bool)x.IsPopular,
                                PrimaryHex = x.PrimaryHex,
                                SecondaryHex = x.SecondaryHex
                            }).Where(p => p.IsPopular).ToList();
                }
            }
            return result;
        }

        public static SwatchListModel Solids(string brand)
        {
            var result = new SwatchListModel();
            if (!string.IsNullOrEmpty(brand))
            {
                using (var client = new LandauPortalWebAPI())
                {
                    var solids = client.Swatches.GetAllSolidByBrand(brand);
                    result.NewList = solids.Results.Select(x =>
                            new SwatchItemModel()
                            {
                                Brand = x.Brand,
                                ColorCode = x.ColorCode,
                                ColorName = x.ColorName,
                                ImageURI = x.PrintImageUri,
                                IsNew = x.IsNew == null ? false : (bool)x.IsNew,
                                IsPopular = x.IsPopular == null ? false : (bool)x.IsPopular,
                                PrimaryHex = x.PrimaryHex,
                                SecondaryHex = x.SecondaryHex
                            }).Where(p => p.IsNew).ToList();

                    result.PopularList = solids.Results.Select(x =>
                            new SwatchItemModel()
                            {
                                Brand = x.Brand,
                                ColorCode = x.ColorCode,
                                ColorName = x.ColorName,
                                ImageURI = x.PrintImageUri,
                                IsNew = x.IsNew == null ? false : (bool)x.IsNew,
                                IsPopular = x.IsPopular == null ? false : (bool)x.IsPopular,
                                PrimaryHex = x.PrimaryHex,
                                SecondaryHex = x.SecondaryHex
                            }).Where(p => p.IsPopular).ToList();
                }
            }
            return result;
        }

        public static List<SwatchProductModel> PrintsProduct(string brand, string color)
        {
            var result = new List<SwatchProductModel>();
            if (!string.IsNullOrEmpty(color) && !string.IsNullOrEmpty(brand))
            {
                using (var client = new LandauPortalWebAPI())
                {
                    var products = client.Swatches.GetPrintsByBrandAndColor(brand, color);

                    result = products.Results.Select(x =>
                        new SwatchProductModel()
                        {
                            ProductCode = x.ProductCode,
                            ProductName = x.ProductName,
                            TypeDescription = x.ProductTypeDescription,
                            ImageUri = x.ImageUri,
                            ColorCode = color
                        }).ToList();
                }
            }
            return result;

        }

        public static List<SwatchProductModel> SolidsProduct(string brand, string color)
        {
            var result = new List<SwatchProductModel>();
            if (!string.IsNullOrEmpty(color) && !string.IsNullOrEmpty(brand))
            {
                using (var client = new LandauPortalWebAPI())
                {
                    var products = client.Swatches.GetSolidsByBrandAndColor(brand, color);

                    result = products.Results.Select(x =>
                        new SwatchProductModel()
                        {
                            ProductCode = x.ProductCode,
                            ProductName = x.ProductName,
                            TypeDescription = x.ProductTypeDescription,
                            ImageUri = x.ImageUri,
                            ColorCode = color
                        }).ToList();
                }
            }
            return result;
        }
    }
}