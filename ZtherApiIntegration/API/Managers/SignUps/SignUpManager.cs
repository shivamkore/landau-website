using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZtherApiIntegration.API.Models;
using ZtherApiIntegration.Models;

namespace ZtherApiIntegration.API.Managers.SignUps
{
    public class SignUpManager
    {
        public static bool SignUp(SignupModel model)
        {
            using (var client = new LandauPortalWebAPI())
            {
                var signupModel = new SignUp(model.Brand, model.Email);
                signupModel.EntryDate = DateTime.Now;
                signupModel.LastName = string.Empty;
                signupModel.FirstName = string.Empty;
                signupModel.Phone = string.Empty;

                try
                {
                    client.SignUps.CreateSignUps(model.Brand, signupModel);
                    return true;
                }
                catch (Exception e) {

                    if (e is HttpOperationException)
                    {
                        var httpEx = (HttpOperationException)e;
                        return httpEx.Response.IsSuccessStatusCode;
                    }
                }
                return false;
            }
        }
    }
}