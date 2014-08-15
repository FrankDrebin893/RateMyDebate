using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RateMyDebate.Startup))]
namespace RateMyDebate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
