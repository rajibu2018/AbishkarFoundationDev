using AbishkarFoundation.CoreService.Interfaces;
using AbishkarFoundation.Helper;
using AbishkarFoundation.Model;
using AbishkarFoundation.Repository.Interfaces;
//using System.Security.Cryptography;
//using System.Web.Security;
namespace AbishkarFoundation.CoreService.Impl
{
    public class UserAccountService : IUserAccountService
    {
        private IUserRepository UserRepository { get; set; }
        public UserAccountService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }
        public bool SignUp(User user)
        {
            var salt = Salt.Create();
            var hash = AuthenticationHelper.Create(user.Password, salt);
            user.Hash = hash;
            user.Salt = salt;
            UserRepository.Save(user);
            return true;
        }
    }
}
