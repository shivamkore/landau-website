using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZtherApiIntegration.Common
{
    public class Constants
    {
        public static string MEN_GENDER = "male";
        public static string WOMEN_GENDER = "female";

        public static string IMAGE_NOT_FOUND = "/public/images/catalog/not_found.jpg";

        public static string GenderFilterFor(string gender)
        {
            return gender.Trim().ToLower() == "men" ? Constants.MEN_GENDER : Constants.WOMEN_GENDER;
        }

        public static string GenderFor(string filter)
        {
            return filter.Trim().ToLower() == Constants.MEN_GENDER ? "Men" : "Women";
        }

    }
}