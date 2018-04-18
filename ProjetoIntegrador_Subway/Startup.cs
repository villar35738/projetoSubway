using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetoIntegrador_Subway.Startup))]
namespace ProjetoIntegrador_Subway
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
