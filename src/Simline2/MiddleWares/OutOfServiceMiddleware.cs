using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SlDataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simline2.MiddleWares
{
    /// <summary>
    /// 利用時間外ミドルウェア
    /// </summary>
    public class OutOfServiceMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="next">次のミドルウェア</param>
        /// <param name="serviceProvider">サービスプロバイダ</param>
        public OutOfServiceMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
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
            using var scope = _serviceProvider.CreateScope();
            var _sMConfigService = scope.ServiceProvider.GetRequiredService<ISMConfigService>();
            //利用時間の設定を取得（0:サービス時間内、1:サービス時間外）
            SMConfigDataModel smModel = _sMConfigService.Get("サービス時間");
            if (smModel.VALUE == "1")
            {
                //認証失敗
                context.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                string errorMessage = "サービス利用時間外です。";
                int status = 503;
                string title = "Service unavailable";
                string responseText = string.Format("{{\r\n  \"errorMessage\" : \"{0}\",\r\n  \"status\" : {1}, \r\n  \"title\" : \"{2}\"\r\n}}", errorMessage, status, title);
                await context.Response.WriteAsync(responseText);
            }
            else
            {
                await _next.Invoke(context);
                return;
            }
        }
    }
}
