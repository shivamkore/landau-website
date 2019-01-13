using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ZtherApiIntegration.Common;



namespace ZtherApiIntegration
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.LowercaseUrls = true;

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();
             
            routes.MapRoute(
                            "CatalogFit", // Route name
                            "{gender}/{type}/{selection}/{fit}", // URL with parameters
                            new { controller = "Catalog", action = "IndexFit" },
                            constraints: new { gender = "(women|men)", fit = string.Format("({0}|{1}|{2})", UrlBuilder.CATALOG_CLASSIC_FIT, UrlBuilder.CATALOG_MODERN_FIT, UrlBuilder.CATALOG_CONTEMPORARY_FIT ) }// Parameter defaults
                        );
            
            routes.Add(
                "ProductConfirmation", // Route name
                new ProductDetailSeoRoute("{gender}/{type}/{typeName}/review/{product}/success",
            new RouteValueDictionary(new { controller = "Review", action = "ReviewConfirmation" }),
            new MvcRouteHandler(),
            new RouteValueDictionary(new { gender = "(women|men)" }))); 
            
            routes.Add(
                "ProductReview", // Route name
                new ProductDetailSeoRoute("{gender}/{type}/{typeName}/review/{product}",
            new RouteValueDictionary(new { controller = "Review", action = "Index" }),
            new MvcRouteHandler(),
            new RouteValueDictionary(new { gender = "(women|men)" })));

            
            routes.Add(
                "ProductDetail", // Route name
                new ProductDetailSeoRoute("{gender}/{type}/{typeName}/{product}",
            new RouteValueDictionary(new { controller = "Detail", action = "Index" }),
            new MvcRouteHandler(),
            new RouteValueDictionary(new { gender = "(women|men)" })));
            
            routes.Add(
                "ProductDetailCanonical", // Route name
                new ProductDetailSeoRoute("{product}",
            new RouteValueDictionary(new { controller = "Detail", action = "Canonical" }),
            new MvcRouteHandler(),
            new RouteValueDictionary(new { product = "([a-zA-Z0-9]*)-([a-zA-Z0-9-]*)" })));

            
            routes.MapRoute(
                "Catalog", // Route name
                "{gender}/{type}/{selection}", // URL with parameters
                new { controller = "Catalog", action = "Index" },
                constraints: new { gender = "(women|men)" }// Parameter defaults
            );

            routes.MapRoute(
                "CatalogActions", // Route name
                "Catalog/ProductsFilter", // URL with parameters
                new { controller = "Catalog", action = "ProductsFilter" } // Parameter defaults
            );

            routes.MapRoute(
                "SearchActions", // Route name
                "Search/Paginate", // URL with parameters
                new { controller = "Search", action = "Paginate" } // Parameter defaults
            );

            routes.MapRoute(
                            "DetailChangeProductImage", // Route name
                            "Detail/ChangeProductImage", // URL with parameters
                            new { controller = "Detail", action = "ChangeProductImage" } // Parameter defaults
                        );

            routes.MapRoute(
                "Groups", // Route name
                "Groups", // URL with parameters
                new { controller = "Groups", action = "Index" } // Parameter defaults
            );

            routes.MapRoute(
                "GroupsThankYou", // Route name
                "validation-group", // URL with parameters
                new { controller = "Groups", action = "ThankYou" } // Parameter defaults
            );

            routes.MapRoute(
                          "Scholarship", // Route name
                          "Scholarship", // URL with parameters
                         new { controller = "Scholarship", action = "Index" } // Parameter defaults
                      );

             routes.MapRoute(
                "GroupsCreate", // Route name
                "GroupsCreate", // URL with parameters
                new { controller = "Groups", action = "Create" } // Parameter defaults
            );
            
            routes.MapRoute(
                "Policy", // Route name
                "PrivacyPolicy", // URL with parameters
                new { controller = "PrivacyPolicy", action = "Index" } // Parameter defaults
            );
            
            routes.MapRoute(
                "Collections", // Route name
                "Collections", // URL with parameters
                new { controller = "Collections", action = "Index" } // Parameter defaults
            );
            

            routes.MapRoute(
                "Prints", // Route name
                "Prints", // URL with parameters
                new { controller = "Prints", action = "Index" } // Parameter defaults
            );

            routes.MapRoute(
                "Solids", // Route name
                "Solids", // URL with parameters
                new { controller = "Solids", action = "Index" } // Parameter defaults
            );                        
            

            routes.MapRoute(
                "Signup", // Route name
                "Footer/SignUp", // URL with parameters
                new { controller = "Footer", action = "SignUp" } // Parameter defaults
            );

            routes.MapRoute(
                "SignupThankYou", // Route name
                "validation-email", // URL with parameters
                new { controller = "Footer", action = "ThankYou" } // Parameter defaults
            );

            routes.MapRoute(
                "WhereToBuy", // Route name
                "WhereToBuy", // URL with parameters
                new { controller = "WhereToBuy", action = "Index" } // Parameter defaults
            );

            routes.MapRoute(
                "WhereToBuyActions", // Route name
                "WhereToBuy/{action}", // URL with parameters
                new { controller = "WhereToBuy", action = "{action}" } // Parameter defaults
            );

            routes.MapRoute(
                "WhereToBuyWhereToBuyIntl", // Route name
                "where-to-buy-intl/{countryCode}", // URL with parameters
                new { controller = "WhereToBuy", action = "WhereToBuyIntl" } // Parameter defaults
            );

            routes.MapRoute(
                "Contact", // Route name
                "Contact", // URL with parameters
                new { controller = "Contact", action = "Index" } // Parameter defaults
            );
            
            routes.MapRoute(
                "About", // Route name
                "About", // URL with parameters
                new { controller = "About", action = "Index" } // Parameter defaults
            );

            routes.MapRoute(
                "MadeBetter", // Route name
                "MadeBetter", // URL with parameters
                new { controller = "MadeBetter", action = "Index" } // Parameter defaults
            );

            routes.MapRoute(
                "Faq", // Route name
                "Faq", // URL with parameters
                new { controller = "Faq", action = "Index" } // Parameter defaults
            );

            routes.MapRoute(
                "FitGuide", // Route name
                "FitGuide", // URL with parameters
                new { controller = "FitGuide", action = "Index" } // Parameter defaults
            );

            routes.MapRoute(
                "FitGuideTops", // Route name
                "FitGuideTops", // URL with parameters
                new { controller = "FitGuideTops", action = "Index" } // Parameter defaults
            );

            routes.MapRoute(
                "FitGuidePants", // Route name
                "FitGuidePants", // URL with parameters
                new { controller = "FitGuidePants", action = "Index" } // Parameter defaults
            );

            routes.MapRoute(
                "Header", // Route name
                "Header/RenderHeader", // URL with parameters
                new { controller = "Header", action = "RenderHeader" } // Parameter defaults
            ); 
                      

            routes.MapRoute(
            "DetailReviews", // Route name
            "Detail/ReviewsPagination", // URL with parameters
            new { controller = "Detail", action = "ReviewsPagination" } // Parameter defaults
            );

            routes.MapRoute(
                "Favorites", // Route name
                "Favorites", // URL with parameters
                new { controller = "Favorites", action = "Index" } // Parameter defaults
            );

            routes.MapRoute(
                "FavoritesAction", // Route name
                "Favorites/{action}", // URL with parameters
                new { controller = "Favorites", action = "{action}" } // Parameter defaults
            );

            routes.MapRoute(
                "News", // Route name
                "news", // URL with parameters
                new { controller = "News", action = "Index" } // Parameter defaults
            );

            routes.MapRoute(
                "Retail", // Route name
                "login", // URL with parameters
                new { controller = "RetailPartners", action = "Index" } // Parameter defaults
            );

            routes.MapRoute(
                "PrintsAction", // Route name
                "Prints/{action}", // URL with parameters
                new { controller = "Prints", action = "{action}" } // Parameter defaults
            );

            routes.MapRoute(
                "SolidsAction", // Route name
                "Solids/{action}", // URL with parameters
                new { controller = "Solids", action = "{action}" } // Parameter defaults
            );  

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Error",
                "Error404",
                new { controller = "Error", action = "Error404" }
            );

            routes.MapRoute(
                "NotFound",
                "{*url}",
                new { controller = "Error", action = "HTTP404" }
            );
        }
    }
}
