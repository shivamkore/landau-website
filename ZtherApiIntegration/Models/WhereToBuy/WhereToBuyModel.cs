using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZtherApiIntegration.Models.WhereToBuy
{
    public class WhereToBuyModel
    {
        public List<CountryModel> Countries { get; set; }
        public RetailListModel RetailList { get; set; }
        public RetailListModel AllRetailList { get; set; }
        public RetailListModel DiamondList { get; set; }
        public string SearchByDesc { get; set; }
        public string SearchByValue { get; set; }

        public WhereToBuyModel()
        {
            this.Countries = new List<CountryModel>();
            this.RetailList = new RetailListModel();
            this.AllRetailList = new RetailListModel();
            this.DiamondList = new RetailListModel();
            this.SearchByDesc = string.Empty;
            this.SearchByValue = string.Empty;
        }
    }
}