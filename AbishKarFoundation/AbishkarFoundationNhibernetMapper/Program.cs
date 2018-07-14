using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Configuration;

namespace AbishkarFoundation.NhibernetMapper
{
    class Program
    {
        private static ISessionFactory _sessionFactory;

        static void Main(string[] args)
        {
            //creating database 
            string connectionString = ConfigurationManager.ConnectionStrings["strAbishkarFoundationConnection"].ConnectionString;
            CreateDatabase(connectionString);
            Console.WriteLine("Database Created sucessfully");          

           
        }

        static void CreateDatabase(string connectionString)
        {
            var configuration = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql)
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMapper>())
             .ExposeConfiguration(config =>
             {
                 new SchemaUpdate(config).Execute(false, true);
               
             })
            .BuildConfiguration();

            var exporter = new SchemaExport(configuration);
            exporter.Execute(true, true, false);

            _sessionFactory = configuration.BuildSessionFactory();
        }
    }


}
