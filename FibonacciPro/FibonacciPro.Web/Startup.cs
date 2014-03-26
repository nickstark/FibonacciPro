using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FibonacciPro.Web.Startup))]
namespace FibonacciPro.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
