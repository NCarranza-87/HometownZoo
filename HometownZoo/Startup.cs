using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HometownZoo.Startup))]
namespace HometownZoo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
