using AbishkarFoundation.Model;

namespace AbishkarFoundation.Repository.Interfaces
{
    public interface IUserRepository
    {
        User Save(User user);
        User GetUserById(int userId);
    }
}
