using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZtherApiIntegration.Models.Groups
{
    public class PurchaseModel
    {
        public string AreYouSellingToOther { get; set; }
        public bool AreYouTheDecisionMaker { get; set; }
        public string IfNotDecisionMakerWhoIs { get; set; }
        
        public List<OutfittedModel> OutfittedList { get; set; }
        public string NumberOfOutfitted { get; set; }

        public bool WhoWillWearNonMedical { get; set; }
        public bool WhoWillWearPatientCare { get; set; }

        public string WhichAreYouSeekingToOutfit { get; set; }

        public PurchaseModel() 
        {
            this.OutfittedList = new List<OutfittedModel>();
        }
    }
}