using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZtherApiIntegration.Models.Detail
{
    public class ColorsAndSizesModel
    {
        public List<string> ProductCategorySizes { get; set; }       
        public Dictionary<string, List<ProductColorModel>> AvailableColorsPerSizeCategory { get; set; }
        public List<ProductSizeModel> Sizes { get; set; }

        public ProductColorModel GetProductColorModel(string colorCode)
        {
            if (AvailableColorsPerSizeCategory == null || string.IsNullOrEmpty(colorCode))
                return null;

            foreach (var k in AvailableColorsPerSizeCategory.Keys)
            {
                ProductColorModel color = AvailableColorsPerSizeCategory[k].FirstOrDefault(o => o.ColorCode.ToUpper() == colorCode.ToUpper());
                if (color != null)
                {
                    return color;
                }
            }

            return null;
        }
    }
}