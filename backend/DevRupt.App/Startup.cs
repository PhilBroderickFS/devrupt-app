using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using DevRupt.Core.Clients;
using DevRupt.Core.Configuration;
using DevRupt.Core.Repositories;
using DevRupt.Core.Services;
using DevRupt.Data.Repositories;

namespace DevRupt.App
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IReservationService, ReservationService>();
            services.AddTransient<IReservationRepository, ReservationRepository>();
            services.AddTransient<IApaleoClient, ApaleoClient>();

            services.Configure<ApaleoClientCredentials>(_configuration.GetSection(ApaleoClientCredentials.ApaleoClient));
            
            services.AddControllersWithViews();

            services.AddHttpClient("apaleo", client =>
            {
                client.BaseAddress = new Uri(_configuration.GetValue<string>("APALEO_BASE_URL"));

            });

            services.AddHostedService<ReservationProcessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Reservation}/{action=Index}/{id?}");
            });
        }
    }
}
