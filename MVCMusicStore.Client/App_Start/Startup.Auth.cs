using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using MVCMusicStore.Client.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Autofac;
using MVCMusicStore.Infrastructure.EF;
using MVCMusicStore.Infrastructure.Repositories;
using MVCMusicStore.Core.Models;
using MVCMusicStore.Infrastructure.Service;
using Microsoft.Owin.Security;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using System.Web;

namespace MVCMusicStore.Client
{
    public partial class Startup
    {
        // Aby uzyskać więcej informacji o konfigurowaniu uwierzytelniania, odwiedź stronę https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            // REGISTER DEPENDENCIES
            builder.RegisterType<MVCMusicStoreDBContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationUserStore>().As<IUserStore<ApplicationUser>>().InstancePerRequest();
            builder.RegisterType<RoleStore<IdentityRole>>().As<IRoleStore<IdentityRole, string>>().InstancePerRequest();
            builder.RegisterType<RoleManager<IdentityRole>>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();

            // REGISTER CONTROLLERS SO DEPENDENCIES ARE CONSTRUCTOR INJECTED
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // BUILD THE CONTAINER
            var container = builder.Build();

            // REPLACE THE MVC DEPENDENCY RESOLVER WITH AUTOFAC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            // REGISTER WITH OWIN
            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Umożliwia aplikacji weryfikowanie znacznika zabezpieczeń podczas logowania się użytkownika.
                    // Jest to funkcja zabezpieczeń używana w przypadku zmiany hasła lub dodawania logowania zewnętrznego do konta.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });            
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Umożliwia aplikacji tymczasowe przechowywanie informacji o użytkownikach, gdy używają drugiego etapu w procesie uwierzytelniania dwuetapowego.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Umożliwia aplikacji zapamiętanie drugiego etapu uwierzytelniania logowania, takiego jak numer telefonu lub adres e-mail.
            // Jeśli zaznaczysz tę opcję, drugi etap weryfikacji w procesie logowania zostanie zapamiętany na urządzeniu, na którym się zalogowano.
            // Ta opcja działa podobnie do opcji RememberMe podczas logowania.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Usuń znaczniki komentarza z poniższych wierszy, aby włączyć logowanie przy użyciu innych dostawców logowania
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }
    }
}