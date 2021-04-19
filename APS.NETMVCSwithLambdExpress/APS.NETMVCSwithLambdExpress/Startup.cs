using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(APS.NETMVCSwithLambdExpress.Startup))]
namespace APS.NETMVCSwithLambdExpress
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
