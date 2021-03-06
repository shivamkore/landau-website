﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using Newtonsoft.Json.Linq;
using ZtherApiIntegration.API;
using ZtherApiIntegration.API.Models;

namespace ZtherApiIntegration.API
{
    internal partial class Swatches : IServiceOperations<LandauPortalWebAPI>, ISwatches
    {
        /// <summary>
        /// Initializes a new instance of the Swatches class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal Swatches(LandauPortalWebAPI client)
        {
            this._client = client;
        }
        
        private LandauPortalWebAPI _client;
        
        /// <summary>
        /// Gets a reference to the
        /// ZtherApiIntegration.API.LandauPortalWebAPI.
        /// </summary>
        public LandauPortalWebAPI Client
        {
            get { return this._client; }
        }
        
        /// <param name='brand'>
        /// Required.
        /// </param>
        /// <param name='sortby'>
        /// Optional.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<HttpOperationResponse<SwatchList>> GetAllPrintByBrandWithOperationResponseAsync(string brand, string sortby = null, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Validate
            if (brand == null)
            {
                throw new ArgumentNullException("brand");
            }
            
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("brand", brand);
                tracingParameters.Add("sortby", sortby);
                ServiceClientTracing.Enter(invocationId, this, "GetAllPrintByBrandAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/brands/";
            url = url + Uri.EscapeDataString(brand);
            url = url + "/prints";
            List<string> queryParameters = new List<string>();
            if (sortby != null)
            {
                queryParameters.Add("sortby=" + Uri.EscapeDataString(sortby));
            }
            if (queryParameters.Count > 0)
            {
                url = url + "?" + string.Join("&", queryParameters);
            }
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Get;
            httpRequest.RequestUri = new Uri(url);
            
            // Set Credentials
            if (this.Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (statusCode != HttpStatusCode.OK)
            {
                HttpOperationException<object> ex = new HttpOperationException<object>();
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                ex.Body = null;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            
            // Create Result
            HttpOperationResponse<SwatchList> result = new HttpOperationResponse<SwatchList>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            
            // Deserialize Response
            if (statusCode == HttpStatusCode.OK)
            {
                SwatchList resultModel = new SwatchList();
                JToken responseDoc = null;
                if (string.IsNullOrEmpty(responseContent) == false)
                {
                    responseDoc = JToken.Parse(responseContent);
                }
                if (responseDoc != null)
                {
                    resultModel.DeserializeJson(responseDoc);
                }
                result.Body = resultModel;
            }
            
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }
        
        /// <param name='brand'>
        /// Required.
        /// </param>
        /// <param name='sortby'>
        /// Optional.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<HttpOperationResponse<SwatchList>> GetAllSolidByBrandWithOperationResponseAsync(string brand, string sortby = null, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Validate
            if (brand == null)
            {
                throw new ArgumentNullException("brand");
            }
            
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("brand", brand);
                tracingParameters.Add("sortby", sortby);
                ServiceClientTracing.Enter(invocationId, this, "GetAllSolidByBrandAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/brands/";
            url = url + Uri.EscapeDataString(brand);
            url = url + "/solids";
            List<string> queryParameters = new List<string>();
            if (sortby != null)
            {
                queryParameters.Add("sortby=" + Uri.EscapeDataString(sortby));
            }
            if (queryParameters.Count > 0)
            {
                url = url + "?" + string.Join("&", queryParameters);
            }
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Get;
            httpRequest.RequestUri = new Uri(url);
            
            // Set Credentials
            if (this.Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (statusCode != HttpStatusCode.OK)
            {
                HttpOperationException<object> ex = new HttpOperationException<object>();
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                ex.Body = null;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            
            // Create Result
            HttpOperationResponse<SwatchList> result = new HttpOperationResponse<SwatchList>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            
            // Deserialize Response
            if (statusCode == HttpStatusCode.OK)
            {
                SwatchList resultModel = new SwatchList();
                JToken responseDoc = null;
                if (string.IsNullOrEmpty(responseContent) == false)
                {
                    responseDoc = JToken.Parse(responseContent);
                }
                if (responseDoc != null)
                {
                    resultModel.DeserializeJson(responseDoc);
                }
                result.Body = resultModel;
            }
            
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }
        
        /// <param name='brand'>
        /// Required.
        /// </param>
        /// <param name='color'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<HttpOperationResponse<ProductLineArtList>> GetPrintsByBrandAndColorWithOperationResponseAsync(string brand, string color, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Validate
            if (brand == null)
            {
                throw new ArgumentNullException("brand");
            }
            if (color == null)
            {
                throw new ArgumentNullException("color");
            }
            
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("brand", brand);
                tracingParameters.Add("color", color);
                ServiceClientTracing.Enter(invocationId, this, "GetPrintsByBrandAndColorAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/brands/";
            url = url + Uri.EscapeDataString(brand);
            url = url + "/prints/";
            url = url + Uri.EscapeDataString(color);
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Get;
            httpRequest.RequestUri = new Uri(url);
            
            // Set Credentials
            if (this.Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (statusCode != HttpStatusCode.OK)
            {
                HttpOperationException<object> ex = new HttpOperationException<object>();
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                ex.Body = null;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            
            // Create Result
            HttpOperationResponse<ProductLineArtList> result = new HttpOperationResponse<ProductLineArtList>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            
            // Deserialize Response
            if (statusCode == HttpStatusCode.OK)
            {
                ProductLineArtList resultModel = new ProductLineArtList();
                JToken responseDoc = null;
                if (string.IsNullOrEmpty(responseContent) == false)
                {
                    responseDoc = JToken.Parse(responseContent);
                }
                if (responseDoc != null)
                {
                    resultModel.DeserializeJson(responseDoc);
                }
                result.Body = resultModel;
            }
            
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }
        
        /// <param name='brand'>
        /// Required.
        /// </param>
        /// <param name='color'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<HttpOperationResponse<ProductLineArtList>> GetSolidsByBrandAndColorWithOperationResponseAsync(string brand, string color, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Validate
            if (brand == null)
            {
                throw new ArgumentNullException("brand");
            }
            if (color == null)
            {
                throw new ArgumentNullException("color");
            }
            
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("brand", brand);
                tracingParameters.Add("color", color);
                ServiceClientTracing.Enter(invocationId, this, "GetSolidsByBrandAndColorAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/brands/";
            url = url + Uri.EscapeDataString(brand);
            url = url + "/solids/";
            url = url + Uri.EscapeDataString(color);
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Get;
            httpRequest.RequestUri = new Uri(url);
            
            // Set Credentials
            if (this.Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }
            
            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (statusCode != HttpStatusCode.OK)
            {
                HttpOperationException<object> ex = new HttpOperationException<object>();
                ex.Request = httpRequest;
                ex.Response = httpResponse;
                ex.Body = null;
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }
            
            // Create Result
            HttpOperationResponse<ProductLineArtList> result = new HttpOperationResponse<ProductLineArtList>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            
            // Deserialize Response
            if (statusCode == HttpStatusCode.OK)
            {
                ProductLineArtList resultModel = new ProductLineArtList();
                JToken responseDoc = null;
                if (string.IsNullOrEmpty(responseContent) == false)
                {
                    responseDoc = JToken.Parse(responseContent);
                }
                if (responseDoc != null)
                {
                    resultModel.DeserializeJson(responseDoc);
                }
                result.Body = resultModel;
            }
            
            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }
    }
}
