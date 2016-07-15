using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZtherApiIntegration.Models.Swatch
{
    public class SwatchListModel
    {
        public List<SwatchItemModel> NewList { get; set; }
        public List<SwatchItemModel> PopularList { get; set; }

        public SwatchListModel()
        {
            this.PopularList = new List<SwatchItemModel>();
            this.NewList = new List<SwatchItemModel>();
        }
    }
}