using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Bizentro.BlazorApp.Swbiz.Data;
using Blazored.Modal;
using System.Globalization;
using Bizentro.BlazorApp.Swbiz.Services;
using Microsoft.AspNetCore.Components.Authorization;

namespace Bizentro.BlazorApp.Swbiz
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddOptions();
           // services.AddAuthorizationCore();

            services.AddControllers();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>(); // ���� ���߿� ����
            
            services.AddScoped<SwbizAuthStateProvider>();
            services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<SwbizAuthStateProvider>());
            //services.AddScoped<AuthenticationStateProvider, SwbizAuthStateProvider>();
            services.AddBlazoredModal(); // ��� �߰�
            #region >> // �ٱ��� �߰�
            services.AddLocalization(options => options.ResourcesPath = "Resources");


            var supportedCultures = new List<CultureInfo> { new CultureInfo("en-US"), 
                new CultureInfo("ko-KR"),
                new CultureInfo("vi-VN")};
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US");
                options.SupportedUICultures = supportedCultures;
            });
            #endregion
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseRequestLocalization(); // �ٱ���
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // ����
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
