using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrainingMVC.Startup))]
namespace TrainingMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
