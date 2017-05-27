using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManageMovies.Startup))]
namespace ManageMovies
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
