using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BHG.Platform.DemoServer.Data.DbContexts;
using BHG.Platform.DemoServer.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.Generation.Processors.Security;

namespace BHG.Platform.DemoServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDbContext<AppDbContext>();
            services.AddScoped<IZoneService, ZoneService>();
            services.AddScoped<ILiuPengDistrictService, LiuPengDistrictService>();
            services.AddScoped<ILiuPengLocationService, LiuPengLocationService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            #region Swagger
            services.AddSwaggerDocument(settings =>
            {
                settings.PostProcess = document =>
                {
                    document.Info.Version = "v1.0.0";
                    document.Info.Title = "BHG Platform Demo Server";
                    document.Info.Description = "北京华联 Demo 服务";
                };
                settings.OperationProcessors.Add(new OperationSecurityScopeProcessor("Bearer"));
                settings.DocumentProcessors.Add(
                    new SecurityDefinitionAppender("Bearer", new string[] { }, new OpenApiSecurityScheme()
                    {
                        Type = OpenApiSecuritySchemeType.ApiKey,
                        Name = "Authorization",
                        Description = "Copy 'Bearer ' + valid JWT token into field",
                        In = OpenApiSecurityApiKeyLocation.Header
                    })
                );
            });
            #endregion

            #region Authentication
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = Configuration["IdServerAddress"];
                    options.TokenValidationParameters.ValidateIssuer = true;
                    options.TokenValidationParameters.ValidIssuer = "http://idserver.bhg";
                    options.RequireHttpsMetadata = false;

                    options.Audience = "api-demo-server";
                });
            #endregion

            #region Cors

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.SetIsOriginAllowedToAllowWildcardSubdomains();
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            #region Authentication

            app.UseAuthentication();

            #endregion

            #region Swagger

            app.UseOpenApi();
            app.UseSwaggerUi3();

            #endregion

            #region Cors

            app.UseCors();

            #endregion

            app.UseMvc();
        }
    }
}
