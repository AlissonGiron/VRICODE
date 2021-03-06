﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VRICODE.Core;
using VRICODE.Data;
using VRICODE.Interfaces.Core;
using VRICODE.Interfaces.Data;

namespace VRICODE
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromDays(10);
                options.Cookie.HttpOnly = true;
            });

            string LConnectionString = Configuration.GetConnectionString("Default");

            services.AddDbContext<VRICODEContext>(options => options.UseSqlServer(LConnectionString));

            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<IProblemClassRepository, ProblemClassRepository>();
            services.AddScoped<IProblemRepository, ProblemRepository>();
            services.AddScoped<IProblemTestRepository, ProblemTestRepository>();
            services.AddScoped<IProblemUserRepository, ProblemUserRepository>();
            services.AddScoped<IUserClassRepository, UserClassRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IClassCore, ClassCore>();
            services.AddScoped<IProblemClassCore, ProblemClassCore>();
            services.AddScoped<IProblemCore, ProblemCore>();
            services.AddScoped<IProblemTestCore, ProblemTestCore>();
            services.AddScoped<IProblemUserCore, ProblemUserCore>();
            services.AddScoped<IUserClassCore, UserClassCore>();
            services.AddScoped<IUserCore, UserCore>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Não vai pra europa esse site
            // app.UseCookiePolicy();

            DbContextOptionsBuilder<VRICODEContext> LOptionsBuilder = new DbContextOptionsBuilder<VRICODEContext>();
            LOptionsBuilder.UseSqlServer(Configuration.GetConnectionString("Default"));

            using (VRICODEContext LContext = new VRICODEContext(LOptionsBuilder.Options))
            {
                LContext.Database.Migrate();
            }

            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Index}/{id?}");
            });

        }
    }
}
