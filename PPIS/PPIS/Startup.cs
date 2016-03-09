using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PPIS.Startup))]
namespace PPIS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
