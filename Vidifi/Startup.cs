using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidifi.Startup))]
namespace Vidifi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
