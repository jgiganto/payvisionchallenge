using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refactoring.FraudDetection.Application.FraudResults.Contracts;
using Refactoring.FraudDetection.Application.FraudResults.Services;
using Refactoring.FraudDetection.Application.Orders.Contracts;
using Refactoring.FraudDetection.Application.Orders.Services;

namespace Refactoring.FraudDetection.Host
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
           services.AddTransient<INormalizeOrderService, NormalizeOrderService>();
            services.AddScoped<ICheckFraudService, CheckFraudService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
