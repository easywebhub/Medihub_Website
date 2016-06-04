using System;
using Data;


namespace RAT.Backend.Api.DAL
{
    public interface IUnitOfWorkSql : IDisposable
    {

        SqlDbContext GetDbContext();
        GenericSqlRepository<TEntity> Repository<TEntity>() where TEntity : class;
        void Save();
    }
}
