using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ThomasSalon.UI.Startup))]
namespace ThomasSalon.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
