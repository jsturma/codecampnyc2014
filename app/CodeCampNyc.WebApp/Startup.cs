using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeCampNyc.WebApp.Startup))]
namespace CodeCampNyc.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
