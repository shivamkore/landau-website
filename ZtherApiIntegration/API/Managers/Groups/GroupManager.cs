using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZtherApiIntegration.Models.Groups;
using ZtherApiIntegration.API.Models;
using Microsoft.Rest;

namespace ZtherApiIntegration.API.Managers.Groups
{
    public class GroupManager
    {

        public static List<IndustryModel> GetIndustryList(String brand)
        {
            using (var client = new LandauPortalWebAPI())
            {
                var obs = client.GroupOrders.GetAllIndustryByBrand(brand);
                List<IndustryModel> IndustryList = obs.Results.Select(s => new IndustryModel() { ID = (int)s.ID, Name = s.Name }).ToList();
                return IndustryList;
            }
        }

        public static List<OutfittedModel> GetOutfittedList(String brand)
        {
            using (var client = new LandauPortalWebAPI())
            {
                var obs = client.GroupOrders.GetAllNumberToBeOutfittedByBrand(brand);
                List<OutfittedModel> OutfittedModelList = obs.Results.Select(s => new OutfittedModel() { Key = s.Key, Value = s.Value }).ToList();
                return OutfittedModelList;
            }
        }

        public static bool Create(GroupModel groupModel)
        {
            using (var client = new LandauPortalWebAPI())
            {
                var groupOrder = new GroupOrder();
                
                //Group
                groupOrder.Brand = groupModel.Brand;
                //Group Inquiry
                setInquiry(groupOrder, groupModel);
                //Group Purchase
                setPurchase(groupOrder, groupModel);
                //Group Necessity
                setNecessity(groupOrder, groupModel);
                //Group
                groupOrder.Comments = groupModel.Comments;
                groupOrder.EntryDate = DateTime.Now;

                try
                {
                    String result = client.GroupOrders.Create(groupOrder.Brand, groupOrder);
                    return true;
                }
                catch (Exception e)
                {
                    if (e is HttpOperationException)
                    {
                        var httpEx = (HttpOperationException)e;
                        return httpEx.Response.IsSuccessStatusCode;
                    }
                }
                return false;
            }
        }

        private static void setInquiry(GroupOrder groupOrder, GroupModel groupModel) 
        {
            //Group Inquiry (required)
            groupOrder.FirstName = groupModel.Inquiry.FirstName;
            groupOrder.LastName = groupModel.Inquiry.LastName;
            groupOrder.CompanyName = groupModel.Inquiry.CompanyName;

            var industry = groupModel.Inquiry.IndustryList.Where(i => i.Name == groupModel.Inquiry.Industry.Name).FirstOrDefault();
            if (industry != null)
                groupOrder.Industry = new Industry() { Name = industry.Name, ID = industry.ID };            
            
            //Group Inquiry Address
            groupOrder.Address = new Address();
            groupOrder.Address.Street1 = groupModel.Inquiry.Address.Street1;
            if (groupModel.Inquiry.Address.Street2!=null) // (not required)
                groupOrder.Address.Street2 = groupModel.Inquiry.Address.Street2;
            groupOrder.Address.City = groupModel.Inquiry.Address.City;
            groupOrder.Address.State = groupModel.Inquiry.Address.State;
            groupOrder.Address.Zipcode = groupModel.Inquiry.Address.Zipcode;
            //Group Inquiry
            groupOrder.Phone = groupModel.Inquiry.Phone;
            if (groupModel.Inquiry.Cell != null) // (not required)
                groupOrder.Cell = groupModel.Inquiry.Cell;
            groupOrder.Email = groupModel.Inquiry.Email;
            if (groupModel.Inquiry.Web != null) // (not required)
                groupOrder.Web = groupModel.Inquiry.Web;
        }

        private static void setPurchase(GroupOrder groupOrder, GroupModel groupModel)
        {
            //Group Purchase (not required)
            if (groupModel.Purchase.AreYouSellingToOther!=null)
                groupOrder.AreYouSellingToOther = groupModel.Purchase.AreYouSellingToOther;

            groupOrder.AreYouTheDecisionMaker = groupModel.Purchase.AreYouTheDecisionMaker;

            if (groupModel.Purchase.IfNotDecisionMakerWhoIs!=null)
                groupOrder.IfNotDecisionMakerWhoIs = groupModel.Purchase.IfNotDecisionMakerWhoIs;

            if(groupModel.Purchase.NumberOfOutfitted!=null)
                groupOrder.NumberOfOutfitted = groupModel.Purchase.NumberOfOutfitted;
            
            groupOrder.WhoWillWearPatientCare = groupModel.Purchase.WhoWillWearPatientCare;
            groupOrder.WhoWillWearNonMedical = groupModel.Purchase.WhoWillWearNonMedical;
            
            if(groupModel.Purchase.WhichAreYouSeekingToOutfit!=null)
                groupOrder.WhichAreYouSeekingToOutfit = groupModel.Purchase.WhichAreYouSeekingToOutfit;
        }


        private static void setNecessity(GroupOrder groupOrder, GroupModel groupModel)
        {
            //Group Necessity
            groupOrder.NeedScrubs = groupModel.Necessity.NeedScrubs;
            groupOrder.NeedLabCoats = groupModel.Necessity.NeedLabCoats;
            groupOrder.NeedPrintedTops = groupModel.Necessity.NeedPrintedTops;
            groupOrder.NeedEmbroidery = groupModel.Necessity.NeedEmbroidery;
            groupOrder.NeedNonMedical = groupModel.Necessity.NeedNonMedical;
            groupOrder.NeedCustomized = groupModel.Necessity.NeedCustomized;
        }
    }
}