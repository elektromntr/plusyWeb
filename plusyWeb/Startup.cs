using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(plusyWeb.Startup))]
namespace plusyWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
