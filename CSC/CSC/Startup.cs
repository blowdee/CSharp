using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using SimpleInjector;
using SimpleInjector.Lifestyles;
using SimpleInjector.Integration.AspNetCore;
using SimpleInjector.Integration.AspNetCore.Mvc;

namespace CSC
{
    public class Startup
    {
        private Container _container = new Container();

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<IControllerActivator>(
                new SimpleInjectorControllerActivator(_container));
            services.AddSingleton<IViewComponentActivator>(
                new SimpleInjectorViewComponentActivator(_container));

            services.UseSimpleInjectorAspNetRequestScoping(_container);
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            InitializeContainer(app);

            _container.Register<TreeHandler>();

            _container.Verify();

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }

        private void InitializeContainer(IApplicationBuilder app)
        {
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            
            _container.RegisterMvcControllers(app);
            _container.RegisterMvcViewComponents(app);

            _container.Register<ITreeOperation, TreeOperations>(Lifestyle.Singleton);
            _container.Register<ITreeServicesFactory, TreeServicesFactory>(Lifestyle.Singleton);

            _container.RegisterSingleton(app.ApplicationServices.GetService<ILoggerFactory>());
        }
    }
}
