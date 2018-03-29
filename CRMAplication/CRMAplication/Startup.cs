using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRMAplication.Startup))]
namespace CRMAplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
