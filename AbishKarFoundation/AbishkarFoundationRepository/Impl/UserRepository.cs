using AbishkarFoundation.Model;
using AbishkarFoundation.Repository.Interfaces;
using Microsoft.Extensions.Options;
using NHibernate;
using Ninject;

namespace AbishkarFoundation.Repository.Impl
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public User GetUserByEmail(string email)
        {
            return _session.QueryOver<User>().Where(u => u.Email == email).SingleOrDefault();
        }

        public User GetUserById(int userId)
        {
            return _session.Get<User>(userId);
        }

        public User GetUserByUserName(string userName)
        {
            return _session.QueryOver<User>().Where(u => u.UserName == userName).SingleOrDefault();
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

        public User ValidateUser(string userName)
        {
            return _session.QueryOver<User>().Where(u => u.UserName == userName || u.Email == userName).SingleOrDefault();
        }
    }
}
