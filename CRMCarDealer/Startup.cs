using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRMCarDealer.Startup))]
namespace CRMCarDealer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
