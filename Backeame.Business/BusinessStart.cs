using Backeame.Data.Repository;
using Owin;

namespace Backeame.Business
{
    /// <summary>
    /// Class used to extend Startup of WebApi in Business layer
    /// </summary>
    public static class BusinessStart
    {
        /// <summary>
        /// Configures the web app on startup
        /// </summary>
        /// <param name="app">Owin context</param>
        public static void StartupBusiness(this IAppBuilder app)
        {
            app.StartupRepository();
        }
    }
}
