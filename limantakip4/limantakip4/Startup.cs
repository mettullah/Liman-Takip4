using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(limantakip4.StartupOwin))]

namespace limantakip4
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
