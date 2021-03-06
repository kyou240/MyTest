/*
 * 登記・供託オンライン申請システムAPI
 *
 *  本リファレンスは登記・供託オンライン申請システムAPIリファレンスとなります。  登記・供託オンライン申請システムAPIを利用することで、オンライン申請、処理状況の確認、公文書取得等を行うことができます。  本リファレンスは「API一覧」と「リクエスト・レスポンス一覧」で構成されており、それぞれ以下の内容を記しています。  ■API一覧      各APIの仕様について記しています。  ■リクエスト・レスポンス一覧      各APIのリクエスト及びレスポンスの構造や各API共通で扱う共通エラーレスポンスの構造を記しています。なお、Exampleの値はSwaggerファイルと異なる表記となる場合がありますので、別途提供するSwaggerファイルをあわせて確認してください。  共通エラーレスポンスは以下の4種類です。詳細についてはリクエスト・レスポンス一覧の内容を確認してください。    ・HTTP403（Forbidden）    ・HTTP404（Not Found）      ・HTTP500（Internal Server Error）      ・HTTP503（Service unavailable）    
 *
 * The version of the OpenAPI document: 0.1
 * 
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Simline2.Converters;

namespace Simline2.Models
{ 
    /// <summary>
    /// 連件意思確定リクエスト
    /// </summary>
    [DataContract]
    public partial class ConfirmRenkenRequest : IEquatable<ConfirmRenkenRequest>
    {
        /// <summary>
        /// 意思。連件申請を確定する場合はtrue、取下げる場合はfalseを設定する。
        /// </summary>
        /// <value>意思。連件申請を確定する場合はtrue、取下げる場合はfalseを設定する。</value>
        [Required]
        [DataMember(Name="decision", EmitDefaultValue=false)]
        public bool? Decision { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ConfirmRenkenRequest {\n");
            sb.Append("  Decision: ").Append(Decision).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((ConfirmRenkenRequest)obj);
        }

        /// <summary>
        /// Returns true if ConfirmRenkenRequest instances are equal
        /// </summary>
        /// <param name="other">Instance of ConfirmRenkenRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ConfirmRenkenRequest other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Decision == other.Decision ||
                    Decision != null &&
                    Decision.Equals(other.Decision)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (Decision != null)
                    hashCode = hashCode * 59 + Decision.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ConfirmRenkenRequest left, ConfirmRenkenRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ConfirmRenkenRequest left, ConfirmRenkenRequest right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
