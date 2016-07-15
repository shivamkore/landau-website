using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using ZtherApiIntegration.Models;

namespace ZtherApiIntegration.Common
{
    public class Utility
    {        
        public static string RelativeDate(DateTime theDate)
        {
            Dictionary<long, string> thresholds = new Dictionary<long, string>();
            int minute = 60;
            int hour = 60 * minute;
            int day = 24 * hour;
            thresholds.Add(60, "{0} seconds ago");
            thresholds.Add(minute * 2, "a minute ago");
            thresholds.Add(45 * minute, "{0} minutes ago");
            thresholds.Add(120 * minute, "an hour ago");
            thresholds.Add(day, "{0} hours ago");
            thresholds.Add(day * 2, "yesterday");
            thresholds.Add(day * 30, "{0} days ago");
            thresholds.Add(day * 30 * 2, "{0} month ago");
            thresholds.Add(day * 365, "{0} months ago");
            thresholds.Add(day * 365 * 2, "{0} year ago");
            thresholds.Add(long.MaxValue, "{0} years ago");

            long since = (DateTime.Now.Ticks - theDate.Ticks) / 10000000;
            foreach (long threshold in thresholds.Keys)
            {
                if (since < threshold)
                {
                    TimeSpan t = new TimeSpan((DateTime.Now.Ticks - theDate.Ticks));
                    return string.Format(thresholds[threshold], (t.Days > 365 ? t.Days / 365 : (t.Days > 0 ? t.Days : (t.Hours > 0 ? t.Hours : (t.Minutes > 0 ? t.Minutes : (t.Seconds > 0 ? t.Seconds : 0))))).ToString());
                }
            }
            return "";
        }

        public static string ToDescription(Enum en) //ext method
        {
            if (en != null)
            {
                Type type = en.GetType();
                MemberInfo[] memInfo = type.GetMember(en.ToString());
                if (memInfo != null && memInfo.Length > 0)
                {
                    object[] attrs = memInfo[0].GetCustomAttributes(
                    typeof(DescriptionAttribute), false);

                    if (attrs != null && attrs.Length > 0)
                        return ((DescriptionAttribute)attrs[0]).Description;
                }
                return en.ToString();
            }

            return String.Empty;
        }

        public static string GetBreadcrumbCategory(DropDownModel category)
        {
            string value = string.Empty;
            if (category != null)
            {
                if (category.Value.ToLower().Equals(UrlBuilder.CATALOG_NEW_ARRIVALS))
                    value = "New Arrivals";
                else if (category.Value.ToLower().Equals(UrlBuilder.CATALOG_TOPS_NEW))
                    value = "Tops";
                else value = category.Value;
            }

            return value;


        }

        public static bool IsIE(HttpRequestBase request)
        {
            return request.Browser.Browser == "IE" || request.Browser.Browser == "InternetExplorer";
        }


        public static HttpException Exception404()
        {
            return new HttpException(404, "Url not found");
        }
    }
}