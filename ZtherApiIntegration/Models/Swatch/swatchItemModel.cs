using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZtherApiIntegration.Models.Swatch
{
    public class SwatchItemModel
    {
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public string ImageURI { get; set; }
        public bool IsNew { get; set; }
        public bool IsPopular { get; set; }

        public string Brand { get; set; }
        //public string DisplayName { get; set; }
        public string PrimaryHex { get; set; }
        public string SecondaryHex { get; set; }

    }
}