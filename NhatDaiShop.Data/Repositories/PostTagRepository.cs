using NhatDaiShop.Data.Infrastructure;
using NhatDaiShop.Model.Models;

namespace NhatDaiShop.Data.Repositories
{
    public interface IPostTagRepository : IRepository<PostTag>
    {
    }

    public class PostTagRepository : RepositoryBase<PostTag>, IPostTagRepository
    {
        public PostTagRepository(IDBFactory dBFactory) : base(dBFactory)
        {
        }
    }
}