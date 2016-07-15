using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZtherApiIntegration.Models.Collections
{
    public class CollectionModel
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Gender { get; set; }        
        public List<ProductModel> Products { get; set; }
        public int Index { get; set; }
    }
}