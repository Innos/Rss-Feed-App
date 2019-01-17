using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RssFeed.Web.Startup))]
namespace RssFeed.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
