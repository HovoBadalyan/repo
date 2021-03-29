using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NorthWnd.Api.Middleware;
using NorthWnd.BLL.Operations;
using NorthWnd.CORE.Abstractions;
using NorthWnd.CORE.Abstractions.Operations;
using NorthWnd.CORE.Entities;
using NorthWnd.DAL;


namespace NorthWnd.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<NORTHWNDContext>(x =>
            {
                x.UseSqlServer(Configuration.GetConnectionString("default"));
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
              .AddCookie(options =>
              {
              });

            services.AddControllers();

            services.AddScoped<IRepositoryManager, RepositoryManager>();

            services.AddScoped<IOrderOperations, OrderOperations>();

            services.AddScoped<IUserOperations, UserOperations>();

            services.AddScoped<IProductOperations, ProductOperations>();

            services.AddScoped<IOrderDetailsOperations, OrderDetailsOperations>();

            services.AddScoped<IShipperOperations, ShipperOperations>();

            services.AddScoped<ISupplierOperations, SupplierOperations>();

            services.AddScoped<IRegionOperations, RegionOperations>();

            services.AddScoped<IEmployeeOperations, EmployeeOperations>();

            services.AddScoped<ICustomerOperations, CustomerOperations>();

            services.AddScoped<ICategoryOperations, CategoryOperations>();

            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI();
        }
    }
}
