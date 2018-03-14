using Backeame.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backeame.Business
{
    public interface ICollectionLogic
    {
        Collection Trending();

        Collection JustLaunched();

        Collection NearlyFunded();

        Collection Recommended();

        Collection PerCategory(int categoryId);

        Collection PerProjectType(ProjectType type);

    }
}
