using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(web_app.Startup))]
namespace web_app
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
