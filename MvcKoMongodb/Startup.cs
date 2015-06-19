using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcKoMongodb.Startup))]
namespace MvcKoMongodb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
