using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZtherApiIntegration.Models
{
    public class PowerReviewModel
    {
        public string ProductCode { get; set; }
        public string API_Key { get; set; }
        public string Locale { get; set; }
        public string Merchant_Id { get; set; }
        public string Merchant_Group_Id { get; set; }
        public string Write_Review_URL { get; set; }
        public string StyleSheet { get; set; }
    }
}