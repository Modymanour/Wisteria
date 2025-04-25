using Mapster;
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

        public string register(string name, string email, string password)// we are just first regestering so we dont need dto
        {
            var checkname = _registerchecker.Name_validator(name);
            var checkemail = _registerchecker.Email_validator(email);
            var checkpassword = _registerchecker.Password_validator(password);

            if (checkname)
            {
                if(checkemail && checkpassword)
                {
                    //complete
                }
                else if (checkemail)
                {
                    return "Password is invalid";//pasword is wrong
                }
                else if (checkpassword)
                {
                    return "Email is invalid";//email is wrong
                }
                else
                {
                    return "Both the Email & Password are invalid";//both are wrong
                }
            }
            else
            {
                return "Name is already taken";//name is already taken
            }
                var user = new User
                {
                    Name = name,
                    Email = email,
                    Password = password
                };

            _db.Users.Add(user);
            _db.SaveChanges();
            return "Complete";
        }
    }
}
