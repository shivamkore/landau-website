using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZtherApiIntegration.Models.Swatch
{
    public class SwatchProductModel
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string TypeDescription { get; set; }
        public string ImageUri { get; set; }
        public string ColorCode { get; set; }
    }
}