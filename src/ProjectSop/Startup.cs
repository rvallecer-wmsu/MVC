using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectSop.Startup))]
namespace ProjectSop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
