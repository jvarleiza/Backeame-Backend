using Backeame.Business;
using Backeame.Data.Entities;
using Backeame.Data.Repository;

namespace Backeame.Business.Implementation
{
    /// <summary>
    /// Implementation of backer business logic
    /// </summary>
    public class BackerLogic : IBackerLogic
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="unitOfWork">Injection of unit of work</param>
        public BackerLogic(IUnitOfWork unitOfWork)
        {
        }
    }
}
