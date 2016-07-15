using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ZtherApiIntegration.Models.Groups
{
    public class InquiryModel
    {
        [Required(ErrorMessage = "Please Enter First Name")]
        public String FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Last Name")]
        public String LastName { get; set; }
        [Required(ErrorMessage = "Please Enter Company Name")]
        public String CompanyName { get; set; }
        public List<IndustryModel> IndustryList { get; set; }
        //[Required(ErrorMessage = "Please Enter Industry")]
        public IndustryModel Industry { get; set; }
        public List<StateModel> StateList { get; set; }
        public AddressModel Address { get; set; }
        [Required(ErrorMessage = "Please Enter Phone")]
        public String Phone { get; set; }
        public String Cell { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        public String Email { get; set; }
        public String Web { get; set; }

        public InquiryModel() 
        {
            this.Industry = new IndustryModel();
            this.Address = new AddressModel();
        }
    }
}