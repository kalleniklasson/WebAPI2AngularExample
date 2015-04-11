using System;
using System.Data.Entity;

namespace WebAPI2Angular.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        DbContext GetDbContext();
    }
}