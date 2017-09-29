using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(npoi.Startup))]
namespace npoi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
