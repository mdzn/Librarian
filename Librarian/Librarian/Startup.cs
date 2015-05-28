using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Librarian.Startup))]
namespace Librarian
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
