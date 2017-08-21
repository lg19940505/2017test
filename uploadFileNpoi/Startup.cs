using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(uploadFileNpoi.Startup))]
namespace uploadFileNpoi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
