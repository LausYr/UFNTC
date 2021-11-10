using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Syncfusion.Blazor;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Directory.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDk1OTgzQDMxMzkyZTMyMmUzMEM0d2dkamhTbmNtQzJBd2o3THh6TEx0VGlCWmhPKzViWC8zakVVY0VNOWM9");

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddSyncfusionBlazor();

            await builder.Build().RunAsync();
        }
    }
}
