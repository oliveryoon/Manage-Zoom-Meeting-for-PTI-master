﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SchoolWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.AspNetCore.Mvc;


namespace SchoolWebApi
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
            // Inject default DB connection string.
            services.AddDbContext<SchoolContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAuthentication(sharedOptions =>
            {
                sharedOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddAzureAdBearer(options => Configuration.Bind("AzureAd", options));
            
            services.AddProtectWebApiWithMicrosoftIdentityPlatformV2(Configuration);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddCors();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseMvc(routeBuilder => {

            //    routeBuilder.EnableDependencyInjection();

            //    routeBuilder.Expand().Select().OrderBy().Filter();

            //});
            //exceptions for web origins for script calls.
            string[] origins = { "http://localhost:4200", "https://*.joeys.org" };
            app.UseCors(options =>
                options.WithOrigins(origins).AllowAnyMethod().AllowAnyHeader());


            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
