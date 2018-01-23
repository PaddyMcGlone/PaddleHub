using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PaddleHub.Startup))]
namespace PaddleHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
