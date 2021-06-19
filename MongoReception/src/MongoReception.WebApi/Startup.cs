using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoReception.Application.Common.Interfaces;
using MongoReception.Application.Services;
using MongoReception.DataAccess.Interfaces;
using MongoReception.DataAccess.Settings;
using MongoReception.Infrastructure.Common.Interfaces;
using MongoReception.Infrastructure.Common.Providers;
using MongoReception.Infrastructure.Common.Repositories;
using MongoReception.Infrastructure.Repositories;
using System;

namespace MongoReception.WebApi
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
            services.Configure<ReceptionDatabaseSettings>(
                Configuration.GetSection(nameof(ReceptionDatabaseSettings)));

            services.AddSingleton<IReceptionDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<ReceptionDatabaseSettings>>().Value);

            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IBaseRepositoryProvider, BaseRepositoryProvider>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IBuildingRepository, BuildingRepository>();
            services.AddTransient<IRoomRepository, RoomRepository>();

            services.AddTransient<IBuildingService, BuildingService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IReservationService, ReservationService>();

            services.AddControllers()
                .AddNewtonsoftJson(options => options.UseMemberCasing());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MongoReception",
                    Description = "MongoReception API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    License = new OpenApiLicense
                    {
                        Name = "Use under MIT license",
                        Url = new Uri("https://www.mit.edu/~amini/LICENSE.md"),
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShareEventAPI v1.0");
            });

            // CORS
            app.UseCors(config => config
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}