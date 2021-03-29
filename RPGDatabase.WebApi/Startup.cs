using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RPGDatabase.BLL.Implementations;
using RPGDatabase.BLL.Interfaces;
using RPGDatabase.DataAccess.Context;
using RPGDatabase.DataAccess.Interfaces;
using RPGDatabase.DataAccess.Implementations;

namespace RPGDatabase.WebApi
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

            // BLL
            services.Add(new ServiceDescriptor(typeof(IItemService), typeof(ItemService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IPlayerService), typeof(PlayerService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IPlayerValidate), typeof(PlayerValidateService), ServiceLifetime.Scoped));

            // DataAccess
            services.Add(new ServiceDescriptor(typeof(IItemRepository), typeof(ItemRepository), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IPlayerRepository), typeof(PlayerRepository), ServiceLifetime.Transient));

            // DB Contexts
            services.AddDbContext<RPGContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Database")));
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

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}