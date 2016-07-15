using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZtherApiIntegration.Models.Contact;


namespace ZtherApiIntegration.API.Managers.Contact
{
    public class StateManager
    {
        public static List<StateModel> GetStateModelList()
        {
            using (var client = new LandauWebAPI()) 
            {
                var obs = client.States.GetAll();
                return obs.Results.Select(s => new StateModel() { Abbrev = s.Abbrev, Name = s.Name }).ToList();
            }
        }
    }

}