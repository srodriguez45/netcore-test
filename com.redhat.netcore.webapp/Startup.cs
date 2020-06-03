using com.redhat.netcore.context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace com.redhat.netcore.webapp
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
            var SERVER = Environment.GetEnvironmentVariable("SERVER");
            var DB = Environment.GetEnvironmentVariable("DB");
            var PORT = Environment.GetEnvironmentVariable("PORT");
            var USER = Environment.GetEnvironmentVariable("USER");
            var PWD = Environment.GetEnvironmentVariable("PWD");

            var constr = $"Server={SERVER},{PORT};Database={DB};User Id={USER};password={PWD};Trusted_Connection=true;MultipleActiveResultSets=true;";
            //var connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DBApiContext>(

            options => options.UseSqlServer(constr, sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                })
            );

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
