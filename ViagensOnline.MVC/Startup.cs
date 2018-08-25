using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(ViagensOnline.MVC.Startup))]

namespace ViagensOnline.MVC
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Para obter mais informações sobre como configurar seu aplicativo, visite https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCookieAuthentication(
                new CookieAuthenticationOptions()
                {
                    AuthenticationType = "ViagensOnlineCookieAuth",
                    LoginPath = new PathString("/Admin/Login/Index")
                }
                );

        }
    }
}
