using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Udi.ecommerceCar.API.Startup))]
namespace Udi.ecommerceCar.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
