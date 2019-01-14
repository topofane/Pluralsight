﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OdeToFood.Services;

namespace OdeToFood
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IMavenlinkSettings, MavenlinkSettings>();
            services.AddScoped<IRestaurantData, InMemoryRestaurantData>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMavenlinkSettings mavenlinkSettings, ILogger<Startup> logger)
        {
            //if (env.IsDevelopment())
            //{
               app.UseDeveloperExceptionPage();
            //}

            app.UseStaticFiles();
            app.UseMvc(ConfigureRoutes);


            app.Run(async (context) =>
            {
                var MavenlinkSchema = mavenlinkSettings.Schema;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync($"Not Found");
                //await context.Response.WriteAsync($"{MavenlinkSchema} : {env.EnvironmentName}");
            });
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            // /Home/Index

            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
