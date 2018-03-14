using Backeame.Data.Access;
using Backeame.Data.Entities;
using Backeame.Data.Repository;
using Backeame.Magic.DTOs;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;

namespace Backeame.Data.Repository.Implementation
{
    public class AuthRepository : IDisposable, IAuthRepository
    {
        private BackeameContext _ctx;

        private UserManager<Backer> _userManager;

        public AuthRepository(BackeameContext ctx)
        {
            _ctx = ctx;
            _userManager = new UserManager<Backer>(new UserStore<Backer>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(RegisterBackerDTO backer)
        {
            Backer user = new Backer
            {
                UserName = backer.UserName
            };

            var result = await _userManager.CreateAsync(user, backer.Password);

            return result;
        }

        public async Task<Backer> FindUser(string userName, string password)
        {
            Backer user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}