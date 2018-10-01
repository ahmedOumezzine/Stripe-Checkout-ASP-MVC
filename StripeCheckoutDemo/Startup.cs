using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StripeCheckoutDemo.Startup))]
namespace StripeCheckoutDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
