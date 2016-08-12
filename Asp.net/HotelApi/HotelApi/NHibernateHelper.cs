
using System.Configuration;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using HotelApi_.Entities;
using HotelApi_.Mappers;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace HotelApi_
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        private static ISession session;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    NHibernateProfiler.Initialize();
                    InitializeSessionFactory();
                }
                return _sessionFactory;
            }
        }
        private static void InitializeSessionFactory()

        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(@"Data Source=IASI-H5BP4G7;Initial Catalog=Bookings;User ID=sa;Password=1234%asd").ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<HotelMap>())
                .BuildSessionFactory();
        }
        public static ISession OpenSession()
        {
            if (session == null)
                session = SessionFactory.OpenSession();
            return session;
        }

        public static void StartSession()
        {
            session = SessionFactory.OpenSession();
        }

        public static ISession GetSession()
        {
             if (session == null)
                 session = SessionFactory.OpenSession();
             if(!session.IsOpen)
                session= SessionFactory.OpenSession();
            return session;
        }

        public static void Delete<TEntity>( ISession session, object id)
        {
            var queryString = string.Format("delete {0} where id = :id",
                                            typeof(TEntity));
            session.CreateQuery(queryString)
                   .SetParameter("id", id)
                   .ExecuteUpdate();
        }

    }
}
