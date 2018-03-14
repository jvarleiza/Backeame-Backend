using Owin;
using System.Web.Mvc;
using Backeame.OwinManagers;
using Backeame.Business;
using System.Web.Http;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(Backeame.WebApi.Startup))]
namespace Backeame.WebApi
{
    public class Startup
    {
        public static HttpConfiguration HttpConfiguration { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration = new HttpConfiguration();
            Magic.Helpers.MappingHelper.CreateMappers();
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(HttpConfiguration);

            app.StartupBusiness();
            app.StartupManagers();

            // Configure OAuth server
            app.UseWebApi(HttpConfiguration);

        }
    }
}