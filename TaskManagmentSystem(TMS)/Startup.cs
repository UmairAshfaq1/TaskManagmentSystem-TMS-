using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaskManagmentSystem_TMS_.Startup))]
namespace TaskManagmentSystem_TMS_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
