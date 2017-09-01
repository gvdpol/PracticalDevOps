// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PartsUnlimited.Areas.Admin;
using PartsUnlimited.Models;
using PartsUnlimited.Data;
using PartsUnlimited.Queries;
using PartsUnlimited.Recommendations;
using PartsUnlimited.Search;
using PartsUnlimited.Services;
using PartsUnlimited.Telemetry;
using PartsUnlimited.WebsiteConfiguration;
using System;

namespace PartsUnlimited
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. 
        /// Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // If this type is present - we're on mono
            var runningOnMono = Type.GetType("Mono.Runtime") != null;

            var sqlConnectionString = Configuration.GetConnectionString("DefaultConnection");
            var useInMemoryDatabase = string.IsNullOrWhiteSpace(sqlConnectionString);

            // Add Entity Framework services to the services container
            if (useInMemoryDatabase || runningOnMono)
            {
                services.AddDbContext<PartsUnlimitedContext>(options =>
                {
                    string databaseName = "PartsUnlimitedDB";
                    options.UseInMemoryDatabase(databaseName);
                    // options.UseInMemoryDatabase();
                });
            }
            else
            {
                services.AddDbContext<PartsUnlimitedContext>(options =>
                {
                    options.UseSqlServer(sqlConnectionString);
                });
            }

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<PartsUnlimitedContext>()
                .AddDefaultTokenProviders();

            // Configure admin policies
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy(AdminConstants.Role, authBuilder => 
                  { authBuilder.RequireClaim(AdminConstants.ManageStore.Name, AdminConstants.ManageStore.Allowed);} );
            });

            // Add implementations
            services.AddSingleton<IMemoryCache, MemoryCache>();
            services.AddScoped<IOrdersQuery, OrdersQuery>();
            services.AddScoped<IRaincheckQuery, RaincheckQuery>();
            services.AddSingleton<ITelemetryProvider, EmptyTelemetryProvider>();
            services.AddScoped<IProductSearch, StringContainsProductSearch>();
            services.AddScoped<IPartsUnlimitedContext>(provider => provider.GetService<PartsUnlimitedContext>());

            SetupRecommendationService(services);

            services.AddScoped<IWebsiteOptions>(p =>
            {
                ITelemetryProvider telemetry = p.GetRequiredService<ITelemetryProvider>();

                return new ConfigurationWebsiteOptions(
                    Configuration.GetSection("WebsiteOptions"), telemetry);
            });

            services.AddScoped<IApplicationInsightsSettings>(p =>
            {
                return new ConfigurationApplicationInsightsSettings(
                    Configuration.GetSection(ConfigurationPath.Combine("Keys", "ApplicationInsights")));
            });

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            // We need access to these settings in a static extension method, so DI does not help us :(
            ContentDeliveryNetworkExtensions.Configuration = new ContentDeliveryNetworkConfiguration(Configuration.GetSection("CDN"));

            // Add framework services.
            // services.AddApplicationInsightsTelemetry(Configuration); // probably not needed

            // Add MVC services to the services container
            services.AddMvc();

            // Add InMemoryCache
            // services.AddSingleton<IMemoryCache, MemoryCache>();

            // Add session related services.
            // services.AddCaching();
            services.AddSession();
        }

        private void SetupRecommendationService(IServiceCollection services)
        {
            var azureMlConfig = 
                new AzureMLFrequentlyBoughtTogetherConfig(
                    Configuration.GetSection(ConfigurationPath.Combine("Keys", "AzureMLFrequentlyBoughtTogether")));

            // If keys are not available for Azure ML recommendation service, register an empty recommendation engine
            if (string.IsNullOrEmpty(azureMlConfig.AccountKey) || string.IsNullOrEmpty(azureMlConfig.ModelName))
            {
                services.AddSingleton<IRecommendationEngine, EmptyRecommendationsEngine>();
            }
            else
            {
                services.AddSingleton<IAzureMLAuthenticatedHttpClient, AzureMLAuthenticatedHttpClient>();
                services.AddSingleton<IAzureMLFrequentlyBoughtTogetherConfig>(azureMlConfig);
                services.AddScoped<IRecommendationEngine, AzureMLFrequentlyBoughtTogetherRecommendationEngine>();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
#pragma warning disable CS0612 // Type or member is obsolete
            app.UseApplicationInsightsRequestTelemetry(); // is obsolete
            app.UseApplicationInsightsExceptionTelemetry(); // is obsolete
#pragma warning restore CS0612 // Type or member is obsolete

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // Configure Session.
            app.UseSession();

            app.UseStaticFiles();

            // Add cookie-based authentication to the request pipeline
            app.UseAuthentication();

            // Add login providers (Microsoft/AzureAD/Google/etc).  This must be done after `app.UseIdentity()`
            //app.AddLoginProviders(new ConfigurationLoginProviders(Configuration.GetSection("Authentication")));

            // Add MVC to the request pipeline
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller}/{action}",
                    defaults: new { action = "Index" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });

                routes.MapRoute(
                    name: "api",
                    template: "{controller}/{id?}");
            });

            // Populates the PartsUnlimited sample data
            SampleData.InitializePartsUnlimitedDatabaseAsync(app.ApplicationServices).Wait();
        }
    }
}
