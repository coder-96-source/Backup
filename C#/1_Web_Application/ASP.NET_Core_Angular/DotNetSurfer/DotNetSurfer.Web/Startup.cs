using DotNetSurfer.Web.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DotNetSurfer.Web
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
            services.AddCoreServices();
            services.AddAngularServices();
            services.AddDatabaseServices(this.Configuration);
            services.AddAuthenticationServices(this.Configuration);
            services.AddAspDotNetCoreServices(this.Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            ServiceConfigurator.ConfigureExceptionHandler(app, env);
            ServiceConfigurator.ConfigureLogHandler(loggerFactory, this.Configuration);
            app.ConfigureAspDotNetCore();
            app.ConfigureAngular(env);
        }
    }
}
