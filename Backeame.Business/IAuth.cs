using Backeame.Magic.DTOs;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace Backeame.Business
{
    public interface IAuth
    {
        /// <summary>
        /// Register a new user.
        /// </summary>
        /// <param name="backer"></param>
        /// <returns></returns>
        Task<IdentityResult> RegisterUser(RegisterBackerDTO backer);
    }
}
