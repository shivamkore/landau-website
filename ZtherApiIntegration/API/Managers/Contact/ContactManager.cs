using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZtherApiIntegration.Models.Contact;
using ZtherApiIntegration.API.Models;
using Microsoft.Rest;

namespace ZtherApiIntegration.API.Managers.Contact
{
    public class ContactManager
    {
        public static bool Create(ContactModel contactModel)
        {
            using (var client = new LandauPortalWebAPI())
            {
                var contactUs = new ContactUs();

                contactUs.Address = new Address()
                {
                    City = contactModel.City,
                    State = contactModel.State,
                    Street1 = contactModel.Address,
                    Zipcode = contactModel.ZipCode
                };

                contactUs.Comments = contactModel.Comments;
                contactUs.Email = contactModel.Email;
                contactUs.FirstName = contactModel.FirstName;
                contactUs.LastName = contactModel.LastName;
                contactUs.Phone = contactModel.PhoneNumber;
                contactUs.Brand = contactModel.Brand;
                
                try
                {
                    client.ContactUs.CreateContactUs(contactUs.Brand, contactUs);
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
    }
}