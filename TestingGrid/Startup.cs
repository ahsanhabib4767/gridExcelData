using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestingGrid.Startup))]
namespace TestingGrid
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
