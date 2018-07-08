
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbishkarFoundation.Repository
{
   public class NHibernateSession
    {
        private static object HttpContext;

        //public static ISession OpenSession()
        //{
        //    var configuration = new Configuration();
        //    var configurationPath = HttpContext.Current.Server.MapPath(@"~\Models\hibernate.cfg.xml");
        //    configuration.Configure(configurationPath);
        //    var bookConfigurationFile = HttpContext.Current.Server.MapPath(@"~\Mappings\Book.hbm.xml");
        //    configuration.AddFile(bookConfigurationFile);
        //    ISessionFactory sessionFactory = configuration.BuildSessionFactory();
        //    return sessionFactory.OpenSession();
        //}
    }
}
