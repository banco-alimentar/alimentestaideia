/*
 * Easypay Payments API
 *
 * <a href='https://www.easypay.pt/en/legal-terms-and-conditions/' class='item'>Terms conditions and legal terms</a><br><a href='https://www.easypay.pt/en/privacy-and-data-protection-policy/' class='item'>Privacy Policy</a>
 *
 * The version of the OpenAPI document: 2.0
 * Contact: tec@easypay.pt
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using Easypay.Rest.Client.Client;
using Easypay.Rest.Client.Model;

namespace Easypay.Rest.Client.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ICheckoutApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Cancels a checkout
        /// </summary>
        /// <remarks>
        /// This cancels the Checkout and deletes the payment associated with it if possible.
        /// </remarks>
        /// <exception cref="Easypay.Rest.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Resource Identification</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void CheckoutIdDelete(Guid id, int operationIndex = 0);

        /// <summary>
        /// Cancels a checkout
        /// </summary>
        /// <remarks>
        /// This cancels the Checkout and deletes the payment associated with it if possible.
        /// </remarks>
        /// <exception cref="Easypay.Rest.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Resource Identification</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> CheckoutIdDeleteWithHttpInfo(Guid id, int operationIndex = 0);
        /// <summary>
        /// Shows checkout details
        /// </summary>
        /// <exception cref="Easypay.Rest.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Resource Identification</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>CheckoutDetails</returns>
        CheckoutDetails CheckoutIdGet(Guid id, int operationIndex = 0);

        /// <summary>
        /// Shows checkout details
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Easypay.Rest.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Resource Identification</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of CheckoutDetails</returns>
        ApiResponse<CheckoutDetails> CheckoutIdGetWithHttpInfo(Guid id, int operationIndex = 0);
        /// <summary>
        /// Create Checkout
        /// </summary>
        /// <remarks>
        /// Creates a Checkout Session.
        /// </remarks>
        /// <exception cref="Easypay.Rest.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="checkoutPostRequest">Checkout request details</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>CheckoutPost201Response</returns>
        CheckoutPost201Response CheckoutPost(CheckoutPostRequest checkoutPostRequest, int operationIndex = 0);

        /// <summary>
        /// Create Checkout
        /// </summary>
        /// <remarks>
        /// Creates a Checkout Session.
        /// </remarks>
        /// <exception cref="Easypay.Rest.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="checkoutPostRequest">Checkout request details</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of CheckoutPost201Response</returns>
        ApiResponse<CheckoutPost201Response> CheckoutPostWithHttpInfo(CheckoutPostRequest checkoutPostRequest, int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ICheckoutApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Cancels a checkout
        /// </summary>
        /// <remarks>
        /// This cancels the Checkout and deletes the payment associated with it if possible.
        /// </remarks>
        /// <exception cref="Easypay.Rest.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Resource Identification</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task CheckoutIdDeleteAsync(Guid id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Cancels a checkout
        /// </summary>
        /// <remarks>
        /// This cancels the Checkout and deletes the payment associated with it if possible.
        /// </remarks>
        /// <exception cref="Easypay.Rest.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Resource Identification</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> CheckoutIdDeleteWithHttpInfoAsync(Guid id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        /// <summary>
        /// Shows checkout details
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Easypay.Rest.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Resource Identification</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CheckoutDetails</returns>
        System.Threading.Tasks.Task<CheckoutDetails> CheckoutIdGetAsync(Guid id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Shows checkout details
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Easypay.Rest.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Resource Identification</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CheckoutDetails)</returns>
        System.Threading.Tasks.Task<ApiResponse<CheckoutDetails>> CheckoutIdGetWithHttpInfoAsync(Guid id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        /// <summary>
        /// Create Checkout
        /// </summary>
        /// <remarks>
        /// Creates a Checkout Session.
        /// </remarks>
        /// <exception cref="Easypay.Rest.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="checkoutPostRequest">Checkout request details</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CheckoutPost201Response</returns>
        System.Threading.Tasks.Task<CheckoutPost201Response> CheckoutPostAsync(CheckoutPostRequest checkoutPostRequest, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Create Checkout
        /// </summary>
        /// <remarks>
        /// Creates a Checkout Session.
        /// </remarks>
        /// <exception cref="Easypay.Rest.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="checkoutPostRequest">Checkout request details</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CheckoutPost201Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<CheckoutPost201Response>> CheckoutPostWithHttpInfoAsync(CheckoutPostRequest checkoutPostRequest, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ICheckoutApi : ICheckoutApiSync, ICheckoutApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class CheckoutApi : ICheckoutApi
    {
        private Easypay.Rest.Client.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CheckoutApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CheckoutApi(string basePath)
        {
            this.Configuration = Easypay.Rest.Client.Client.Configuration.MergeConfigurations(
                Easypay.Rest.Client.Client.GlobalConfiguration.Instance,
                new Easypay.Rest.Client.Client.Configuration { BasePath = basePath }
            );
            this.Client = new Easypay.Rest.Client.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Easypay.Rest.Client.Client.ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = Easypay.Rest.Client.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public CheckoutApi(Easypay.Rest.Client.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = Easypay.Rest.Client.Client.Configuration.MergeConfigurations(
                Easypay.Rest.Client.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.Client = new Easypay.Rest.Client.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Easypay.Rest.Client.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = Easypay.Rest.Client.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public CheckoutApi(Easypay.Rest.Client.Client.ISynchronousClient client, Easypay.Rest.Client.Client.IAsynchronousClient asyncClient, Easypay.Rest.Client.Client.IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = Easypay.Rest.Client.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public Easypay.Rest.Client.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public Easypay.Rest.Client.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Easypay.Rest.Client.Client.IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public Easypay.Rest.Client.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Cancels a checkout This cancels the Checkout and deletes the payment associated with it if possible.
        /// </summary>
        /// <exception cref="Easypay.Rest.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Resource Identification</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void CheckoutIdDelete(Guid id, int operationIndex = 0)
        {
            CheckoutIdDeleteWithHttpInfo(id);
        }

        /// <summary>
        /// Cancels a checkout This cancels the Checkout and deletes the payment associated with it if possible.
        /// </summary>
        /// <exception cref="Easypay.Rest.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Resource Identification</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Easypay.Rest.Client.Client.ApiResponse<Object> CheckoutIdDeleteWithHttpInfo(Guid id, int operationIndex = 0)
        {
            Easypay.Rest.Client.Client.RequestOptions localVarRequestOptions = new Easypay.Rest.Client.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json",
                "application/xml"
            };

            var localVarContentType = Easypay.Rest.Client.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Easypay.Rest.Client.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", Easypay.Rest.Client.Client.ClientUtils.ParameterToString(id)); // path parameter

            localVarRequestOptions.Operation = "CheckoutApi.CheckoutIdDelete";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (accountId) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("AccountId")))
            {
                localVarRequestOptions.HeaderParameters.Add("AccountId", this.Configuration.GetApiKeyWithPrefix("AccountId"));
            }
            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("ApiKey")))
            {
                localVarRequestOptions.HeaderParameters.Add("ApiKey", this.Configuration.GetApiKeyWithPrefix("ApiKey"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/checkout/{id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CheckoutIdDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Cancels a checkout This cancels the Checkout and deletes the payment associated with it if possible.
        /// </summary>
        /// <exception cref="Easypay.Rest.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Resource Identification</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task CheckoutIdDeleteAsync(Guid id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            await CheckoutIdDeleteWithHttpInfoAsync(id, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Cancels a checkout This cancels the Checkout and deletes the payment associated with it if possible.
        /// </summary>
        /// <exception cref="Easypay.Rest.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Resource Identification</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Easypay.Rest.Client.Client.ApiResponse<Object>> CheckoutIdDeleteWithHttpInfoAsync(Guid id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {

            Easypay.Rest.Client.Client.RequestOptions localVarRequestOptions = new Easypay.Rest.Client.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json",
                "application/xml"
            };

            var localVarContentType = Easypay.Rest.Client.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Easypay.Rest.Client.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", Easypay.Rest.Client.Client.ClientUtils.ParameterToString(id)); // path parameter

            localVarRequestOptions.Operation = "CheckoutApi.CheckoutIdDelete";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (accountId) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("AccountId")))
            {
                localVarRequestOptions.HeaderParameters.Add("AccountId", this.Configuration.GetApiKeyWithPrefix("AccountId"));
            }
            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("ApiKey")))
            {
                localVarRequestOptions.HeaderParameters.Add("ApiKey", this.Configuration.GetApiKeyWithPrefix("ApiKey"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/checkout/{id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CheckoutIdDelete", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Shows checkout details 
        /// </summary>
        /// <exception cref="Easypay.Rest.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Resource Identification</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>CheckoutDetails</returns>
        public CheckoutDetails CheckoutIdGet(Guid id, int operationIndex = 0)
        {
            Easypay.Rest.Client.Client.ApiResponse<CheckoutDetails> localVarResponse = CheckoutIdGetWithHttpInfo(id);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Shows checkout details 
        /// </summary>
        /// <exception cref="Easypay.Rest.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Resource Identification</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of CheckoutDetails</returns>
        public Easypay.Rest.Client.Client.ApiResponse<CheckoutDetails> CheckoutIdGetWithHttpInfo(Guid id, int operationIndex = 0)
        {
            Easypay.Rest.Client.Client.RequestOptions localVarRequestOptions = new Easypay.Rest.Client.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json",
                "application/xml"
            };

            var localVarContentType = Easypay.Rest.Client.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Easypay.Rest.Client.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", Easypay.Rest.Client.Client.ClientUtils.ParameterToString(id)); // path parameter

            localVarRequestOptions.Operation = "CheckoutApi.CheckoutIdGet";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (accountId) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("AccountId")))
            {
                localVarRequestOptions.HeaderParameters.Add("AccountId", this.Configuration.GetApiKeyWithPrefix("AccountId"));
            }
            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("ApiKey")))
            {
                localVarRequestOptions.HeaderParameters.Add("ApiKey", this.Configuration.GetApiKeyWithPrefix("ApiKey"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<CheckoutDetails>("/checkout/{id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CheckoutIdGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Shows checkout details 
        /// </summary>
        /// <exception cref="Easypay.Rest.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Resource Identification</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CheckoutDetails</returns>
        public async System.Threading.Tasks.Task<CheckoutDetails> CheckoutIdGetAsync(Guid id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            Easypay.Rest.Client.Client.ApiResponse<CheckoutDetails> localVarResponse = await CheckoutIdGetWithHttpInfoAsync(id, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Shows checkout details 
        /// </summary>
        /// <exception cref="Easypay.Rest.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Resource Identification</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CheckoutDetails)</returns>
        public async System.Threading.Tasks.Task<Easypay.Rest.Client.Client.ApiResponse<CheckoutDetails>> CheckoutIdGetWithHttpInfoAsync(Guid id, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {

            Easypay.Rest.Client.Client.RequestOptions localVarRequestOptions = new Easypay.Rest.Client.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json",
                "application/xml"
            };

            var localVarContentType = Easypay.Rest.Client.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Easypay.Rest.Client.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", Easypay.Rest.Client.Client.ClientUtils.ParameterToString(id)); // path parameter

            localVarRequestOptions.Operation = "CheckoutApi.CheckoutIdGet";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (accountId) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("AccountId")))
            {
                localVarRequestOptions.HeaderParameters.Add("AccountId", this.Configuration.GetApiKeyWithPrefix("AccountId"));
            }
            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("ApiKey")))
            {
                localVarRequestOptions.HeaderParameters.Add("ApiKey", this.Configuration.GetApiKeyWithPrefix("ApiKey"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<CheckoutDetails>("/checkout/{id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CheckoutIdGet", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create Checkout Creates a Checkout Session.
        /// </summary>
        /// <exception cref="Easypay.Rest.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="checkoutPostRequest">Checkout request details</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>CheckoutPost201Response</returns>
        public CheckoutPost201Response CheckoutPost(CheckoutPostRequest checkoutPostRequest, int operationIndex = 0)
        {
            Easypay.Rest.Client.Client.ApiResponse<CheckoutPost201Response> localVarResponse = CheckoutPostWithHttpInfo(checkoutPostRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create Checkout Creates a Checkout Session.
        /// </summary>
        /// <exception cref="Easypay.Rest.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="checkoutPostRequest">Checkout request details</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of CheckoutPost201Response</returns>
        public Easypay.Rest.Client.Client.ApiResponse<CheckoutPost201Response> CheckoutPostWithHttpInfo(CheckoutPostRequest checkoutPostRequest, int operationIndex = 0)
        {
            // verify the required parameter 'checkoutPostRequest' is set
            if (checkoutPostRequest == null)
            {
                throw new Easypay.Rest.Client.Client.ApiException(400, "Missing required parameter 'checkoutPostRequest' when calling CheckoutApi->CheckoutPost");
            }

            Easypay.Rest.Client.Client.RequestOptions localVarRequestOptions = new Easypay.Rest.Client.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json",
                "application/xml"
            };

            var localVarContentType = Easypay.Rest.Client.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Easypay.Rest.Client.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.Data = checkoutPostRequest;

            localVarRequestOptions.Operation = "CheckoutApi.CheckoutPost";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (accountId) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("AccountId")))
            {
                localVarRequestOptions.HeaderParameters.Add("AccountId", this.Configuration.GetApiKeyWithPrefix("AccountId"));
            }
            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("ApiKey")))
            {
                localVarRequestOptions.HeaderParameters.Add("ApiKey", this.Configuration.GetApiKeyWithPrefix("ApiKey"));
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<CheckoutPost201Response>("/checkout", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CheckoutPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create Checkout Creates a Checkout Session.
        /// </summary>
        /// <exception cref="Easypay.Rest.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="checkoutPostRequest">Checkout request details</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CheckoutPost201Response</returns>
        public async System.Threading.Tasks.Task<CheckoutPost201Response> CheckoutPostAsync(CheckoutPostRequest checkoutPostRequest, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            Easypay.Rest.Client.Client.ApiResponse<CheckoutPost201Response> localVarResponse = await CheckoutPostWithHttpInfoAsync(checkoutPostRequest, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create Checkout Creates a Checkout Session.
        /// </summary>
        /// <exception cref="Easypay.Rest.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="checkoutPostRequest">Checkout request details</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CheckoutPost201Response)</returns>
        public async System.Threading.Tasks.Task<Easypay.Rest.Client.Client.ApiResponse<CheckoutPost201Response>> CheckoutPostWithHttpInfoAsync(CheckoutPostRequest checkoutPostRequest, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            // verify the required parameter 'checkoutPostRequest' is set
            if (checkoutPostRequest == null)
            {
                throw new Easypay.Rest.Client.Client.ApiException(400, "Missing required parameter 'checkoutPostRequest' when calling CheckoutApi->CheckoutPost");
            }


            Easypay.Rest.Client.Client.RequestOptions localVarRequestOptions = new Easypay.Rest.Client.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json",
                "application/xml"
            };

            var localVarContentType = Easypay.Rest.Client.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Easypay.Rest.Client.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.Data = checkoutPostRequest;

            localVarRequestOptions.Operation = "CheckoutApi.CheckoutPost";
            localVarRequestOptions.OperationIndex = operationIndex;

            // authentication (accountId) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("AccountId")))
            {
                localVarRequestOptions.HeaderParameters.Add("AccountId", this.Configuration.GetApiKeyWithPrefix("AccountId"));
            }
            // authentication (apiKey) required
            if (!string.IsNullOrEmpty(this.Configuration.GetApiKeyWithPrefix("ApiKey")))
            {
                localVarRequestOptions.HeaderParameters.Add("ApiKey", this.Configuration.GetApiKeyWithPrefix("ApiKey"));
            }

            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<CheckoutPost201Response>("/checkout", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CheckoutPost", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
