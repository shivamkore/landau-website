using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZtherApiIntegration.Models
{
    public class SignupModel
    {
        public string Brand { get; set; }
        public string Email { get; set; }
        public DateTimeOffset EntryDate { get; set; }

        
    }
}