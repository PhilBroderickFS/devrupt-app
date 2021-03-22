using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using DevRupt.Core.Clients;
using DevRupt.Core.Configuration;
using DevRupt.Core.Services;
using DevRupt.App.Data;
using DevRupt.App.Repositories;
using DevRupt.Core.Contracts;

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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("ReservationAzureConnection")));

            services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();
            services.AddTransient<IReservationService, ReservationService>();
            services.AddTransient<IReservationRepository, ReservationRepository>();
            services.AddTransient<IFolioRepository, FolioRepository>();
            services.AddTransient<IRatePlanRepository, RatePlanRepository>();
            services.AddTransient<IApaleoClient, ApaleoClient>();
            services.AddAutoMapper(typeof(Startup));

            services.Configure<ApaleoClientCredentials>(_configuration.GetSection(ApaleoClientCredentials.ApaleoClient));
            
            services.AddControllersWithViews();


            services.AddHostedService<ReservationProcessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                InitializeDatabase(app).GetAwaiter().GetResult();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static async Task InitializeDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            await dbContext.Database.MigrateAsync();
        }
    }
}
