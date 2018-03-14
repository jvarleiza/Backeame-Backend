using Backeame.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backeame.Data.Access
{
    public class ContextInitializer : DropCreateDatabaseIfModelChanges<BackeameContext>
    {
        protected override void Seed(BackeameContext context)
        {
            TestData.Create(context);
        }
    }
}
