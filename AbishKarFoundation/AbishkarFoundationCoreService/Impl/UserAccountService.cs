using AbishkarFoundation.CoreService.Interfaces;
using AbishkarFoundation.Helper;
using AbishkarFoundation.Model;
using AbishkarFoundation.Repository.Interfaces;
using System;

namespace AbishkarFoundation.CoreService.Impl
{
    public class UserAccountService : IUserAccountService
    {
        private IUserRepository UserRepository { get; set; }
        public UserAccountService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }
        public bool SignUp(User user,string password)
        {
            if(UserRepository.GetUserByEmail(user.Email)!=null)
            {
                throw new ApplicationException("User with same email is exist");
            }
            if (UserRepository.GetUserByUserName(user.UserName) != null)
            {
                throw new ApplicationException("User with same user name is exist");
            }
            var salt = Salt.Create();
            var hash = AuthenticationHelper.Create(password, salt);
            user.Hash = hash;
            user.Salt = salt;
            UserRepository.Save(user);
            return true;
        }
    }
}
