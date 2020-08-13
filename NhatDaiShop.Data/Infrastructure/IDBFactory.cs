using System;

namespace NhatDaiShop.Data.Infrastructure
{
    public interface IDBFactory : IDisposable
    {
        NhatDaiShopDBContext Init();
    }
}