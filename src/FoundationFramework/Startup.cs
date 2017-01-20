using System;
using System.IO;
using System.Text;
using LTF.Implements;
using LTF.Interfaces;
using LTF.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.Swagger.Model;

namespace LTF
{
    public partial class Startup
    {
        IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // 配置cors
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            // 全局可跨域访问
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowAll"));
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                                        ops => ops.UseRowNumberForPaging()));

            services.AddScoped<IUserLogic, UserLogic>();
            services.AddScoped<IDepartmentLogic, DepartmentLogic>();
            services.AddScoped<ILogLogic, LogLogic>();
            services.AddScoped<IRoleLogic, RoleLogic>();

            services.AddMvc();

            services.AddSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "API接口文档",
                    Description = "XXX系统接口文档",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "FF", Email = "", Url = "https://github.com/litengfei-ff" },
                    //License = new License { Name = "Use under LICX", Url = "http://url.com" },
                });
                //Determine base path for the application.
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;

                //Set the comments path for the swagger json and ui.
                var xmlPath = Path.Combine(basePath, "FoundationFramework.xml");
                options.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseStatusCodePages();
                app.UseDeveloperExceptionPage();
            }

            // 配置JWT验证
            ConfigureJwtAuth(app);

            app.UseMvcWithDefaultRoute();

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUi();

            ApplicationDbContext.SetSeed(app.ApplicationServices, Configuration);

        }

        /// <summary>
        /// 配置JWT验证
        /// </summary>
        /// <param name="app"></param>
        public void ConfigureJwtAuth(IApplicationBuilder app)
        {
            var audienceConfig = Configuration.GetSection("JWT");
            var symmetricKeyAsBase64 = audienceConfig["Secret"];
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                ValidateIssuer = true,
                ValidIssuer = audienceConfig["Issuer"],

                ValidateAudience = true,
                ValidAudience = audienceConfig["Audience"],

                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };

            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = tokenValidationParameters,
            });
        }
    }
}
