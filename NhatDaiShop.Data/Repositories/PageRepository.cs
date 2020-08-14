using NhatDaiShop.Data.Infrastructure;
using NhatDaiShop.Model.Models;

namespace NhatDaiShop.Data.Repositories
{
    public interface IPageRepository : IRepository<Page>
    {
    }

    public class PageRepository : RepositoryBase<Page>, IPageRepository
    {
        public PageRepository(IDBFactory dBFactory) : base(dBFactory)
        {
        }
    }
}