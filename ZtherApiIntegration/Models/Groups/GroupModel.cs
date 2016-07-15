using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZtherApiIntegration.Models.Groups
{
    public class GroupModel
    {
        public string Brand { get; set; }
        public InquiryModel Inquiry { get; set; }
        public PurchaseModel Purchase { get; set; }
        public NecessityModel Necessity { get; set; }
        public string Comments { get; set; }

        public GroupModel() 
        {
            this.Inquiry = new InquiryModel();
            this.Purchase = new PurchaseModel();
            this.Necessity = new NecessityModel();
        }
    }
}