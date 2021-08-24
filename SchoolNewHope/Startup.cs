using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SchoolNewHope.Startup))]
namespace SchoolNewHope
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
