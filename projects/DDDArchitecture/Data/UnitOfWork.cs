using Data.Contracts;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
// using NHibernate.Tool.hbm2ddl;
using System;
using System.Reflection;

namespace Data
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private ISession session;

        private ITransaction transaction;

        public UnitOfWork()
        {
            session = Fluently.Configure()
                .Database(PostgreSQLConfiguration.PostgreSQL82.ConnectionString(x => x.FromConnectionStringWithKey("ConnectionString")).ShowSql())
                // .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())
                .Conventions.Add(DefaultLazy.Never()))
                .BuildSessionFactory()
                .OpenSession();
        }

        public void BeginTransaction()
        {
            transaction = session.BeginTransaction();
        }

        public ISession GetSession()
        {
            return session;
        }

        public void Commit()
        {
            try
            {
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
        }

        public void Dispose()
        {
            if (session != null)
            {
                session.Dispose();
                session = null;
            }
        }
    }
}
