using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppRestaurant.Startup))]
namespace AppRestaurant
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
