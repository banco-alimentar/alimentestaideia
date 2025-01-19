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
    /// An object within the capture request that specifies the details of the account to which the funds should be routed, different from the initially requested account. This ensures that the captured funds are directed to the correct destination as per the specific routing requirements.
    /// </summary>
    [DataContract(Name = "CaptureAccount")]
    public partial class CaptureAccount : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CaptureAccount" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CaptureAccount() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CaptureAccount" /> class.
        /// </summary>
        /// <param name="id">A unique identifier for the resource. While typically formatted as a UUID (Universally Unique Identifier), it can also be in other formats as defined by the user. This field ensures the resource can be distinctly recognized and referenced. (required).</param>
        public CaptureAccount(string id = default(string))
        {
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for CaptureAccount and cannot be null");
            }
            this.Id = id;
        }

        /// <summary>
        /// A unique identifier for the resource. While typically formatted as a UUID (Universally Unique Identifier), it can also be in other formats as defined by the user. This field ensures the resource can be distinctly recognized and referenced.
        /// </summary>
        /// <value>A unique identifier for the resource. While typically formatted as a UUID (Universally Unique Identifier), it can also be in other formats as defined by the user. This field ensures the resource can be distinctly recognized and referenced.</value>
        /*
        <example>c6056234-a3f9-42de-b944-3ed793fcb6bb</example>
        */
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CaptureAccount {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
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
