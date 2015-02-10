using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using LocaleDiary.Api.Infrastructure;
using LocaleDiary.Data.Ef;
using LocaleDiary.Data.Ef.Repositories;
using LocaleDiary.Data.Repositories;
using LocaleDiary.Services;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Serialization;
using Owin;

namespace LocaleDiary.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var httpConfig = new HttpConfiguration();
            ConfigureAuth(app);
            ConfigureWebApi(httpConfig);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(httpConfig);
        }

        private static void ConfigureWebApi(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<ILocaleRepository, LocaleRepository>(
                new HierarchicalLifetimeManager());
            container.RegisterType<LocaleDiaryContext, LocaleDiaryContext>(
                new HierarchicalLifetimeManager());
            container.RegisterType<LocaleService, LocaleService>(
                new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            config.MapHttpAttributeRoutes();

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        private void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
        }
    }
}