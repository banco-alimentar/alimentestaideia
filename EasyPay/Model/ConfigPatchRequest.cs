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
    /// ConfigPatchRequest
    /// </summary>
    [DataContract(Name = "_config_patch_request")]
    public partial class ConfigPatchRequest : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigPatchRequest" /> class.
        /// </summary>
        /// <param name="generic">URL for generic notification (default to &quot;https://www.easypay.pt/generic&quot;).</param>
        /// <param name="authorisation">URL for authorisation notification (default to &quot;https://www.easypay.pt/authorisation&quot;).</param>
        /// <param name="transaction">URL for transaction notification (default to &quot;https://www.easypay.pt/transaction&quot;).</param>
        /// <param name="visaFwd">URL for redirect clients on credit card forward (default to &quot;https://www.easypay.pt/visa_fwd&quot;).</param>
        /// <param name="visaDetail">URL for credit card payment detail (default to &quot;https://www.easypay.pt/visa_detail&quot;).</param>
        public ConfigPatchRequest(string generic = @"https://www.easypay.pt/generic", string authorisation = @"https://www.easypay.pt/authorisation", string transaction = @"https://www.easypay.pt/transaction", string visaFwd = @"https://www.easypay.pt/visa_fwd", string visaDetail = @"https://www.easypay.pt/visa_detail")
        {
            // use default value if no "generic" provided
            this.Generic = generic ?? @"https://www.easypay.pt/generic";
            // use default value if no "authorisation" provided
            this.Authorisation = authorisation ?? @"https://www.easypay.pt/authorisation";
            // use default value if no "transaction" provided
            this.Transaction = transaction ?? @"https://www.easypay.pt/transaction";
            // use default value if no "visaFwd" provided
            this.VisaFwd = visaFwd ?? @"https://www.easypay.pt/visa_fwd";
            // use default value if no "visaDetail" provided
            this.VisaDetail = visaDetail ?? @"https://www.easypay.pt/visa_detail";
        }

        /// <summary>
        /// URL for generic notification
        /// </summary>
        /// <value>URL for generic notification</value>
        [DataMember(Name = "generic", EmitDefaultValue = false)]
        public string Generic { get; set; }

        /// <summary>
        /// URL for authorisation notification
        /// </summary>
        /// <value>URL for authorisation notification</value>
        [DataMember(Name = "authorisation", EmitDefaultValue = false)]
        public string Authorisation { get; set; }

        /// <summary>
        /// URL for transaction notification
        /// </summary>
        /// <value>URL for transaction notification</value>
        [DataMember(Name = "transaction", EmitDefaultValue = false)]
        public string Transaction { get; set; }

        /// <summary>
        /// URL for redirect clients on credit card forward
        /// </summary>
        /// <value>URL for redirect clients on credit card forward</value>
        [DataMember(Name = "visa_fwd", EmitDefaultValue = false)]
        public string VisaFwd { get; set; }

        /// <summary>
        /// URL for credit card payment detail
        /// </summary>
        /// <value>URL for credit card payment detail</value>
        [DataMember(Name = "visa_detail", EmitDefaultValue = false)]
        public string VisaDetail { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ConfigPatchRequest {\n");
            sb.Append("  Generic: ").Append(Generic).Append("\n");
            sb.Append("  Authorisation: ").Append(Authorisation).Append("\n");
            sb.Append("  Transaction: ").Append(Transaction).Append("\n");
            sb.Append("  VisaFwd: ").Append(VisaFwd).Append("\n");
            sb.Append("  VisaDetail: ").Append(VisaDetail).Append("\n");
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
