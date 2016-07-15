using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZtherApiIntegration.Models.Catalog
{
    public class SliderTextModel
    {
        public string Title { get; set; }
        public List<string> Descriptions { get; set; }

        public SliderTextModel()
        {
            this.Title = string.Empty;
            this.Descriptions = new List<string>();
        }

    }
}