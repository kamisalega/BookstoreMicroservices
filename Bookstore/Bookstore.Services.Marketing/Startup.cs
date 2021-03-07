using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Services.Marketing.DbContexts;
using Bookstore.Services.Marketing.Repositories;
using Bookstore.Services.Marketing.Services;
using Bookstore.Services.Marketing.Worker;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Bookstore.Services.Marketing
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

            services.AddHostedService<TimedBasketChangeBookService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //singleton DbContext for timed worker
            var optionsBuilder = new DbContextOptionsBuilder<MarketingDbContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

            services.AddSingleton(new BasketChangeBookRepository(optionsBuilder.Options));


            services.AddScoped<IBasketChangeBookRepository, BasketChangeBookRepository>();

            services.AddHttpClient<IBasketChangeBookService, BasketChangeBookService>(c =>
                c.BaseAddress = new Uri(Configuration["ApiConfigs:ShoppingBasket:Uri"]));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Bookstore.Services.Marketing", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bookstore.Services.Marketing v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
