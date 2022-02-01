using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChildcareScouter.Startup))]
namespace ChildcareScouter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
