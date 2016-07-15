using System;
using System.Net.Http;
using Microsoft.Azure.AppService;

namespace ZtherApiIntegration.API
{
    public static class LandauPortalWebAPIAppServiceExtensions
    {
        public static LandauPortalWebAPI CreateLandauPortalWebAPI(this IAppServiceClient client)
        {
            return new LandauPortalWebAPI(client.CreateHandler());
        }

        public static LandauPortalWebAPI CreateLandauPortalWebAPI(this IAppServiceClient client, params DelegatingHandler[] handlers)
        {
            return new LandauPortalWebAPI(client.CreateHandler(handlers));
        }

        public static LandauPortalWebAPI CreateLandauPortalWebAPI(this IAppServiceClient client, Uri uri, params DelegatingHandler[] handlers)
        {
            return new LandauPortalWebAPI(uri, client.CreateHandler(handlers));
        }

        public static LandauPortalWebAPI CreateLandauPortalWebAPI(this IAppServiceClient client, HttpClientHandler rootHandler, params DelegatingHandler[] handlers)
        {
            return new LandauPortalWebAPI(rootHandler, client.CreateHandler(handlers));
        }
    }
}
