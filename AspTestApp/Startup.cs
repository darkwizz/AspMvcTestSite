using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspTestApp.Startup))]
namespace AspTestApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
            log.Info("Startup configure\n");
        }
    }
}
