using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ImageStoreASP.Startup))]
namespace ImageStoreASP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
