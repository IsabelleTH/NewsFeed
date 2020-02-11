using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewsFeed.Startup))]
namespace NewsFeed
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
