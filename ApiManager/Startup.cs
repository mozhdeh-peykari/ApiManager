using ApiManager.Common;
using ApiManager.Extensions;
using ApiManager.Services;
using ApiManager.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ApiManager
{
    public class Startup
    {
        private readonly AppSettings appSettings;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            appSettings = configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection(nameof(AppSettings)));

            services.AddControllers();
            services.AddCustomSwagger();
            services.AddCustomJwt(appSettings.JwtSettings);
            services.AddAutoMapper(typeof(Startup));

            //DI
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJwtService, JwtService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCustomSwagger();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
