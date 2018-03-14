using Backeame.Data.Access;
using Owin;

namespace Backeame.Data.Repository
{
    /// <summary>
    /// Class used to extend Startup of Business layer in Repository layer
    /// </summary>
    public static class RepositoryStart
    {
        /// <summary>
        /// Configures the web app on startup
        /// </summary>
        /// <param name="app">Owin context</param>
        public static void StartupRepository(this IAppBuilder app)
        {
            app.CreatePerOwinContext(BackeameContext.Create);
        }
    }
}
