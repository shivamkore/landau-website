using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ZtherApiIntegration.Models.Favorites
{
    public class FavoritesEmailModel
    {
        public String Brand { get; set; }
        public String FavCodes { get; set; }
        public List<String> FavProds { get; set; }

        [Required(ErrorMessage = "Please Enter Subject")]
        public String Subject { get; set; }

        [Required(ErrorMessage = "Please Enter Recipient's Name")]
        public String RecipientName { get; set; }

        [Required(ErrorMessage = "Please Enter Email Address of Recipient")]
        public String RecipientEmail { get; set; }

        [Required(ErrorMessage = "Please Enter Your Name")]
        public String FullName { get; set; }

        [Required(ErrorMessage = "Please Enter Message")]
        public String Message { get; set; }

        public FavoritesEmailModel()
        {
        }
    }
}