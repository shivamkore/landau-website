using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ZtherApiIntegration.Common
{
    public static class HttpClientHelper
    {
        public static async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            if (request == null)
                throw new NullReferenceException("The Http Request Message is null.");

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            var client = HttpClientSingleton.GetInstance.GetHttpClient;

            var response = await client.SendAsync(request)
                                .ConfigureAwait(false);

            return response;
        }
    }

    public sealed class HttpClientSingleton
    {
        private static readonly Lazy<HttpClientSingleton> _Instance = new Lazy<HttpClientSingleton>(() => new HttpClientSingleton());

        public readonly HttpClient GetHttpClient = new HttpClient();

        private HttpClientSingleton()
        {
            GetHttpClient.DefaultRequestHeaders.Clear();
            GetHttpClient.Timeout = TimeSpan.FromSeconds(100);
        }

        /// <summary>
        /// Get an instance of this class.
        /// </summary>
        public static HttpClientSingleton GetInstance
        {
            get
            {
                return _Instance.Value;
            }
        }
    }
}