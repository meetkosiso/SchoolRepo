using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Eschool.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Eschool.ViewModels.Mapping;
using Eschool.Data.Abstract;
using Eschool.Data.Repositories;
using Eschool.Infrastructure;


namespace Eschool.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EschoolContext>(options =>
                options.UseSqlServer(Configuration["Data:EschoolConnection:ConnectionString"],
                b => b.MigrationsAssembly("Eschool")));

            // Add framework services.
            services.AddMvc();
            var mapping = new AutoMapper.MapperConfiguration(x =>
            {
                x.ConfigureSchoolMapping();
            });

            services.AddSingleton(x => mapping.CreateMapper());
            // Repositories
             services.AddScoped<IStudentRepository, StudentRepository >();
             services.AddScoped<ISubjectRepository, SubjectRepository>();
             services.AddScoped<IClassesRepository, ClassRepository>();
            services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder =>
               builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod());

            app.UseStaticFiles();
            app.UseExceptionHandler(
              builder =>
              {
                  builder.Run(
                    async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            context.Response.AddApplicationError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                        }
                    });
              });
          
        }
    }
}
