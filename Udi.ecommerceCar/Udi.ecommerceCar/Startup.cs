using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Udi.ecommerceCar.Startup))]
namespace Udi.ecommerceCar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
