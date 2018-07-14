using AbishkarFoundation.NhibernetMapper;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Options;
using NHibernate;
using NHibernate.Cfg;
using System.Configuration;

namespace AbishkarFoundation.Repository
{
    public class RepositorySessionBase
    {
        private static AppSettings AppSettings { get; set; }
        public static string connectionString;
        public RepositorySessionBase(IOptions<AppSettings> settings)
        {
            AppSettings = settings.Value;
             connectionString = AppSettings.StrAbishkarFoundationConnection;
        }

        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                   
                    //connectionString =new DBConnection().GetConnectionString();
                    //connectionString = AppSettings.StrAbishkarFoundationConnection;//ConfigurationManager.AppSettings["StrAbishkarFoundationConnection"];
                    //var configuration = new Configuration();
                    //configuration.Configure();
                    ////configuration.AddAssembly("AbishkarFoundation.Model.School");
                    // _sessionFactory = configuration.BuildSessionFactory();
                    var configuration = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2012.ConnectionString("Server=DELL-PC\\SQLEXPRESS;Database=AbishkarFoundation;Integrated Security=True;").ShowSql)
            //.Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql)
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMapper>())
            .BuildConfiguration();
                                       

                    _sessionFactory = configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }

    public class AppSettings
    {
        public string StrAbishkarFoundationConnection { get; set; }
    }

    //public class DBConStrung
    //{
    //    private static AppSettings AppSettings { get; set; }
    //    public static string DBconnectionString;
    //    public DBConStrung(IOptions<AppSettings> setting)
    //    {
    //        AppSettings = setting.Value;
    //        DBconnectionString = AppSettings.StrAbishkarFoundationConnection;
    //    }
    //}
}
