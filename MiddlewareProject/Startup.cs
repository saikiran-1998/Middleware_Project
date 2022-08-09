using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareProject
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        //{
        //    //if (env.IsDevelopment())
        //    //{
        //    //    app.UseDeveloperExceptionPage();
        //    //}

        //    // app.UseRouting();
        //    // app.UseDefaultFiles(); //displays default.html or index.html on root request 
        //    app.UseStaticFiles(); // will work for static files present in wwwroot folder
        //                          // app.UseFileServer(); // combines the functionalities of UseDefaultFiles and UseStaticFiles middlware.
        //    app.UseStaticFiles(new StaticFileOptions() // will work for static files present in folders other than wwwroot folder
        //    {
        //        FileProvider = new PhysicalFileProvider(
        //                   Path.Combine(Directory.GetCurrentDirectory()/*, @"Properties"*/)),
        //        //RequestPath = new PathString("/app-images")
        //    });
        //    // app.UseMiddleware<CustomMiddleware>();
        //    app.Use(async (context, next) =>
        //    {
        //        //await context.Response.WriteAsync("\nmiddleware that can pass request to next middleware");
        //        await context.Response.WriteAsync("\nmiddleware 1 before next");
        //        string[] strArr = new string[] { "Middleware" };
        //        for (int i = 0; i <= strArr.Length; i++)
        //        {
        //            //string tempstring = strArr[i];
        //            // await context.Response.WriteAsync("\n" + tempstring);
        //        }

        //        await context.Response.WriteAsync("\nmiddleware 1 after next");
        //        await next();

        //        await context.Response.WriteAsync("\nmiddleware 1 after next");
        //    });
        //    app.Use(async (context, next) =>
        //    {
        //        //await context.Response.WriteAsync("\nmiddleware that can pass request to next middleware");
        //        await context.Response.WriteAsync("\nmiddleware 2 before next");
        //        await next();
        //        await context.Response.WriteAsync("\nmiddleware 2 after next");
        //    });
        //    app.Run(async (context) =>
        //   {
        //       throw new Exception("There is an exception");
        //       await context.Response.WriteAsync("\nterminal middleware");
        //   });
        //    //app.Use(async (context, next) =>
        //    //{
        //    //    //await context.Response.WriteAsync("\nmiddleware that can pass request to next middleware");
        //    //    await context.Response.WriteAsync("\nmiddleware 3 before next");
        //    //    await next();
        //    //    await context.Response.WriteAsync("\nmiddleware 4 after next");
        //    //});

        //    //app.UseEndpoints(endpoints =>
        //    //{
        //    //    endpoints.MapGet("/", async context =>
        //    //    {
        //    //        await context.Response.WriteAsync("Hello World!");
        //    //    });
        //    //});
        //}
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            app.UseStaticFiles();

            //app.UseMiddleware<CustomMiddleware>();
            app.Use(async (context, next) =>
            {
                //await context.Response.WriteAsync("\nmiddleware 1 before next");
                string[] strArr = new string[] { "Middleware" };
                for (int i = 0; i <= strArr.Length; i++)
                {
                    string tempstring = strArr[i];
                    // await context.Response.WriteAsync("\n" + tempstring);
                }
                await next();
                // await context.Response.WriteAsync("\nmiddleware 1 after next");
            });
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("\nmiddleware 2 before next");
                await next();
                await context.Response.WriteAsync("\nmiddleware 2 after next");
            });
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("\nterminal middleware 1");
            });
            app.Run(async (context) =>
            {
                //throw new Exception("There is an exception");
                await context.Response.WriteAsync("\nterminal middleware");
            });
            //app.Use(async (context, next) =>
            //{
            //    //await context.Response.WriteAsync("\nmiddleware that can pass request to next middleware");
            //    await context.Response.WriteAsync("\nmiddleware 3 before next");
            //    await next();
            //    await context.Response.WriteAsync("\nmiddleware 4 after next");
            //});
        }
    }
}
