using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ZtherApiIntegration.Models.Faq
{
    public class FaqModel
    {
        public string Brand { get; set; }

        [Required(ErrorMessage = "Please Enter First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter Phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Comments")]
        public string Comments { get; set; }

        public DateTimeOffset EntryDate { get; set; }

    }
}