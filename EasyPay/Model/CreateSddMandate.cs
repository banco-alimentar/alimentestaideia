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
    /// The SDD Mandate object contains the necessary fields to create a SEPA Direct Debit mandate. This object ensures that all required information is provided to authorize and process SEPA Direct Debit transactions. Object required when method is Direct Debit.
    /// </summary>
    [DataContract(Name = "CreateSddMandate")]
    public partial class CreateSddMandate : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSddMandate" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CreateSddMandate() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSddMandate" /> class.
        /// </summary>
        /// <param name="id">A unique identifier for the resource. While typically formatted as a UUID (Universally Unique Identifier), it can also be in other formats as defined by the user. This field ensures the resource can be distinctly recognized and referenced..</param>
        /// <param name="iban">The International Bank Account Number (IBAN) of the debtor&#39;s account. This field is used to uniquely identify the debtor&#39;s bank account across international borders, ensuring accurate and efficient processing of SEPA Direct Debit transactions. The IBAN is a standardized format that includes the country code, check digits, bank code, and account number. (required).</param>
        /// <param name="key">A customizable text field for users to input their own identifier for the resource. This can be any string that helps the user uniquely identify or reference the resource in their own system..</param>
        /// <param name="name">The full name of the individual or entity. This field is used to identify the person or organization involved in the transaction or mandate. (required).</param>
        /// <param name="email">The contact phone number of the individual or entity, including the country code indicator (e.g., \&quot;+351\&quot;). This field is used for communication purposes, such as contacting the individual for verification or support. (required).</param>
        /// <param name="phone">The contact phone number of the individual or entity, excluding the country code indicator (e.g., \&quot;+351\&quot;). This field is used for communication purposes, such as contacting the individual for verification or support. If the payment method is MBWAY, the phone number is required and is used to send the MBWAY push notification. (required).</param>
        /// <param name="accountHolder">The name of the person or entity that holds the bank account. This field is used to identify the owner of the bank account involved in the transaction, ensuring that the correct account is credited or debited. (required).</param>
        /// <param name="countryCode">The two-letter ISO 3166-1 alpha-2 country code representing the country of the individual or entity. This field is used to specify the country associated with the address or account, ensuring correct geographical identification..</param>
        /// <param name="maxNumDebits">The maximum number of debits that can be made under the mandate. This field sets a limit on the number of transactions that can be processed, providing control and security over the usage of the direct debit mandate..</param>
        public CreateSddMandate(string id = default(string), string iban = default(string), string key = default(string), string name = default(string), string email = default(string), string phone = default(string), string accountHolder = default(string), string countryCode = default(string), string maxNumDebits = default(string))
        {
            // to ensure "iban" is required (not null)
            if (iban == null)
            {
                throw new ArgumentNullException("iban is a required property for CreateSddMandate and cannot be null");
            }
            this.Iban = iban;
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for CreateSddMandate and cannot be null");
            }
            this.Name = name;
            // to ensure "email" is required (not null)
            if (email == null)
            {
                throw new ArgumentNullException("email is a required property for CreateSddMandate and cannot be null");
            }
            this.Email = email;
            // to ensure "phone" is required (not null)
            if (phone == null)
            {
                throw new ArgumentNullException("phone is a required property for CreateSddMandate and cannot be null");
            }
            this.Phone = phone;
            // to ensure "accountHolder" is required (not null)
            if (accountHolder == null)
            {
                throw new ArgumentNullException("accountHolder is a required property for CreateSddMandate and cannot be null");
            }
            this.AccountHolder = accountHolder;
            this.Id = id;
            this.Key = key;
            this.CountryCode = countryCode;
            this.MaxNumDebits = maxNumDebits;
        }

        /// <summary>
        /// A unique identifier for the resource. While typically formatted as a UUID (Universally Unique Identifier), it can also be in other formats as defined by the user. This field ensures the resource can be distinctly recognized and referenced.
        /// </summary>
        /// <value>A unique identifier for the resource. While typically formatted as a UUID (Universally Unique Identifier), it can also be in other formats as defined by the user. This field ensures the resource can be distinctly recognized and referenced.</value>
        /*
        <example>c6056234-a3f9-42de-b944-3ed793fcb6bb</example>
        */
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// The International Bank Account Number (IBAN) of the debtor&#39;s account. This field is used to uniquely identify the debtor&#39;s bank account across international borders, ensuring accurate and efficient processing of SEPA Direct Debit transactions. The IBAN is a standardized format that includes the country code, check digits, bank code, and account number.
        /// </summary>
        /// <value>The International Bank Account Number (IBAN) of the debtor&#39;s account. This field is used to uniquely identify the debtor&#39;s bank account across international borders, ensuring accurate and efficient processing of SEPA Direct Debit transactions. The IBAN is a standardized format that includes the country code, check digits, bank code, and account number.</value>
        /*
        <example>PT50000747199140461443823</example>
        */
        [DataMember(Name = "iban", IsRequired = true, EmitDefaultValue = true)]
        public string Iban { get; set; }

        /// <summary>
        /// A customizable text field for users to input their own identifier for the resource. This can be any string that helps the user uniquely identify or reference the resource in their own system.
        /// </summary>
        /// <value>A customizable text field for users to input their own identifier for the resource. This can be any string that helps the user uniquely identify or reference the resource in their own system.</value>
        /*
        <example>01J1PKR2RPHJNJQGFWGDYXY0KM</example>
        */
        [DataMember(Name = "key", EmitDefaultValue = false)]
        public string Key { get; set; }

        /// <summary>
        /// The full name of the individual or entity. This field is used to identify the person or organization involved in the transaction or mandate.
        /// </summary>
        /// <value>The full name of the individual or entity. This field is used to identify the person or organization involved in the transaction or mandate.</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// The contact phone number of the individual or entity, including the country code indicator (e.g., \&quot;+351\&quot;). This field is used for communication purposes, such as contacting the individual for verification or support.
        /// </summary>
        /// <value>The contact phone number of the individual or entity, including the country code indicator (e.g., \&quot;+351\&quot;). This field is used for communication purposes, such as contacting the individual for verification or support.</value>
        [DataMember(Name = "email", IsRequired = true, EmitDefaultValue = true)]
        public string Email { get; set; }

        /// <summary>
        /// The contact phone number of the individual or entity, excluding the country code indicator (e.g., \&quot;+351\&quot;). This field is used for communication purposes, such as contacting the individual for verification or support. If the payment method is MBWAY, the phone number is required and is used to send the MBWAY push notification.
        /// </summary>
        /// <value>The contact phone number of the individual or entity, excluding the country code indicator (e.g., \&quot;+351\&quot;). This field is used for communication purposes, such as contacting the individual for verification or support. If the payment method is MBWAY, the phone number is required and is used to send the MBWAY push notification.</value>
        [DataMember(Name = "phone", IsRequired = true, EmitDefaultValue = true)]
        public string Phone { get; set; }

        /// <summary>
        /// The name of the person or entity that holds the bank account. This field is used to identify the owner of the bank account involved in the transaction, ensuring that the correct account is credited or debited.
        /// </summary>
        /// <value>The name of the person or entity that holds the bank account. This field is used to identify the owner of the bank account involved in the transaction, ensuring that the correct account is credited or debited.</value>
        [DataMember(Name = "account_holder", IsRequired = true, EmitDefaultValue = true)]
        public string AccountHolder { get; set; }

        /// <summary>
        /// The two-letter ISO 3166-1 alpha-2 country code representing the country of the individual or entity. This field is used to specify the country associated with the address or account, ensuring correct geographical identification.
        /// </summary>
        /// <value>The two-letter ISO 3166-1 alpha-2 country code representing the country of the individual or entity. This field is used to specify the country associated with the address or account, ensuring correct geographical identification.</value>
        [DataMember(Name = "country_code", EmitDefaultValue = false)]
        public string CountryCode { get; set; }

        /// <summary>
        /// The maximum number of debits that can be made under the mandate. This field sets a limit on the number of transactions that can be processed, providing control and security over the usage of the direct debit mandate.
        /// </summary>
        /// <value>The maximum number of debits that can be made under the mandate. This field sets a limit on the number of transactions that can be processed, providing control and security over the usage of the direct debit mandate.</value>
        [DataMember(Name = "max_num_debits", EmitDefaultValue = false)]
        public string MaxNumDebits { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CreateSddMandate {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Iban: ").Append(Iban).Append("\n");
            sb.Append("  Key: ").Append(Key).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  Phone: ").Append(Phone).Append("\n");
            sb.Append("  AccountHolder: ").Append(AccountHolder).Append("\n");
            sb.Append("  CountryCode: ").Append(CountryCode).Append("\n");
            sb.Append("  MaxNumDebits: ").Append(MaxNumDebits).Append("\n");
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
            // Iban (string) maxLength
            if (this.Iban != null && this.Iban.Length > 34)
            {
                yield return new ValidationResult("Invalid value for Iban, length must be less than 34.", new[] { "Iban" });
            }

            // Key (string) maxLength
            if (this.Key != null && this.Key.Length > 255)
            {
                yield return new ValidationResult("Invalid value for Key, length must be less than 255.", new[] { "Key" });
            }

            // Name (string) maxLength
            if (this.Name != null && this.Name.Length > 100)
            {
                yield return new ValidationResult("Invalid value for Name, length must be less than 100.", new[] { "Name" });
            }

            // Email (string) maxLength
            if (this.Email != null && this.Email.Length > 50)
            {
                yield return new ValidationResult("Invalid value for Email, length must be less than 50.", new[] { "Email" });
            }

            // Phone (string) maxLength
            if (this.Phone != null && this.Phone.Length > 20)
            {
                yield return new ValidationResult("Invalid value for Phone, length must be less than 20.", new[] { "Phone" });
            }

            // AccountHolder (string) maxLength
            if (this.AccountHolder != null && this.AccountHolder.Length > 100)
            {
                yield return new ValidationResult("Invalid value for AccountHolder, length must be less than 100.", new[] { "AccountHolder" });
            }

            yield break;
        }
    }

}
