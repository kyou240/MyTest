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
    /// 戸籍統一文字検索レスポンス
    /// </summary>
    [DataContract]
    public partial class CharacterKosekiResponse : IEquatable<CharacterKosekiResponse>
    {
        /// <summary>
        /// 検索でヒットした漢字文字情報の件数。該当する漢字の件数が50件を超える場合、51を固定で返却する。
        /// </summary>
        /// <value>検索でヒットした漢字文字情報の件数。該当する漢字の件数が50件を超える場合、51を固定で返却する。</value>
        [Required]
        [Range(0, 51)]
        [DataMember(Name="unlimitedRecordCount", EmitDefaultValue=false)]
        public int? UnlimitedRecordCount { get; set; }

        /// <summary>
        /// 漢字文字情報のリスト。該当する漢字の件数が50件を超える場合、リストには50件分の情報まで格納する。
        /// </summary>
        /// <value>漢字文字情報のリスト。該当する漢字の件数が50件を超える場合、リストには50件分の情報まで格納する。</value>
        [DataMember(Name="characterInfos", EmitDefaultValue=false)]
        public List<CharacterKosekiResponseCharacterInfos> CharacterInfos { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CharacterKosekiResponse {\n");
            sb.Append("  UnlimitedRecordCount: ").Append(UnlimitedRecordCount).Append("\n");
            sb.Append("  CharacterInfos: ").Append(CharacterInfos).Append("\n");
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
            return obj.GetType() == GetType() && Equals((CharacterKosekiResponse)obj);
        }

        /// <summary>
        /// Returns true if CharacterKosekiResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of CharacterKosekiResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CharacterKosekiResponse other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    UnlimitedRecordCount == other.UnlimitedRecordCount ||
                    UnlimitedRecordCount != null &&
                    UnlimitedRecordCount.Equals(other.UnlimitedRecordCount)
                ) && 
                (
                    CharacterInfos == other.CharacterInfos ||
                    CharacterInfos != null &&
                    other.CharacterInfos != null &&
                    CharacterInfos.SequenceEqual(other.CharacterInfos)
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
                    if (UnlimitedRecordCount != null)
                    hashCode = hashCode * 59 + UnlimitedRecordCount.GetHashCode();
                    if (CharacterInfos != null)
                    hashCode = hashCode * 59 + CharacterInfos.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(CharacterKosekiResponse left, CharacterKosekiResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CharacterKosekiResponse left, CharacterKosekiResponse right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
