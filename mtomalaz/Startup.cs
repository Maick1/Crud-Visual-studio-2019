using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mtomalaz.Startup))]
namespace mtomalaz
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
