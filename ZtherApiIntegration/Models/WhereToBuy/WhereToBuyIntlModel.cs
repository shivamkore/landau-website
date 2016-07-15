using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZtherApiIntegration.Models.WhereToBuy
{
    public class WhereToBuyIntlModel
    {
        public List<CountryModel> Countries { get; set; }
        public RetailListModel RetailList { get; set; }
        public string SearchByDesc { get; set; }
        public string SearchByValue { get; set; }
        

        public WhereToBuyIntlModel()
        {
            this.Countries = new List<CountryModel>();
            this.RetailList = new RetailListModel();
            this.SearchByDesc = string.Empty;
            this.SearchByValue = string.Empty;
        }
    }
}