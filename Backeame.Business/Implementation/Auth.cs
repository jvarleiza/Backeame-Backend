using Backeame.Business;
using Backeame.Data.Repository;
using Backeame.Magic.DTOs;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace Backeame.Business.Implementation
{
    public class Auth : IAuth
    {
        protected readonly IUnitOfWork _unitOfWork;

        public Auth(IUnitOfWork uof)
        {
            this._unitOfWork = uof;
        }
        public async Task<IdentityResult> RegisterUser(RegisterBackerDTO backer)
        {
            IdentityResult result = await this._unitOfWork.AuthRepository.RegisterUser(backer);
            return result;
        }
    }
}
