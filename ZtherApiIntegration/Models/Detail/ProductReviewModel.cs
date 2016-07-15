using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZtherApiIntegration.Models.Detail
{
    public class ProductReviewModel
    {
        public Double Average { get; set; }
        public String Comments { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }        
        public Int32 Rating { get; set; }
        public DateTimeOffset EntryDate { get; set; }


        public String FullName 
        { 
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}