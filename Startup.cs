using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StackOverFlowProject.Startup))]
namespace StackOverFlowProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
