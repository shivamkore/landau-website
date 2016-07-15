using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZtherApiIntegration.Models.Detail;
using System.ComponentModel.DataAnnotations;

namespace ZtherApiIntegration.Models.Review
{

    public class ReviewItemModel 
    {
        public String ProductCode { get; set; }
        public String ProductName { get; set; }
        public String ProductDescription { get; set; }
        public String ProductImage { get; set; }
        public Double Average { get; set; }
        public String Rating { get; set; }
        public DateTimeOffset EntryDate { get; set; }

        public String BreadCrumbAndProductId { get; set; } 

        [Required(ErrorMessage = "Please Enter Title")]
        //[StringLength(60, MinimumLength = 10)]
        public String Title { get; set; }

        [Required(ErrorMessage = "Please Enter Comments")]
        public String Comments { get; set; }
        
        [Required(ErrorMessage = "Please Enter Name")]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public String CommentatorName { get; set; }

        [Required(ErrorMessage = "Please Enter Location")]
        public String Location { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Please Enter Email Confirmation")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public String EmailConfirmation { get; set; }
    }
}