using NhatDaiShop.Data.Infrastructure;
using NhatDaiShop.Model.Models;

namespace NhatDaiShop.Data.Repositories
{
    public interface IMenuGroupRepository : IRepository<MenuGroup>
    {
    }

    public class MenuGroupRepository : RepositoryBase<MenuGroup>, IMenuGroupRepository
    {
        public MenuGroupRepository(IDBFactory dBFactory) : base(dBFactory)
        {
        }
    }
}