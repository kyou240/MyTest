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
    /// 連件申請送信リクエスト
    /// </summary>
    [DataContract]
    public partial class SubmitRenkenRequest : IEquatable<SubmitRenkenRequest>
    {
        /// <summary>
        /// ZIP形式でまとめられた申請データ
        /// </summary>
        /// <value>ZIP形式でまとめられた申請データ</value>
        [Required]
        [DataMember(Name="data", EmitDefaultValue=false)]
        public byte[] Data { get; set; }

        /// <summary>
        /// 申請の宛先となる登記所のコード
        /// </summary>
        /// <value>申請の宛先となる登記所のコード</value>
        [Required]
        [RegularExpression("^[0-9]{4}$")]
        [DataMember(Name="tokishoCode", EmitDefaultValue=false)]
        public string TokishoCode { get; set; }

        /// <summary>
        /// この連件申請の中での順番。1から始めて送信のたびに1ずつ増やすこと。
        /// </summary>
        /// <value>この連件申請の中での順番。1から始めて送信のたびに1ずつ増やすこと。</value>
        [Required]
        [DataMember(Name="seq", EmitDefaultValue=false)]
        public int Seq { get; set; }

        /// <summary>
        /// この連件申請で申請する申請案件の数。毎回同じ値を指定すること。設定する値は２以上であること。
        /// </summary>
        /// <value>この連件申請で申請する申請案件の数。毎回同じ値を指定すること。設定する値は２以上であること。</value>
        [Required]
        [DataMember(Name="total", EmitDefaultValue=false)]
        public int Total { get; set; }

        /// <summary>
        /// 申請案件の同順位番号
        /// </summary>
        /// <value>申請案件の同順位番号</value>
        [Required]
        [DataMember(Name="dojuniBango", EmitDefaultValue=false)]
        public int DojuniBango { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SubmitRenkenRequest {\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
            sb.Append("  TokishoCode: ").Append(TokishoCode).Append("\n");
            sb.Append("  Seq: ").Append(Seq).Append("\n");
            sb.Append("  Total: ").Append(Total).Append("\n");
            sb.Append("  DojuniBango: ").Append(DojuniBango).Append("\n");
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
            return obj.GetType() == GetType() && Equals((SubmitRenkenRequest)obj);
        }

        /// <summary>
        /// Returns true if SubmitRenkenRequest instances are equal
        /// </summary>
        /// <param name="other">Instance of SubmitRenkenRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SubmitRenkenRequest other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Data == other.Data ||
                    Data != null &&
                    Data.Equals(other.Data)
                ) && 
                (
                    TokishoCode == other.TokishoCode ||
                    TokishoCode != null &&
                    TokishoCode.Equals(other.TokishoCode)
                ) && 
                (
                    Seq == other.Seq ||
                    
                    Seq.Equals(other.Seq)
                ) && 
                (
                    Total == other.Total ||
                    
                    Total.Equals(other.Total)
                ) && 
                (
                    DojuniBango == other.DojuniBango ||
                    
                    DojuniBango.Equals(other.DojuniBango)
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
                    if (Data != null)
                    hashCode = hashCode * 59 + Data.GetHashCode();
                    if (TokishoCode != null)
                    hashCode = hashCode * 59 + TokishoCode.GetHashCode();
                    
                    hashCode = hashCode * 59 + Seq.GetHashCode();
                    
                    hashCode = hashCode * 59 + Total.GetHashCode();
                    
                    hashCode = hashCode * 59 + DojuniBango.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(SubmitRenkenRequest left, SubmitRenkenRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SubmitRenkenRequest left, SubmitRenkenRequest right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
