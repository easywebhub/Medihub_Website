using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RAT.Backend.Api.Startup))]
namespace RAT.Backend.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
