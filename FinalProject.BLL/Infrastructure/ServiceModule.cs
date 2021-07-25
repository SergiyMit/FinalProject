using FinalProject.DAL.Interfaces;
using FinalProject.DAL.Repositories;
using Ninject.Modules;

namespace FinalProject.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>();
        }
    }
}
