using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Manager_Contact.Startup))]
namespace Manager_Contact
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
