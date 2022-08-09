using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddlewareProject
{
    internal class CustomMiddleware
    {
        public RequestDelegate next;
        public string environment;
        public CustomMiddleware(RequestDelegate next, IWebHostEnvironment environment)
        {
            this.next = next;
            this.environment = environment.EnvironmentName;
        }
        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("this is " + environment + " Environment first time");
            string[] strArr = new string[] { "Middleware" };
            //for (int i = 0; i < strArr.Length; i++)
            //{
            //    string tempstring = strArr[4];
            //    await context.Response.WriteAsync(tempstring);
            //}
            await context.Response.WriteAsync("\nthis is " + environment + " Environment");
            await this.next(context);
        }
    }
}