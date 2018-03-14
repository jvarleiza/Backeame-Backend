using Backeame.Magic.DTOs;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace Backeame.Data.Repository
{
    public interface IAuthRepository
    {
        Task<IdentityResult> RegisterUser(RegisterBackerDTO backer);
    }
}
