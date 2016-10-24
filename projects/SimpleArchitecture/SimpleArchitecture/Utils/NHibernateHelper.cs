using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using System.Reflection;

namespace SimpleArchitecture.Utils
{
    public static class NHibernateHelper
    {
        public static ISession OpenSession()
        {
            return Fluently.Configure()
                .Database(PostgreSQLConfiguration.PostgreSQL82.ConnectionString(x => x.FromConnectionStringWithKey("ConnectionString")).ShowSql())
                // .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())
                .Conventions.Add(DefaultLazy.Never()))
                .BuildSessionFactory()
                .OpenSession();
        }
    }
}
