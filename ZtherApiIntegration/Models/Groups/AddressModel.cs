using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZtherApiIntegration.Models.Contact;
using System.ComponentModel.DataAnnotations;

namespace ZtherApiIntegration.Models.Groups
{
    public class AddressModel
    {
        [Required(ErrorMessage = "Please Enter Address")]
        public String Street1 { get; set; }
        public String Street2 { get; set; }
        [Required(ErrorMessage = "Please Enter City")]
        public String City { get; set; }
        //[Required(ErrorMessage = "Please Enter State")]        
        public String State { get; set; }
        [Required(ErrorMessage = "Please Enter Zip Code")]        
        public String Zipcode { get; set; }
    }
}