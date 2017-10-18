using System.IO;
using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OdeToCode.AddFeatureFolders;

namespace KnockOut
{
    public class Startup
    {
        public static void Main()
        {
            WebHost.CreateDefaultBuilder()
                   .UseStartup<Startup>()
                   .Build()
                   .Run();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var featureOptions = new FeatureFolderOptions
            {
                DeriveFeatureFolderName = model =>
                {
                    var @namespace = model.ControllerType.Namespace;
                    var result = @namespace.Split('.')
                                           .SkipWhile(s => s != "App")
                                           .Aggregate("", Path.Combine);

                    return Path.Combine(result, model.RouteValues.Any() ? model.RouteValues.First().Key : "Index");
                },
                FeatureFolderName = "App"
            };
            
            services.AddMvc().AddFeatureFolders(featureOptions);
            services.AddNodeServices();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}