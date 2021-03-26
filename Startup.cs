using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AilawaAPI.Data.models;
using AilawaAPI.Service;
using Microsoft.EntityFrameworkCore;

namespace AilawaAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<AilawaContext>(e => e.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IUploadCaseDetails, UploadCaseDetails>();
            services.AddTransient<IVendorDetails, VendorDetails>();
            
            services.AddCors(options => {
                options.AddPolicy("AllowAllHeaders",
                       builder => {
                           builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                       });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("AllowAllHeaders");
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
