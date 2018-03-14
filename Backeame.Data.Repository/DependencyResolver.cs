using Backeame.Data.Repository;
using Backeame.Resolver;
using System.ComponentModel.Composition;

namespace Backeame.Data.Repository.Implementation
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IUnitOfWork, UnitOfWork>();            
        }
    }
}
