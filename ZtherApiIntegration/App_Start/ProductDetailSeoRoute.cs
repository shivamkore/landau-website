using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Routing;

namespace ZtherApiIntegration
{
    public class ProductDetailSeoRoute : Route
    {
        public ProductDetailSeoRoute(string url, RouteValueDictionary defaults, IRouteHandler routeHandler)
            : base(url, defaults, routeHandler)
        {            
        }

        public ProductDetailSeoRoute(string url, RouteValueDictionary defaults, IRouteHandler routeHandler, RouteValueDictionary constraints)
            : base(url, defaults, routeHandler)
        {
            this.Constraints = constraints; 
        }

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var routeData = base.GetRouteData(httpContext);

            if (routeData != null)
            {
                if (routeData.Values.ContainsKey("product"))
                    routeData.Values["product"] = GetIdValue(routeData.Values["product"]);
            }

            
            return routeData;
        }

        private object GetIdValue(object id)
        {
            if (id != null)
            {
                string idValue = id.ToString();

                var splitted = id.ToString().Split('-');

                if (splitted.Length > 0)
                    return splitted[0];
            }

            return id;
        }
    }
}