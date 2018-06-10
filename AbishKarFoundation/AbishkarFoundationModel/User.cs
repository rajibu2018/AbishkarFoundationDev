using System;

namespace AbishkarFoundation.Model
{
    public class User
    {
        public virtual int UserId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime DOB { get; set; }
        public virtual UserType UserType { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual int CreatedBy { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual int ModifiedBy { get; set; }
        public virtual DateTime LastLoginDate { get; set; }



    }
}
