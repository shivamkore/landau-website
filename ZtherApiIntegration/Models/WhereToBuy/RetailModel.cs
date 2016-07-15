using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZtherApiIntegration.Models.WhereToBuy
{
    public class RetailModel
    {
        public string StoreName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string imageUri { get; set; }
        public string LandauSiteUrl { get; set; }
        public string SmittenSiteUrl { get; set; }
        public string UrbaneSiteUrl { get; set; }

        public bool IsDiamond { get; set; }
        public double Distance { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}