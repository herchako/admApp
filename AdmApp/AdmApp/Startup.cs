using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdmApp.Startup))]
namespace AdmApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
