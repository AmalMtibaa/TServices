using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PuProject.Startup))]
namespace PuProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }
    }
}
