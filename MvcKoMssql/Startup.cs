using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcKo.Startup))]
namespace MvcKo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
