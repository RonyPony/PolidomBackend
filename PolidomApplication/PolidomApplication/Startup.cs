using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polidom.Core.Contracts;
using Polidom.Core.Interfaces;
using Polidom.Data.Data;
using Polidom.Data.Data.identity;
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
            services.AddControllers().AddNewtonsoftJson(options =>
          options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen();
            services.AddDbContext<PolidomContext>(context => 
            context.UseSqlServer(Configuration.GetConnectionString("DefaultConnections") ,
            b => b.MigrationsAssembly("Polidom.Data")));
            services.AddTransient<IReportRepository, ReportRepository>();
            services.AddTransient<ILocationInfoRepository, LocationInfoRepository>();
            services.AddTransient<IReportService, ReportService>();
            services.AddTransient<IPhotoService, PhotoService>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddIdentity<Account, IdentityRole>(opt =>
           {
               opt.Password.RequireDigit = true; 
               opt.Password.RequireLowercase = false; 
               opt.Password.RequireUppercase = false; 
               opt.Password.RequireNonAlphanumeric = false; 
               opt.Password.RequiredLength = 10; 
               opt.User.RequireUniqueEmail = true;
           }).AddDefaultTokenProviders()
             .AddEntityFrameworkStores<PolidomContext>();

            services.AddAuthentication();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(swagger => {
                swagger.SwaggerEndpoint("/swagger/v1/swagger.json" , "Polidom API V1");
                swagger.RoutePrefix = string.Empty;
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
