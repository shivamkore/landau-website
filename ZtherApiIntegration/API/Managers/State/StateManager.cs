using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZtherApiIntegration.Models;


namespace ZtherApiIntegration.API.Managers.State
{
    public class StateManager
    {
        public static List<StateModel> GetStateModelList()
        {
            using (var client = new LandauPortalWebAPI()) 
            {
                var obs = client.States.GetAll();
                return obs.Results.Select(s => new StateModel() { Abbrev = s.Abbrev, Name = s.Name }).ToList();
            }
        }
    }

}