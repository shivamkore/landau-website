using System;
using System.Net.Http;
using Microsoft.Azure.AppService;

namespace ZtherApiIntegration.API
{
    public static class LandauWebAPIAppServiceExtensions
    {
        public static LandauWebAPI CreateLandauWebAPI(this IAppServiceClient client)
        {
            return new LandauWebAPI(client.CreateHandler());
        }

        public static LandauWebAPI CreateLandauWebAPI(this IAppServiceClient client, params DelegatingHandler[] handlers)
        {
            return new LandauWebAPI(client.CreateHandler(handlers));
        }

        public static LandauWebAPI CreateLandauWebAPI(this IAppServiceClient client, Uri uri, params DelegatingHandler[] handlers)
        {
            return new LandauWebAPI(uri, client.CreateHandler(handlers));
        }

        public static LandauWebAPI CreateLandauWebAPI(this IAppServiceClient client, HttpClientHandler rootHandler, params DelegatingHandler[] handlers)
        {
            return new LandauWebAPI(rootHandler, client.CreateHandler(handlers));
        }
    }
}
