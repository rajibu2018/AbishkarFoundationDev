using AbishkarFoundation.CoreService.Interfaces;
using AbishkarFoundation.Model;
using AbishkarFoundation.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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

            UserRepository.Save(user);
            return true;
        }
    }
}
