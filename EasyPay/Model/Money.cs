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
    /// The money type is a data structure used to represent a monetary value in a specific currency. It includes both the amount and the currency type to accurately define the value of money in various contexts, such as financial transactions, pricing, and accounting.
    /// </summary>
    [DataContract(Name = "Money")]
    public partial class Money : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Money" /> class.
        /// </summary>
        /// <param name="amount">Represents the numerical value of the money. The amount should be a string formatted to include up to two decimal places to accurately represent cents or subunits of currency. For example, \&quot;123.45\&quot; represents one hundred twenty-three units and forty-five subunits of the currency..</param>
        /// <param name="currency">Indicates the type of currency associated with the amount. This should follow standard currency codes (ISO 4217), such as \&quot;USD\&quot; for US Dollar, \&quot;EUR\&quot; for Euro, or \&quot;JPY\&quot; for Japanese Yen, to specify which currency the amount is denominated in..</param>
        public Money(string amount = default(string), string currency = default(string))
        {
            this.Amount = amount;
            this.Currency = currency;
        }

        /// <summary>
        /// Represents the numerical value of the money. The amount should be a string formatted to include up to two decimal places to accurately represent cents or subunits of currency. For example, \&quot;123.45\&quot; represents one hundred twenty-three units and forty-five subunits of the currency.
        /// </summary>
        /// <value>Represents the numerical value of the money. The amount should be a string formatted to include up to two decimal places to accurately represent cents or subunits of currency. For example, \&quot;123.45\&quot; represents one hundred twenty-three units and forty-five subunits of the currency.</value>
        [DataMember(Name = "amount", EmitDefaultValue = false)]
        public string Amount { get; set; }

        /// <summary>
        /// Indicates the type of currency associated with the amount. This should follow standard currency codes (ISO 4217), such as \&quot;USD\&quot; for US Dollar, \&quot;EUR\&quot; for Euro, or \&quot;JPY\&quot; for Japanese Yen, to specify which currency the amount is denominated in.
        /// </summary>
        /// <value>Indicates the type of currency associated with the amount. This should follow standard currency codes (ISO 4217), such as \&quot;USD\&quot; for US Dollar, \&quot;EUR\&quot; for Euro, or \&quot;JPY\&quot; for Japanese Yen, to specify which currency the amount is denominated in.</value>
        [DataMember(Name = "currency", EmitDefaultValue = false)]
        public string Currency { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Money {\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  Currency: ").Append(Currency).Append("\n");
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
