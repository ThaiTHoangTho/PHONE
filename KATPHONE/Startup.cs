using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KATPHONE.Startup))]
namespace KATPHONE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
