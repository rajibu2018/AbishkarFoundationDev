﻿using AbishkarFoundation.Model;

namespace AbishkarFoundation.CoreService.Interfaces
{
   public interface IUserAccountService
    {
        bool SignUp(User user,string password);
    }
}
