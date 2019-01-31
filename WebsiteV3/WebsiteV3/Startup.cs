using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebsiteV3.Startup))]
namespace WebsiteV3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }
    }
}
