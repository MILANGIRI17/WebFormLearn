using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using LearnWebForm.Domain;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace LearnWebForm.Helper
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSesionFactory();
                return _sessionFactory;
            }
        }

        private static void InitializeSesionFactory()
        {
            _sessionFactory = Fluently.Configure()
                            .Database(
                                MsSqlConfiguration.MsSql2008.ConnectionString(@"Server")
                                .ShowSql())
                            .Mappings(m =>
                             m.FluentMappings.AddFromAssemblyOf<Customer>())
                            .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                            .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}