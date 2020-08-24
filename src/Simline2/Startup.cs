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
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Simline2.Authentication;
using Simline2.Filters;
using Simline2.MiddleWares;
using Simline2.OpenApi;
using SlDataProvider;

namespace Simline2
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// The application configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {

            // Add framework services.
            services
                // Don't need the full MVC stack for an API, see https://andrewlock.net/comparing-startup-between-the-asp-net-core-3-templates/
                .AddControllers()
                .AddNewtonsoftJson(opts =>
                {
                    opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    opts.SerializerSettings.Converters.Add(new StringEnumConverter
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    });
                });

            services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("0.1", new OpenApiInfo
                    {
                        Title = "登記・供託オンライン申請システムAPI",
                        Description = "登記・供託オンライン申請システムAPI (ASP.NET Core 3.1)",
                        TermsOfService = new Uri("https://github.com/openapitools/openapi-generator"),
                        Contact = new OpenApiContact
                        {
                            Name = "OpenAPI-Generator Contributors",
                            Url = new Uri("https://github.com/openapitools/openapi-generator"),
                            Email = ""
                        },
                        License = new OpenApiLicense
                        {
                            Name = "NoLicense",
                            Url = new Uri("http://localhost")
                        },
                        Version = "0.1",
                    });
                    c.CustomSchemaIds(type => type.FriendlyId(true));
                    c.DescribeAllEnumsAsStrings();
                    c.IncludeXmlComments($"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}{Assembly.GetEntryAssembly().GetName().Name}.xml");
                    // Sets the basePath property in the Swagger document generated
                    c.DocumentFilter<BasePathFilter>("/rs/api/v1");

                    // Include DataAnnotation attributes on Controller Action parameters as Swagger validation rules (e.g required, pattern, ..)
                    // Use [ValidateModelState] on Actions to actually validate it in C# as well!
                    c.OperationFilter<GeneratePathParamsValidationFilter>();
                });
            services
                .AddSwaggerGenNewtonsoftSupport();
            //セッションサービス
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(1);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            //シミュレータ設定のDBのコンテキスト
            services.AddDbContext<SimLineDbContext>(options => options
            .UseMySql(
                Configuration.GetConnectionString("SimLineDbConnectionString"),
                MySqlOptions => MySqlOptions.ServerVersion(new Version(10, 5, 4), ServerType.MariaDb)
                )
            );

            //申請者情報取得サービス登録
            services.AddScoped<IShinseishaService, ShinseishaService>();

            //シミュレータ設定取得サービス登録
            services.AddScoped<ISMConfigService, SMConfigService>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseSwagger(c =>
                {
                    c.RouteTemplate = "swagger/{documentName}/openapi.json";
                })
                .UseSwaggerUI(c =>
                {
                    //TODO: Either use the SwaggerGen generated Swagger contract (generated from C# classes)
                    c.SwaggerEndpoint("/swagger/0.1/openapi.json", "登記・供託オンライン申請システムAPI");

                    //TODO: Or alternatively use the original Swagger contract that's included in the static files
                    // c.SwaggerEndpoint("/openapi-original.json", "登記・供託オンライン申請システムAPI Original");
                });
            app.UseRouting();

            //セッションミドルウェア
            app.UseSession();

            //サービス時間チェック
            app.UseMiddleware<OutOfServiceMiddleware>();

            //ベーシック認証ミドルウェア
            app.UseMiddleware<BasicAuthMiddleware>();

            app.UseEndpoints(endpoints =>
	            {
	    	        endpoints.MapControllers();
	            });
        }
    }
}
