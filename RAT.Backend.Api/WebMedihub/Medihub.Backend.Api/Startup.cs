using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Medihub.Backend.Api.Startup))]
namespace Medihub.Backend.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
