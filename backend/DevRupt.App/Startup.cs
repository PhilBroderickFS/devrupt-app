using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DevRupt.Core.Clients;
using DevRupt.Core.Configuration;
using DevRupt.Core.Services;
using DevRupt.App.Data;
using DevRupt.App.Repositories;
using DevRupt.Core.Contracts;
using Swashbuckle.AspNetCore.SwaggerUI;

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

            services.AddHttpClient();

            services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();
            services.AddTransient<IReservationService, ReservationService>();
            services.AddTransient<IReservationRepository, ReservationRepository>();
            services.AddTransient<IFolioRepository, FolioRepository>();
            services.AddTransient<IIngredientRepository, IngredientRepository>();
            services.AddTransient<IIngredientService, IngredientService>();
            services.AddTransient<IRatePlanRepository, RatePlanRepository>();
            services.AddTransient<IRecommendedSetRepository, RecommendedSetRepository>();
            services.AddTransient<IRecommendationService, RecommendationService>();
            services.AddTransient<IApaleoClient, ApaleoClient>();
            services.AddAutoMapper(typeof(Startup));

            services.Configure<ApaleoClientCredentials>(_configuration.GetSection(ApaleoClientCredentials.ApaleoClient));
            
            services.AddControllersWithViews();

            services.AddHttpClient<IApaleoClient, ApaleoClient>();
            //services.AddHostedService<ReservationProcessor>();

            services.AddCors(o =>
            {
                o.AddPolicy("localhost", builder =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });

            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "coalla-phil-tayo",
                    Description = "coalla-phil-tayo Apaleo API",
                    TermsOfService = new System.Uri("https://google.com"),
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Admin",
                        Email = string.Empty,
                        Url = new System.Uri("https://google.com")

                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "License",
                        Url = new System.Uri("https://google.com")
                    }
                }); ;
            });
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

            app.UseCors("localhost");

            app.UseSwagger();
            app.UseSwaggerUI(option =>
            {
                option.DocumentTitle = $"coalla-phil-tayo API Documentation";
                option.SwaggerEndpoint("/swagger/v1/swagger.json", "coalla-phil-tayo V1");
                option.RoutePrefix = string.Empty;
                option.DocExpansion(DocExpansion.None);
            });

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
