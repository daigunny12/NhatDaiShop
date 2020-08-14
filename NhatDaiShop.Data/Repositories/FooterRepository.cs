using NhatDaiShop.Data.Infrastructure;
using NhatDaiShop.Model.Models;

namespace NhatDaiShop.Data.Repositories
{
    public interface IFooterReponsitory: IRepository<Footer>
    {
    }

    public class FooterRepository : RepositoryBase<Footer>, IFooterReponsitory
    {
        public FooterRepository(IDBFactory dBFactory) : base(dBFactory)
        {
        }
    }
}