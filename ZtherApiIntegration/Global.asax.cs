using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ZtherApiIntegration
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //BundleTable.EnableOptimizations = true;
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();

            //Log Error Here - removed for brevity
            if (exception != null && exception is HttpException)
            {
                HttpException httpException = exception as HttpException;
                RouteData routeData = new RouteData();
                IController errorController = new Controllers.ErrorController();
                routeData.Values.Add("controller", "Error");
                routeData.Values.Add("area", "");
                routeData.Values.Add("ex", exception);

                if (httpException != null)
                {
                    switch (httpException.GetHttpCode())
                    {
                        case 404:
                            Response.Clear();
                            routeData.Values.Add("action", "PageNotFound");
                            Server.ClearError();
                            errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
                            break;
                        case 400:
                            Response.Clear();
                            routeData.Values.Add("action", "BadRequest");
                            Server.ClearError();
                            errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
                            break;
                        default:
                            Response.Clear();
                            routeData.Values.Add("action", "ServerError");
                            Server.ClearError();
                            errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
                            break;
                    }
                }
                //All other exceptions should result in a 500 error as they are issues with unhandled exceptions in the code
                else
                {
                    routeData.Values.Add("action", "ServerError");
                    Server.ClearError();
                    // Call the controller with the route
                    errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
                }
            }
        }
    }
}
