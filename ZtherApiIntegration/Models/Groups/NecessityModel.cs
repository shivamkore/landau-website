using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZtherApiIntegration.Models.Groups
{
    public class NecessityModel
    {
        public bool NeedCustomized {get; set;}
        public bool NeedEmbroidery {get; set;}
        public bool NeedLabCoats {get; set;}
        public bool NeedNonMedical {get; set;}
        public bool NeedPrintedTops {get; set;}
        public bool NeedScrubs { get; set; }
    }
}