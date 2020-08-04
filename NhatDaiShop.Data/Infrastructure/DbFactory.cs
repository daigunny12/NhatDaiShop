using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhatDaiShop.Data.Infrastructure
{
    public class DBFactory : Disposable, IDBFactory
    {
        private NhatDaiShopDBContext dbContext;

        public NhatDaiShopDBContext Init()
        {
            return dbContext ?? (dbContext = new NhatDaiShopDBContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
