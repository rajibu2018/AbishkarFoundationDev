using AbishkarFoundation.Model;
using FluentNHibernate.Mapping;

namespace AbishkarFoundation.NhibernetMapper
{
    public class UserMapper: ClassMap<User>
    {
        public UserMapper()
        {
            Id(u => u.UserId);
            Map(u => u.FirstName).Not.Nullable();
            Map(u => u.LastName).Not.Nullable();
            Map(u => u.Email);
            Map(u => u.UserName).Not.Nullable();
            Map(u => u.Password);
            Map(u => u.DOB);
            Map(u => u.UserType).Not.Nullable();
            Map(u => u.CreatedDate).Not.Nullable();
            Map(u => u.CreatedBy);
            Map(u => u.ModifiedDate);
            Map(u => u.ModifiedBy);
            Map(u => u.LastLoginDate);

        }
    }
}
