using NhatDaiShop.Data.Infrastructure;
using NhatDaiShop.Model.Models;

namespace NhatDaiShop.Data.Repositories
{
    public interface IErrorRepository: IRepository<Error>
    {
    }

    public class ErrorRepository : RepositoryBase<Error>, IErrorRepository
    {
        public ErrorRepository(IDBFactory dBFactory) : base(dBFactory)
        {
        }
    }
}