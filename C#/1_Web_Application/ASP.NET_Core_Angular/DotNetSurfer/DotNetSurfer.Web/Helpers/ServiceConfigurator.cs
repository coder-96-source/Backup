using DotNetSurfer.Core.Encryptors;
using DotNetSurfer.Core.TokenGenerators;
using DotNetSurfer.Web.Models;
using DotNetSurfer.DAL.Repositories;
using DotNetSurfer.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NLog;
using NLog.Extensions.Logging;
using System;
using System.Text;
using DotNetSurfer.DAL.Entities;
using DotNetSurfer.DAL.CDNs.Interfaces;

namespace DotNetSurfer.Web.Helpers
{
    public static class ServiceConfigurator
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddSingleton<IEncryptor, HashEncryptor>();
            services.AddSingleton<ITokenGenerator, JwtGenerator>();
            services.AddScoped<ICdnHandler, AzureBlobHandler>();
        }

        public static void AddAngularServices(this IServiceCollection services)
        {
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        public static void AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DotNetSurferDbContext>((options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(nameof(Models.Permission), policy => policy.RequireRole(PermissionType.Admin.ToString()));
            });
        }

        public static void AddAspDotNetCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            // To avoid loop between primary and foreign keys
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            // Session
            // Adds a default in-memory implementation of IDistributedCache.
            services.AddDistributedMemoryCache();

            int sessionExpireMinutes = Convert.ToInt32(configuration["Session:ExpireMinutes"]);
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(sessionExpireMinutes);
                options.Cookie.HttpOnly = true;
            });

            // ASP.NET Core
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public static void ConfigureAspDotNetCore(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }

        public static void ConfigureAngular(this IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSpaStaticFiles();
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

        public static void ConfigureExceptionHandler(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
        }

        public static void ConfigureLogHandler(ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            GlobalDiagnosticsContext.Set("connectionString", configuration.GetConnectionString("DefaultConnection"));
            loggerFactory.AddNLog();
        }
    }
}
