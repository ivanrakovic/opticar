using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Opticar.Startup))]
namespace Opticar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
