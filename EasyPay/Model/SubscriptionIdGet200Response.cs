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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = Easypay.Rest.Client.Client.OpenAPIDateConverter;

namespace Easypay.Rest.Client.Model
{
    /// <summary>
    /// SubscriptionIdGet200Response
    /// </summary>
    [DataContract(Name = "_subscription__id__get_200_response")]
    public partial class SubscriptionIdGet200Response : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionIdGet200Response" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="key">key.</param>
        /// <param name="expirationTime">expirationTime.</param>
        /// <param name="startTime">startTime.</param>
        /// <param name="frequency">frequency.</param>
        /// <param name="retries">retries.</param>
        /// <param name="maxCaptures">maxCaptures.</param>
        /// <param name="failover">failover.</param>
        /// <param name="captureNow">captureNow.</param>
        /// <param name="customer">customer.</param>
        /// <param name="method">method.</param>
        /// <param name="currency">currency.</param>
        /// <param name="value">value.</param>
        /// <param name="createdAt">Date when payment was created.</param>
        public SubscriptionIdGet200Response(Guid id = default(Guid), string key = default(string), string expirationTime = default(string), string startTime = default(string), string frequency = default(string), int retries = default(int), int maxCaptures = default(int), bool failover = default(bool), bool captureNow = default(bool), SubscriptionGet200ResponseDataInnerCustomer customer = default(SubscriptionGet200ResponseDataInnerCustomer), SubscriptionIdGet200ResponseMethod method = default(SubscriptionIdGet200ResponseMethod), string currency = default(string), decimal value = default(decimal), string createdAt = default(string))
        {
            this.Id = id;
            this.Key = key;
            this.ExpirationTime = expirationTime;
            this.StartTime = startTime;
            this.Frequency = frequency;
            this.Retries = retries;
            this.MaxCaptures = maxCaptures;
            this.Failover = failover;
            this.CaptureNow = captureNow;
            this.Customer = customer;
            this.Method = method;
            this.Currency = currency;
            this.Value = value;
            this.CreatedAt = createdAt;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or Sets Key
        /// </summary>
        [DataMember(Name = "key", EmitDefaultValue = false)]
        public string Key { get; set; }

        /// <summary>
        /// Gets or Sets ExpirationTime
        /// </summary>
        [DataMember(Name = "expiration_time", EmitDefaultValue = false)]
        public string ExpirationTime { get; set; }

        /// <summary>
        /// Gets or Sets StartTime
        /// </summary>
        [DataMember(Name = "start_time", EmitDefaultValue = false)]
        public string StartTime { get; set; }

        /// <summary>
        /// Gets or Sets Frequency
        /// </summary>
        [DataMember(Name = "frequency", EmitDefaultValue = false)]
        public string Frequency { get; set; }

        /// <summary>
        /// Gets or Sets Retries
        /// </summary>
        [DataMember(Name = "retries", EmitDefaultValue = false)]
        public int Retries { get; set; }

        /// <summary>
        /// Gets or Sets MaxCaptures
        /// </summary>
        [DataMember(Name = "max_captures", EmitDefaultValue = false)]
        public int MaxCaptures { get; set; }

        /// <summary>
        /// Gets or Sets Failover
        /// </summary>
        [DataMember(Name = "failover", EmitDefaultValue = true)]
        public bool Failover { get; set; }

        /// <summary>
        /// Gets or Sets CaptureNow
        /// </summary>
        [DataMember(Name = "capture_now", EmitDefaultValue = true)]
        public bool CaptureNow { get; set; }

        /// <summary>
        /// Gets or Sets Customer
        /// </summary>
        [DataMember(Name = "customer", EmitDefaultValue = false)]
        public SubscriptionGet200ResponseDataInnerCustomer Customer { get; set; }

        /// <summary>
        /// Gets or Sets Method
        /// </summary>
        [DataMember(Name = "method", EmitDefaultValue = false)]
        public SubscriptionIdGet200ResponseMethod Method { get; set; }

        /// <summary>
        /// Gets or Sets Currency
        /// </summary>
        [DataMember(Name = "currency", EmitDefaultValue = false)]
        public string Currency { get; set; }

        /// <summary>
        /// Gets or Sets Value
        /// </summary>
        [DataMember(Name = "value", EmitDefaultValue = false)]
        public decimal Value { get; set; }

        /// <summary>
        /// Date when payment was created
        /// </summary>
        /// <value>Date when payment was created</value>
        [DataMember(Name = "created_at", EmitDefaultValue = false)]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SubscriptionIdGet200Response {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Key: ").Append(Key).Append("\n");
            sb.Append("  ExpirationTime: ").Append(ExpirationTime).Append("\n");
            sb.Append("  StartTime: ").Append(StartTime).Append("\n");
            sb.Append("  Frequency: ").Append(Frequency).Append("\n");
            sb.Append("  Retries: ").Append(Retries).Append("\n");
            sb.Append("  MaxCaptures: ").Append(MaxCaptures).Append("\n");
            sb.Append("  Failover: ").Append(Failover).Append("\n");
            sb.Append("  CaptureNow: ").Append(CaptureNow).Append("\n");
            sb.Append("  Customer: ").Append(Customer).Append("\n");
            sb.Append("  Method: ").Append(Method).Append("\n");
            sb.Append("  Currency: ").Append(Currency).Append("\n");
            sb.Append("  Value: ").Append(Value).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
