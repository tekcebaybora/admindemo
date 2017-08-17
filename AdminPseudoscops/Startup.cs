using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdminPseudoscops.Startup))]

namespace AdminPseudoscops
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}