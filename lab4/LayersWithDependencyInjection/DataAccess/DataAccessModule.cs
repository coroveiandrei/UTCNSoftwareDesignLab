using DataAccess.Contracts.Services;
using DataAccess.Repositories;
using Microsoft.Practices.Unity;
using Prism.Modularity;

namespace DataAccess
{
    public class DataAccessModule: IModule
    {
        readonly IUnityContainer _container;
        public DataAccessModule(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<IBookRepository, BookRepository>();
        }
    }
}
