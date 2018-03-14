using Backeame.Data.Access;
using Backeame.Data.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;

namespace Backeame.OwinManagers
{
    public class ApplicationUserManager : UserManager<Backer>
    {
        public ApplicationUserManager(IUserStore<Backer> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var appDbContext = context.Get<BackeameContext>();
            var appUserManager = new ApplicationUserManager(new UserStore<Backer>(appDbContext));

            appUserManager.UserValidator = new UserValidator<Backer>(appUserManager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            appUserManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = false,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            appUserManager.EmailService = new Services.EmailService();

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                appUserManager.UserTokenProvider = 
                    new DataProtectorTokenProvider<Backer>(
                        dataProtectionProvider.Create("ASP.NET Identity"))
                {
                    //Code for email confirmation and reset password life time
                    TokenLifespan = TimeSpan.FromHours(24)
                };
            }

            return appUserManager;
        }
    }
}
