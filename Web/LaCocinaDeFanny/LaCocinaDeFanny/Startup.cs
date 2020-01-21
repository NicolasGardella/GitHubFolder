using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LaCocinaDeFanny.Startup))]
namespace LaCocinaDeFanny
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
