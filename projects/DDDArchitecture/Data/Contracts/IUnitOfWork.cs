using System;

namespace Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();

        void Commit();
    }
}
