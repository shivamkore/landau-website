using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ZtherApiIntegration.Models.Contact
{
    public class ContactModel
    {
        public List<StateModel> StateModelList { get; set; }

        public String Brand { get; set; }
        
        [Required(ErrorMessage = "Please Enter First Name")]
        public String FirstName { get; set; }
        
        [Required(ErrorMessage = "Please Enter Last Name")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "Please Enter Address")]
        public String Address { get; set; }
        
        [Required(ErrorMessage = "Please Enter City")]
        public String City { get; set; }
        
        //[Required(ErrorMessage = "Please Enter State")]
        public String State { get; set; }
        
        [Required(ErrorMessage = "Please Enter Zip Code")]
        public String ZipCode { get; set; }
        
        [Required(ErrorMessage = "Please Enter Email")]
        //[DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public String Email { get; set; }
        
        [Required(ErrorMessage = "Please Enter Phone Number")]
        public String PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "Please Enter Comments")]
        public String Comments { get; set; }

        public ContactModel(){
            this.StateModelList = new List<StateModel>();
        }
    }
}