using Backeame.Data.Entities;
using Backeame.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backeame.Business.Implementation
{
    public class TestLogic : BaseLogic<Test>, ITestLogic
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="uof">Inject unit of work</param>
        public TestLogic(IUnitOfWork uof)
            : base(uof)
        {
            var x = uof;
        }

        public void Seed()
        {
            this._unitOfWork.Seed();
        }
    }
}
