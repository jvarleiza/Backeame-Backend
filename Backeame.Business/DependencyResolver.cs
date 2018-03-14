using Backeame.Data.Repository;
using Backeame.Resolver;
using System.ComponentModel.Composition;

namespace Backeame.Business.Implementation
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IAuth, Auth>();
            registerComponent.RegisterType<IBackerLogic, BackerLogic>();
            registerComponent.RegisterType<IProjectLogic, ProjectLogic>();
            registerComponent.RegisterType<ICollectionLogic, CollectionLogic>();
            //registerComponent.RegisterType(typeof(IBaseLogic<>), typeof(BaseLogic<>));
            //registerComponent.RegisterTypeWithControlledLifeTime<IUnitOfWork, UnitOfWork>();
        }
    }
}
