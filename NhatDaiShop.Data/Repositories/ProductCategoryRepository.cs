using NhatDaiShop.Data.Infrastructure;
using NhatDaiShop.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace NhatDaiShop.Data.Repositories
{
    public interface IProductCategoryReponsitory : IRepository<ProductCategory>
    {
        IEnumerable<ProductCategory> GetByAlias(string alias);
    }

    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryReponsitory
    {
        public ProductCategoryRepository(IDBFactory dBFactory) : base(dBFactory)
        {
        }

        public IEnumerable<ProductCategory> GetByAlias(string alias)
        {
            return this.DbContext.ProductCategories.Where(x => x.Alias == alias);
        }
    }
}