using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Data;
using Microsoft.Practices.ServiceLocation;



namespace RAT.Backend.Api.DAL
{
    public class UnitOfWorkMssql : IUnitOfWorkSql
    {
        private readonly SqlDbContext _contextSql;
   
        private Dictionary<string, dynamic> _repositories;

        public UnitOfWorkMssql(SqlDbContext context)
        {
            if (context == null) context = new SqlDbContext();
           
            this._contextSql = context;
           
        }
        public SqlDbContext GetDbContext()
        {
            return _contextSql;
        }

       

        public GenericSqlRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (ServiceLocator.IsLocationProviderSet)
            {
                return ServiceLocator.Current.GetInstance<GenericSqlRepository<TEntity>>();
            }

            if (_repositories == null)
            {
                _repositories = new Dictionary<string, dynamic>();
            }

            var type = typeof(TEntity).Name;
            if (_repositories.ContainsKey(type))
            {
                return (GenericSqlRepository<TEntity>)_repositories[type];
            }

            _repositories.Add(type, new GenericSqlRepository<TEntity>(_contextSql));


            return _repositories[type];
        }
        public void Save()
        {
            _contextSql.SaveChanges();
        }

        private bool disposedSql = false;


        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedSql)
            {
                if (disposing)
                {
                    _contextSql.Dispose();
                }
            }
            this.disposedSql = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}