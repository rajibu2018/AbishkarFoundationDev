using AbishkarFoundation.Model;
using AbishkarFoundation.Repository.Interfaces;
using Microsoft.Extensions.Options;
using NHibernate;
using Ninject;

namespace AbishkarFoundation.Repository.Impl
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        //private readonly ISession _session;
        //private AppSettings AppSettings { get; set; }
        
        //public UserRepository(IOptions<AppSettings> settings) : base(settings)
        //{
        //}

        public User GetUserById(int userId)
        {
            
            return _session.Get<User>(userId);
            //using (RepositoryBase repository = new RepositoryBase())
            //{               
            //     return   _session.        
            //}\
            //using (var portalSession = _session.OpenSession())
            //{
            // return   portalSession.Get<User>(userId);
            //}
        }

        public User Save(User user)
        {
            using (RepositoryBase repository = new RepositoryBase())
            {
                try
                {
                    repository.BeginTransaction();
                    _session.SaveOrUpdate(user);
                    repository.CommitTransaction();
                }
                catch
                {
                    repository.RollbackTransaction();
                }
            }
            return user;
        }
    }
}
