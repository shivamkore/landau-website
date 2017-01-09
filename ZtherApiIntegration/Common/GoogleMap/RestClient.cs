using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace ZtherApiIntegration.Common.GoogleMap
{
    public class RestClient
    {
        public async Task<string> GetJsonAsync(string uriString)
        {
            var content = string.Empty;

            try
            {
                if (!string.IsNullOrWhiteSpace(uriString))
                {
                    HttpResponseMessage response = await this.GetHttpResponseMessageAsync(uriString, AcceptFormat.Json);

                    if (response != null)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            content = await response.Content.ReadAsStringAsync();
                        }
                    }
                }
            }
            catch
            {

            }

            return content;

        }

        public async Task<HttpStatusCode> GetHttpStatusCodeAsync(string uriString)
        {
            var statusCode = default(HttpStatusCode);

            if (!string.IsNullOrWhiteSpace(uriString))
            {
                HttpResponseMessage response = await this.GetHttpResponseMessageAsync(uriString);

                if (response != null)
                {
                    statusCode = response.StatusCode;
                }
            }

            return statusCode;
        }

        private async Task<HttpResponseMessage> GetHttpResponseMessageAsync(string uriString, AcceptFormat format = AcceptFormat.None)
        {
            var response = default(HttpResponseMessage);

            try
            {
                var requestUri = UriHelper.CreateUri(uriString);

                if (requestUri != null)
                {
                    using (var http = new HttpClient())
                    {
                        //http.BaseAddress = requestUri;
                        http.DefaultRequestHeaders.Accept.Clear();
                        if (format == AcceptFormat.Json)
                        {
                            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        }
                        else if (format == AcceptFormat.Xml)
                        {
                            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                        }

                        response = await http.GetAsync(requestUri);
                    }
                }
            }
            catch (Exception)
            { }

            return response;
        }
    }
}