using Backeame.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backeame.Business
{
    public interface ITestLogic : IBaseLogic<Test>
    {
        void Seed();
    }
}
