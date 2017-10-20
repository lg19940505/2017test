using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(npoiWeb.Startup))]
namespace npoiWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
