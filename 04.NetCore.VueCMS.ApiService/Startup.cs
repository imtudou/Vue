using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace NetCore.VueCMS.ApiService
{
    public class Startup
    {
        #region 构造函数
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            //configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", true, true)
            //    .Build();
            Configuration = configuration;
        }

        #endregion



        #region 配置服务中间件
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            #region 配置跨域
            services.AddCors(options =>
            {
                //默认策略
                options.AddDefaultPolicy(builder =>
                {
                    //AllowAnyOrigin – 允许来自任何方案使用所有来源的 CORS 请求 (http或https)
                    builder.SetIsOriginAllowedToAllowWildcardSubdomains()
                        .WithOrigins("*") ////允许http://localhost:8089的主机访问
                        .AllowAnyMethod() //允许任何 HTTP 方法
                        .AllowAnyHeader() //允许所有作者的请求标头调用AllowAnyHeader:
                        .AllowCredentials() //服务器必须允许凭据。 若要允许跨域凭据，调用AllowCredentials:
                        .AllowAnyOrigin(); //允许任何来源的主机访问

                });

                //自定义策略
                options.AddPolicy("AllowAllOrigin", builder =>
                {
                    //AllowAnyOrigin – 允许来自任何方案使用所有来源的 CORS 请求 (http或https)
                    builder.SetIsOriginAllowedToAllowWildcardSubdomains()
                        .WithOrigins("*") ////允许http://localhost:8089的主机访问
                        .AllowAnyMethod() //允许任何 HTTP 方法
                        .AllowAnyHeader() //允许所有作者的请求标头调用AllowAnyHeader:
                        .AllowCredentials() //服务器必须允许凭据。 若要允许跨域凭据，调用AllowCredentials:
                        .AllowAnyOrigin(); //允许任何来源的主机访问
                });
            });
            #endregion

            #region 配置Swagger
            //Swagger所需要的配置项
            services.AddSwaggerGen(c =>
            {
                //添加Swagger.
                c.SwaggerDoc("VueCmsApiService", new Info
                {
                    Version = "V201911001.0",
                    Title = "VueCMS接口文档",
                    Description = "VueCMS接口文档",
                    //服务条款
                    TermsOfService = "None",
                    //作者信息
                    Contact = new Contact
                    {
                        Name = "无敌小土豆",
                        Email = "imtudous@163.com",
                        Url = "http://www.imtudou.cn/"
                    },
                    //许可证
                    License = new License
                    {
                        Name = "土豆部落",
                        Url = "http://www.imtudou.cn/"
                    }
                });
                // 下面三个方法为 Swagger JSON and UI设置xml文档注释路径
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//获取应用程序所在目录（绝对，不受工作目录影响，建议采用此方法获取路径）
                var xmlPath = Path.Combine(basePath, "NetCore.VueCMS.ApiService.xml");
                c.IncludeXmlComments(xmlPath);
            });

            //读取aoosettings.json里配置的数据库连接语句需要的代码
            //services.Configure<DBContext>(Configuration.GetSection("SqlConfiguration")); 
            #endregion


        }
        #endregion


        #region 启用服务
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            #region 启用跨域
            //跨域服务必须放在 UseMvc 之前
            app.UseCors();//启用默认策略
                          //app.UseCors("AllowAllOrigin");//启用自定义策略

            #endregion


            #region 启用配置Swagger
            // 配置Swagger  必须加在app.UseMvc前面
            app.UseSwagger();
            //Swagger Core需要配置的  必须加在app.UseMvc前面
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/VueCmsApiService/swagger.json", "VueCmsApiService");
                //汉化
                c.InjectJavascript($"Language/swagger_zh-cn.js");
            });
            #endregion

            app.UseStaticFiles();//启用静态文件访问 wwwroot
            //var defaultFilesOptions = new DefaultFilesOptions();
            //defaultFilesOptions.DefaultFileNames.Add("swagger/index.html");
            //app.UseDefaultFiles(defaultFilesOptions);//配置默认访问页面


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();



        }
        #endregion
    }
}
