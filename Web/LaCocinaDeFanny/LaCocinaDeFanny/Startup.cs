using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.Twitter;
using Owin;
using System.Configuration;

[assembly: OwinStartupAttribute(typeof(LaCocinaDeFanny.Startup))]
namespace LaCocinaDeFanny
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
        //public void Configuration(IAppBuilder app)
        //{
        //    app.UseCookieAuthentication(new CookieAuthenticationOptions
        //    {
        //        AuthenticationType = "Cookie",
        //        LoginPath = new PathString("/Account/Login")
        //    });
        //    app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
        //    //app.UseTwitterAuthentication(new TwitterAuthenticationOptions
        //    //{
        //    //    ConsumerKey = "",
        //    //    ConsumerSecret = ""
        //    //});
        //    //app.UseGoogleAuthentication();
        //    app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions
        //    {
        //        ClientId = "929017837921-845fdcuaufhlf71s6oeojtfre5j7s5c4.apps.googleusercontent.com",
        //        ClientSecret = "0XRLd16rfCfGta3TZZUZ0YuU"
        //    });
        //}
    }
}
