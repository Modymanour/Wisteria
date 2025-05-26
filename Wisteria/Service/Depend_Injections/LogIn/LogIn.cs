using Microsoft.AspNetCore.Identity;
using Wisteria.Domain.Dtos;
using Wisteria.Domain.Entities;

namespace Wisteria.Service.Depend_Injections.LogIn
{
    public class LogIn : ILogIn
    {
        private readonly UserBase _db;
        public LogIn(UserBase db)
        {
            _db = db;
        }

        public User? Login(UserDtoLogin _u)
        {
            bool emailCond = false;
            if (_u == null)
            {
                return null;
            }
            if (_u.Email != null && _u.Email != "")
            {
                emailCond = true;
            }
            if (emailCond)
            {
                var user = (from u in _db.Users
                            where u.Email == _u.Email
                            select u).FirstOrDefault();
                if (user == null)
                {
                    return new User
                    {
                        Name = "notfound"
                    };
                }
                else
                {
                    if (new PasswordHasher<User>().VerifyHashedPassword(user, user.Password, _u.Password)
                    == PasswordVerificationResult.Success)
                    {
                        return user;
                    }
                    return new User
                    {
                        Name = "WrongPassword"
                    };
                }
            }
            else
            {
                return null;
            }
        }
    }
}
