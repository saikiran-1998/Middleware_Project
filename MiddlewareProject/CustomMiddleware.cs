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
            await context.Response.WriteAsync("this is " + environment+" Environment");
            await this.next(context);
        }
    }
}