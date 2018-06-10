using AbishkarFoundationModel;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbishkarFoundationNhibernetMapper
{
    public class UserMapper: ClassMap<User>
    {
        public UserMapper()
        {
            Id(u => u.UserId);
            Map(u => u.FirstName);
            Map(u => u.LastName);
            Map(u => u.Email);
            Map(u => u.UserName);
            Map(u => u.Password);
            Map(u => u.DOB);
            Map(u => u.UserType);
            Map(u => u.CreatedDate);
            Map(u => u.CreatedBy);
            Map(u => u.ModifiedDate);
            Map(u => u.ModifiedBy);


        }
    }
}
