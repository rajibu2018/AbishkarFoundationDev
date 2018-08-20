
using AbishkarFoundation.Model;
using System;

namespace AbishkarFoundation.ApiService.ResponseModel
{
    public class LoginResponse : ResponseBase
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public DateTime? DOB { get; set; }
        public UserType UserType { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public bool Active { get; set; }
    }
}
