using Mapster;
using Microsoft.AspNetCore.Identity;
using System.Net;
using Wisteria.Domain.Dtos;
using Wisteria.Domain.Entities;
using Wisteria.Service.Depend_Injections.Register;

namespace Wisteria.Service.Depend_Injections.Add
{
    public class AddUser : IUser
    {
        private readonly UserBase _db;
        private readonly RegisterChecker _registerchecker;
        public AddUser(UserBase db,RegisterChecker registerchecker)
        {
            _db = db;
            _registerchecker = registerchecker;
        }

        public User? register(UserDto u)// we are just first regestering so we dont need dto
        {
            var checkname = _registerchecker.Name_validator(u.Name);
            var checkemail = _registerchecker.Email_validator(u.Email);
            var checkpassword = _registerchecker.Password_validator(u.Password);

            if (checkname)
            {
                if(checkemail && checkpassword)
                {
                    //complete
                }
                else if (checkemail)
                {
                    return new User
                    {
                        Name = "Password is invalid"
                    };//pasword is wrong
                }
                else if (checkpassword)
                {
                    return new User
                    {
                       Name = "Email is invalid"
                    };//email is wrong
                }
                else
                {
                    return new User
                    {
                       Name = "Both the Email & Password are invalid"
                    };//both are wrong
                }
            }
            else
            {
                return new User {
                    Name = "Name is already taken"
                };//name is already taken
            }
                var user = new User
                {
                    Name = u.Name,
                    Email = u.Email,
                };
            var Password = new PasswordHasher<User>().
                    HashPassword(user, u.Password);
            user.Password = Password;
            _db.Users.Add(user);
            _db.SaveChanges();
            return user;
        }
    }
}
