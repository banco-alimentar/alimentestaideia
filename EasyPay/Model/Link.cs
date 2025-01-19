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
    /// Link
    /// </summary>
    [DataContract(Name = "Link")]
    public partial class Link : IValidatableObject
    {

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public PayByLinkPaymentTypes? Type { get; set; }
        /// <summary>
        /// Defines CommunicationChannels
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum CommunicationChannelsEnum
        {
            /// <summary>
            /// Enum SMS for value: SMS
            /// </summary>
            [EnumMember(Value = "SMS")]
            SMS = 1,

            /// <summary>
            /// Enum EMAIL for value: EMAIL
            /// </summary>
            [EnumMember(Value = "EMAIL")]
            EMAIL = 2
        }


        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public Status? Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Link" /> class.
        /// </summary>
        /// <param name="expirationTime">expirationTime.</param>
        /// <param name="type">type.</param>
        /// <param name="customer">customer.</param>
        /// <param name="communicationChannels">the communication channels to where the final customer link should be forwarded.</param>
        /// <param name="payment">payment.</param>
        /// <param name="url">url.</param>
        /// <param name="image">image.</param>
        /// <param name="status">status.</param>
        public Link(DateTime expirationTime = default(DateTime), PayByLinkPaymentTypes? type = default(PayByLinkPaymentTypes?), PayByLinkCustomer customer = default(PayByLinkCustomer), Collection<CommunicationChannelsEnum> communicationChannels = default(Collection<CommunicationChannelsEnum>), LinkPayment payment = default(LinkPayment), string url = default(string), string image = default(string), Status? status = default(Status?))
        {
            this.ExpirationTime = expirationTime;
            this.Type = type;
            this.Customer = customer;
            this.CommunicationChannels = communicationChannels;
            this.Payment = payment;
            this.Url = url;
            this.Image = image;
            this.Status = status;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public Guid Id { get; private set; }

        /// <summary>
        /// Returns false as Id should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeId()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets ExpirationTime
        /// </summary>
        [DataMember(Name = "expiration_time", EmitDefaultValue = false)]
        public DateTime ExpirationTime { get; set; }

        /// <summary>
        /// Gets or Sets Customer
        /// </summary>
        [DataMember(Name = "customer", EmitDefaultValue = false)]
        public PayByLinkCustomer Customer { get; set; }

        /// <summary>
        /// the communication channels to where the final customer link should be forwarded
        /// </summary>
        /// <value>the communication channels to where the final customer link should be forwarded</value>
        [DataMember(Name = "communication_channels", EmitDefaultValue = false)]
        public Collection<Link.CommunicationChannelsEnum> CommunicationChannels { get; set; }

        /// <summary>
        /// Gets or Sets Payment
        /// </summary>
        [DataMember(Name = "payment", EmitDefaultValue = false)]
        public LinkPayment Payment { get; set; }

        /// <summary>
        /// Gets or Sets Url
        /// </summary>
        /*
        <example>https://easypay.pt/s/XStDvnMKZaN</example>
        */
        [DataMember(Name = "url", EmitDefaultValue = false)]
        public string Url { get; set; }

        /// <summary>
        /// Gets or Sets Image
        /// </summary>
        /*
        <example>https://cdn.easypay.pt/images/qr/XStDvnMKZaN</example>
        */
        [DataMember(Name = "image", EmitDefaultValue = false)]
        public string Image { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Link {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  ExpirationTime: ").Append(ExpirationTime).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Customer: ").Append(Customer).Append("\n");
            sb.Append("  CommunicationChannels: ").Append(CommunicationChannels).Append("\n");
            sb.Append("  Payment: ").Append(Payment).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  Image: ").Append(Image).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
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
