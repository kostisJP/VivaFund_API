using System.IdentityModel.Claims;
using Microsoft.Owin;
using Owin;
using VivaFund.WEB;

[assembly: OwinStartup(typeof(Startup))]
namespace VivaFund.WEB
{

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            System.Web.Helpers.AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;

            
        }
    }
}
