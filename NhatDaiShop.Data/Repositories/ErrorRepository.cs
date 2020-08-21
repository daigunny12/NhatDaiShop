using NhatDaiShop.Data.Infrastructure;
using NhatDaiShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhatDaiShop.Data.Repositories
{
    public interface IErrorRepository
    {

    }
    public class ErrorRepository: RepositoryBase<Error>,  IErrorRepository
    {
        public ErrorRepository(IDBFactory dBFactory) : base(dBFactory)
        {

        }
    }
}
