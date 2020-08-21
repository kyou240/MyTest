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
    /// 到達通知取得レスポンス
    /// </summary>
    [DataContract]
    public partial class TotatsuJohoResponse : IEquatable<TotatsuJohoResponse>
    {
        /// <summary>
        /// 到達日時
        /// </summary>
        /// <value>到達日時</value>
        [DataMember(Name="totatsuNichiji", EmitDefaultValue=false)]
        public DateTime TotatsuNichiji { get; set; }

        /// <summary>
        /// 到達通知ファイル。HTMLファイル。
        /// </summary>
        /// <value>到達通知ファイル。HTMLファイル。</value>
        [Required]
        [DataMember(Name="totatsuTsuchi", EmitDefaultValue=false)]
        public byte[] TotatsuTsuchi { get; set; }

        /// <summary>
        /// 受付結果：  - 0・・・正常   - 1・・・形式チェックエラー   - 2・・・手続きIDエラー   - 3・・・大量請求制限エラー   - 4・・・添付ファイル拡張子エラー   - 5・・・添付ファイル必須エラー   - 6・・・提出先エラー   - 7・・・初回申請番号エラー   - 8・・・初回申請番号処理状況エラー   - 9・・・署名検証エラー   - 10・・・証明書検証エラー   - 11・・・登記権利者特定エラー 
        /// </summary>
        /// <value>受付結果：  - 0・・・正常   - 1・・・形式チェックエラー   - 2・・・手続きIDエラー   - 3・・・大量請求制限エラー   - 4・・・添付ファイル拡張子エラー   - 5・・・添付ファイル必須エラー   - 6・・・提出先エラー   - 7・・・初回申請番号エラー   - 8・・・初回申請番号処理状況エラー   - 9・・・署名検証エラー   - 10・・・証明書検証エラー   - 11・・・登記権利者特定エラー </value>
        [Required]
        [DataMember(Name="uketsukeKekka", EmitDefaultValue=false)]
        public int UketsukeKekka { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TotatsuJohoResponse {\n");
            sb.Append("  TotatsuNichiji: ").Append(TotatsuNichiji).Append("\n");
            sb.Append("  TotatsuTsuchi: ").Append(TotatsuTsuchi).Append("\n");
            sb.Append("  UketsukeKekka: ").Append(UketsukeKekka).Append("\n");
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
            return obj.GetType() == GetType() && Equals((TotatsuJohoResponse)obj);
        }

        /// <summary>
        /// Returns true if TotatsuJohoResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of TotatsuJohoResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TotatsuJohoResponse other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    TotatsuNichiji == other.TotatsuNichiji ||
                    TotatsuNichiji != null &&
                    TotatsuNichiji.Equals(other.TotatsuNichiji)
                ) && 
                (
                    TotatsuTsuchi == other.TotatsuTsuchi ||
                    TotatsuTsuchi != null &&
                    TotatsuTsuchi.Equals(other.TotatsuTsuchi)
                ) && 
                (
                    UketsukeKekka == other.UketsukeKekka ||
                    
                    UketsukeKekka.Equals(other.UketsukeKekka)
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
                    if (TotatsuNichiji != null)
                    hashCode = hashCode * 59 + TotatsuNichiji.GetHashCode();
                    if (TotatsuTsuchi != null)
                    hashCode = hashCode * 59 + TotatsuTsuchi.GetHashCode();
                    
                    hashCode = hashCode * 59 + UketsukeKekka.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(TotatsuJohoResponse left, TotatsuJohoResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TotatsuJohoResponse left, TotatsuJohoResponse right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
