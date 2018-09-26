using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlogASP.Startup))]
namespace BlogASP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
