using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAlbums.Startup))]
namespace WebAlbums
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
