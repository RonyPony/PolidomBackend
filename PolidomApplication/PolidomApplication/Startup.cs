using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polidom.Core.Contracts;
using Polidom.Core.Interfaces;
using Polidom.Data.Data;
using Polidom.Data.Repository;
using Polidom.Data.Services;

namespace PolidomApplication
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
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<PolidomContext>(context => 
            context.UseSqlServer(Configuration.GetConnectionString("DefaultConnections") ,
            b => b.MigrationsAssembly("PolidomApplication")));
            services.AddTransient<IReportRepository, ReportRepository>();
            services.AddTransient<ILocationInfoRepository, LocationInfoRepository>();
            services.AddTransient<IReportService, ReportService>();
            services.AddTransient<ILocationService, LocationService>();
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
