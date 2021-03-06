﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BillingWebJob.Models;
using Microsoft.Rest;
using Newtonsoft.Json.Linq;
using System.Configuration;
using BillingWebJob.Helpers;
using System.Net.Http.Headers;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Globalization;

namespace BillingWebJob
{
    internal partial class CspBilling : IServiceOperations<AzureAnalyticsApi>, ICspBilling
    {
        /// <summary>
        /// Initializes a new instance of the CspBilling class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal CspBilling(AzureAnalyticsApi client)
        {
            int timeOut = int.Parse(ConfigurationManager.AppSettings["ApiResponseWaitTimeOutInMinutes"],
                CultureInfo.InvariantCulture);
            client.HttpClient.Timeout = TimeSpan.FromMinutes(timeOut);
            this._client = client;
        }

        private AzureAnalyticsApi _client;

        private AuthenticationResult authTokenObject = AuthenticationHelper.GetAuthenticationResult();

        /// <summary>
        /// Gets a reference to the BillingWebJob.AzureAnalyticsApi.
        /// </summary>
        public AzureAnalyticsApi Client
        {
            get { return this._client; }
        }

        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<HttpOperationResponse<IList<CspUsageLineItem>>> GetAllDataWithOperationResponseAsync(
            CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                ServiceClientTracing.Enter(invocationId, this, "GetAllDataAsync", tracingParameters);
            }

            // Construct URL
            string url = "";
            url = url + "/api/CspBilling";
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
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authTokenObject.AccessToken);

            // Set Credentials
            if (this.Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await
                    this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken)
                        .ConfigureAwait(false);
            }

            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse =
                await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
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
            HttpOperationResponse<IList<CspUsageLineItem>> result = new HttpOperationResponse<IList<CspUsageLineItem>>();
            result.Request = httpRequest;
            result.Response = httpResponse;

            // Deserialize Response
            if (statusCode == HttpStatusCode.OK)
            {
                IList<CspUsageLineItem> resultModel = new List<CspUsageLineItem>();
                JToken responseDoc = null;
                if (string.IsNullOrEmpty(responseContent) == false)
                {
                    responseDoc = JToken.Parse(responseContent);
                }
                if (responseDoc != null)
                {
                    resultModel = CspUsageLineItemCollection.DeserializeJson(responseDoc);
                }
                result.Body = resultModel;
            }

            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<HttpOperationResponse<IList<CspUsageLineItem>>> GetCurrentMonthDataWithOperationResponseAsync(
            CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                ServiceClientTracing.Enter(invocationId, this, "GetCurrentMonthDataAsync", tracingParameters);
            }

            // Construct URL
            string url = "";
            url = url + "/api/cspbilling/currentmonth";
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
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authTokenObject.AccessToken);

            // Set Credentials
            if (this.Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await
                    this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken)
                        .ConfigureAwait(false);
            }

            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse =
                await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
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
            HttpOperationResponse<IList<CspUsageLineItem>> result = new HttpOperationResponse<IList<CspUsageLineItem>>();
            result.Request = httpRequest;
            result.Response = httpResponse;

            // Deserialize Response
            if (statusCode == HttpStatusCode.OK)
            {
                IList<CspUsageLineItem> resultModel = new List<CspUsageLineItem>();
                JToken responseDoc = null;
                if (string.IsNullOrEmpty(responseContent) == false)
                {
                    responseDoc = JToken.Parse(responseContent);
                }
                if (responseDoc != null)
                {
                    resultModel = CspUsageLineItemCollection.DeserializeJson(responseDoc);
                }
                result.Body = resultModel;
            }

            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <param name='startMMYYYY'>
        /// Required.
        /// </param>
        /// <param name='endMMYYYY'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<HttpOperationResponse<IList<CspUsageLineItem>>> GetDataForMonthRangeWithOperationResponseAsync
        (string startMMYYYY, string endMMYYYY,
            CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Validate
            if (startMMYYYY == null)
            {
                throw new ArgumentNullException("startMMYYYY");
            }
            if (endMMYYYY == null)
            {
                throw new ArgumentNullException("endMMYYYY");
            }

            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("startMMYYYY", startMMYYYY);
                tracingParameters.Add("endMMYYYY", endMMYYYY);
                ServiceClientTracing.Enter(invocationId, this, "GetDataForMonthRangeAsync", tracingParameters);
            }

            // Construct URL
            string url = "";
            url = url + "/api/cspbilling/byMonthRange/";
            url = url + Uri.EscapeDataString(startMMYYYY);
            url = url + "/";
            url = url + Uri.EscapeDataString(endMMYYYY);
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
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authTokenObject.AccessToken);

            // Set Credentials
            if (this.Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await
                    this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken)
                        .ConfigureAwait(false);
            }

            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse =
                await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
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
            HttpOperationResponse<IList<CspUsageLineItem>> result = new HttpOperationResponse<IList<CspUsageLineItem>>();
            result.Request = httpRequest;
            result.Response = httpResponse;

            // Deserialize Response
            if (statusCode == HttpStatusCode.OK)
            {
                IList<CspUsageLineItem> resultModel = new List<CspUsageLineItem>();
                JToken responseDoc = null;
                if (string.IsNullOrEmpty(responseContent) == false)
                {
                    responseDoc = JToken.Parse(responseContent);
                }
                if (responseDoc != null)
                {
                    resultModel = CspUsageLineItemCollection.DeserializeJson(responseDoc);
                }
                result.Body = resultModel;
            }

            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <param name='mmyyyy'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<HttpOperationResponse<IList<CspUsageLineItem>>> GetSingleMonthDataWithOperationResponseAsync(
            string mmyyyy, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Validate
            if (mmyyyy == null)
            {
                throw new ArgumentNullException("mmyyyy");
            }

            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("mmyyyy", mmyyyy);
                ServiceClientTracing.Enter(invocationId, this, "GetSingleMonthDataAsync", tracingParameters);
            }

            // Construct URL
            string url = "";
            url = url + "/api/cspbilling/byMonth/";
            url = url + Uri.EscapeDataString(mmyyyy);
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
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authTokenObject.AccessToken);

            // Set Credentials
            if (this.Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await
                    this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken)
                        .ConfigureAwait(false);
            }

            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse =
                await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
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
            HttpOperationResponse<IList<CspUsageLineItem>> result = new HttpOperationResponse<IList<CspUsageLineItem>>();
            result.Request = httpRequest;
            result.Response = httpResponse;

            // Deserialize Response
            if (statusCode == HttpStatusCode.OK)
            {
                IList<CspUsageLineItem> resultModel = new List<CspUsageLineItem>();
                JToken responseDoc = null;
                if (string.IsNullOrEmpty(responseContent) == false)
                {
                    responseDoc = JToken.Parse(responseContent);
                }
                if (responseDoc != null)
                {
                    resultModel = CspUsageLineItemCollection.DeserializeJson(responseDoc);
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