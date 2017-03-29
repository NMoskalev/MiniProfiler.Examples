using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MiniProfile.Examples.Startup))]
namespace MiniProfile.Examples
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
