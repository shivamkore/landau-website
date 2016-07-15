using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZtherApiIntegration.Models.Catalog
{
    public class FilterDisplayModel
    {
        public bool DisplaySizeFilter { get; set; }
        public bool DisplayColorFilter { get; set; }
        public bool DisplayFitFilter { get; set; }
        public bool DisplaySort { get; set; }

        public FilterDisplayModel()
        {
            this.DisplayColorFilter = true;
            this.DisplayFitFilter = true;
            this.DisplaySizeFilter = true;
            this.DisplaySort = true;
        }
    }
}