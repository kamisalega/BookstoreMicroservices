using AutoMapper;
using Bookstore.Services.BookCatalog.DbContexts;
using Bookstore.Services.BookCatalog.Repositories;
using Bookstore.Services.BookCatalog.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Services.BookCatalog
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(setupActions => { setupActions.ReturnHttpNotAcceptable = true; })
                .AddXmlDataContractSerializerFormatters()
                .ConfigureApiBehaviorOptions(setupAction =>
                    {
                        setupAction.InvalidModelStateResponseFactory = context =>
                        {
                            var problemDetails = new ValidationProblemDetails(context.ModelState)
                            {
                                Type = "https://library.com/modelvalidationproblem",
                                Title = "One more validation errors occurred.",
                                Status = StatusCodes.Status422UnprocessableEntity,
                                Detail = "See the errors property for details.",
                                Instance = context.HttpContext.Request.Path
                            };

                            problemDetails.Extensions.Add("traceId", context.HttpContext.TraceIdentifier);

                            return new UnprocessableEntityObjectResult(problemDetails)
                            {
                                ContentTypes = {"application/problem+json"}
                            };
                        };
                    }
                );
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:44339",
                            "https://localhost:44390");
                    });
            });
            services.AddDbContext<BookCatalogDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBookRepository, BookRepository>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Book Catalog API", Version = "v1"});
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


            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Book Catalog API V1"); });

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
