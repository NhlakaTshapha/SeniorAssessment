using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VET_CLINIC.Startup))]
namespace VET_CLINIC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
