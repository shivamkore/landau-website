using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZtherApiIntegration.Common;

namespace ZtherApiIntegration.Models
{
    public class ProductModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsNew { get; set; }
        public bool HasNewColors { get; set; }
        public string ColorCode { get; set; }

        private string _image;
        public string Image 
        {
            get
            {
                if (string.IsNullOrEmpty(_image))
                    return Constants.IMAGE_NOT_FOUND;
                return _image;
            } 
            set
            {
                _image = value;
            }
        }        
        
    }
}