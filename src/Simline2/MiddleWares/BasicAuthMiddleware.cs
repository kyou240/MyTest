using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SlDataProvider;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Simline2.MiddleWares
{
    /// <summary>
    /// ベーシック認証ミドルウェア
    /// </summary>
    public class BasicAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="next">次のミドルウェア</param>
        /// <param name="serviceProvider">サービスプロバイダー</param>
        public BasicAuthMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
        {
            _next = next;
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// リクエスト処理
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            //リクエスト中のBasic認証ヘッダを取得
            string authHeader = context.Request.Headers["Authorization"];
            if (null != authHeader && authHeader.StartsWith("Basic"))
            {
                string base64UserInfo = authHeader.Substring("Basic".Length).Trim();
                string userInfo = Encoding.UTF8.GetString(Convert.FromBase64String(base64UserInfo));
                int sepIndex = userInfo.IndexOf(":");
                string userid = userInfo.Substring(0, sepIndex);
                string password = userInfo.Substring(sepIndex + 1);

                //パスワードのハッシュ化
                string hashedpwd = ToSha256(password);

                //認証実行
                using var scope = _serviceProvider.CreateScope();
                var _shinseishaService = scope.ServiceProvider.GetRequiredService<IShinseishaService>();
                ShinseishaDataModel shinseisha = _shinseishaService.Get(userid, hashedpwd);

                //認証成功
                if (null != shinseisha)
                {
                    DateTime yukoKigembi = DateTime.Today.AddDays(shinseisha.YUKOKIGEN);
                    DateTime now = DateTime.Now;

                    if (!shinseisha.ACCTLOCK && now < yukoKigembi)
                    {
                        /*
                        //Basic認証成功の場合、ユーザーパスワードの有効期限の検証を行う
                        if (null == context.Session.GetString("申請者ID"))
                        {
                            //セッションにユーザーIDを保存
                            context.Session.SetString("申請者ID", userid);
                        }
                        */

                        //パスワード更新日計算
                        if ((yukoKigembi.AddDays(-180) <= now && now < yukoKigembi.AddDays(-90)) ||
                            (yukoKigembi.AddDays(-90) <= now && now < yukoKigembi.AddDays(-30)) ||
                            (yukoKigembi.AddDays(-30) <= now && now < yukoKigembi.AddDays(-7)) ||
                            yukoKigembi.AddDays(-7) <= now)
                        {
                            context.Response.Headers["X-PasswordKoushinTsuchi"] = "1";
                            context.Response.Headers["X-PasswordYukoKigen"] = yukoKigembi.AddSeconds(-1).ToString("yyyy.MM.dd HH:mm:ss", new System.Globalization.CultureInfo("ja-JP"));
                        }
                        else
                        {
                            context.Response.Headers["X-PasswordKoushinTsuchi"] = "0";
                        }

                        var claims = new[]
                        {
                            new Claim(ClaimTypes.Name, userid),
                            new Claim(ClaimTypes.Role, "User")
                        };
                        var identity = new ClaimsIdentity(claims, "Basic");
                        context.User = new ClaimsPrincipal(identity);

                        await _next(context);
                        return;
                    }

                    if (shinseisha.ACCTLOCK)
                    {
                        context.Response.Headers["X-LoginError"] = "ACCOUNT_LOCK_ERROR";
                    }
                    if (shinseisha.YUKOKIGEN <= 0)
                    {
                        context.Response.Headers["X-LoginError"] = "PASSWORD_YUKO_KIGEN_ERROR";
                    }
                }

                //認証失敗
                //context.Session.Clear();
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                string errorMessage = "認証に失敗しました。";
                int status = 401;
                string title = "Unauthorized";
                string responseText = string.Format("{{\r\n  \"errorMessage\" : \"{0}\",\r\n  \"status\" : {1}, \r\n  \"title\" : \"{2}\"\r\n}}", errorMessage, status, title);
                await context.Response.WriteAsync(responseText);
            }
        }

        private string ToSha256(string hashstr)
        {
            // SHA256 デフォルト実装のインスタンスを呼び出します。
            using SHA256 sha256 = SHA256.Create();

            // 文字列をバイト配列にエンコードします。
            byte[] encoded = Encoding.UTF8.GetBytes(hashstr);

            // ハッシュ値を計算します。
            byte[] hash = sha256.ComputeHash(encoded);

            // ハッシュ値を 16 進数文字列に変換します。書き方がちょっと面倒。
            // System.BitConverter.ToString(hash).Replace("-", "").ToLower() と同じ。
            // 16 進数文字列でなく Base64 文字列に変換する場合 -> System.Convert.ToBase64String(hash) で OK。
            // 各要素を 16 進数文字列に変換して結合しています。
            return string.Concat(hash.Select(b => $"{b:x2}"));
        }
    }
}
