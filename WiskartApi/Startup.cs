using AutoMapper;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using WiskartApi.Extensions;
using WiskartApi.Helpers;
using WiskartApi.Middleware;

namespace WiskartApi
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddControllers();

            //sql server connection string
            //services.AddDbContext<StoreContext>(options =>
            //  options.UseSqlServer(_config.GetConnectionString("eCommerceApp")));

            //services.AddDbContext<AppIdentityDbContext>(x =>
            //x.UseSqlServer(_config.GetConnectionString("IdentityConnection")));

            //my sql connection string
            services.AddDbContext<StoreContext>(options =>
                    options.UseMySql(_config.GetConnectionString("eCommerceApp")));

            services.AddDbContext<AppIdentityDbContext>(x =>
            x.UseMySql(_config.GetConnectionString("IdentityConnection")));

            services.AddSingleton<IConnectionMultiplexer>(c =>
            {
                var configuration = ConfigurationOptions.Parse(_config.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(configuration);
            });

            services.AddApplicationServices();

            services.AddIdentityServices(_config);

            services.AddSwaggerDocumentation();

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
                });

            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSwaggerDocumentation();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
