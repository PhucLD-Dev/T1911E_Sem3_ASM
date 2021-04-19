using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LINQwithAPS.NETMVC5.Startup))]
namespace LINQwithAPS.NETMVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
