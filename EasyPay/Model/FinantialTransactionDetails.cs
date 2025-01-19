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
    /// An object containing detailed financial information related to the transaction. Provides a breakdown of various components of the transaction, such as fees , requested and payed amounts.
    /// </summary>
    [DataContract(Name = "FinantialTransactionDetails")]
    public partial class FinantialTransactionDetails : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FinantialTransactionDetails" /> class.
        /// </summary>
        /// <param name="requestedAmount">The amount requested by payee..</param>
        /// <param name="payedAmount">The amount payed by payer..</param>
        /// <param name="fees">An array of fee objects, where each fee represents a specific charge or cost associated with a transaction.   Each fee includes details such as the amount and currency, and may represent different types of fees   like fixed, variable, or VAT..</param>
        public FinantialTransactionDetails(Money requestedAmount = default(Money), Money payedAmount = default(Money), Collection<Fee> fees = default(Collection<Fee>))
        {
            this.RequestedAmount = requestedAmount;
            this.PayedAmount = payedAmount;
            this.Fees = fees;
        }

        /// <summary>
        /// The amount requested by payee.
        /// </summary>
        /// <value>The amount requested by payee.</value>
        [DataMember(Name = "requested_amount", EmitDefaultValue = false)]
        public Money RequestedAmount { get; set; }

        /// <summary>
        /// The amount payed by payer.
        /// </summary>
        /// <value>The amount payed by payer.</value>
        [DataMember(Name = "payed_amount", EmitDefaultValue = false)]
        public Money PayedAmount { get; set; }

        /// <summary>
        /// An array of fee objects, where each fee represents a specific charge or cost associated with a transaction.   Each fee includes details such as the amount and currency, and may represent different types of fees   like fixed, variable, or VAT.
        /// </summary>
        /// <value>An array of fee objects, where each fee represents a specific charge or cost associated with a transaction.   Each fee includes details such as the amount and currency, and may represent different types of fees   like fixed, variable, or VAT.</value>
        [DataMember(Name = "fees", EmitDefaultValue = false)]
        public Collection<Fee> Fees { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class FinantialTransactionDetails {\n");
            sb.Append("  RequestedAmount: ").Append(RequestedAmount).Append("\n");
            sb.Append("  PayedAmount: ").Append(PayedAmount).Append("\n");
            sb.Append("  Fees: ").Append(Fees).Append("\n");
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
