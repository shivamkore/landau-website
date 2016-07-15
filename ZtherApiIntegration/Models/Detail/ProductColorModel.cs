using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZtherApiIntegration.Models.Detail
{
    public class ProductColorModel
    {
        public string ColorCode { get; set; }
        public String ColorName { get; set; }
        public String PrimaryHex { get; set; }
        public String SecondaryHex { get; set; }
        public String SwatchType { get; set; }
        public string ColorImageUrl { get; set; }
    }
}