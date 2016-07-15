using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZtherApiIntegration.Models
{
    public class DropDownModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public bool Selected { get; set; }

        public DropDownModel()
        {
            Selected = false;
        }

        public string EncodedValue
        {
            get
            {
                return Name.Replace("'", "");
            }
        }
    }
}