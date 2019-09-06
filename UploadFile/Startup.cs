using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using UploadFile.Data.Data;
using UploadFile.Data.Repository;
using UploadFile.Data.Services;
using UploadFile.Data.ValidationRules;
using UploadFile.Filters;

namespace UploadFile
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
            services.AddDbContext<FileUploadContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Local"),
                    b => b.MigrationsAssembly("UploadFile")));

            services.AddCors();
            services.AddMvc(
                    opt => { opt.Filters.Add(typeof(ValidatorActionFilter)); })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddJsonOptions(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling =
                        ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.Formatting = Formatting.Indented;
                    options.SerializerSettings.ContractResolver =
                        new CamelCasePropertyNamesContractResolver();
                }).AddFluentValidation(fv => { fv.RegisterValidatorsFromAssemblyContaining<FileModelValidator>(); });
            services.AddScoped<IRepository, FileRepository>();
            services.AddScoped<IFileService, FileService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                        if (exceptionHandlerFeature != null)
                        {
                            var logger = loggerFactory.CreateLogger("Global exception logger");
                            logger.LogError(500,
                                exceptionHandlerFeature.Error,
                                exceptionHandlerFeature.Error.Message);
                        }

                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
                    });
                });
            }

            app.UseCors(builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}