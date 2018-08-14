using BLL.IRepositories;
using BLL.Repositories;
using Ninject.Modules;

namespace BLL.ServiceModule
{
    public class ServiceInjection : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IGenericRepository<>)).To(typeof(Repository<>));
        }
    }
}
