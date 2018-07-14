using AbishkarFoundation.Model;

namespace AbishkarFoundation.Repository.Interfaces
{
    public interface IUserRepository
    {
        User Save(User user);
        User GetUserById(int userId);
        User GetUserByEmail(string email);
        User GetUserByUserName(string userName);
        User ValidateUser(string userName);
    }
}
