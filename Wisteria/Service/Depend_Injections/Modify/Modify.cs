using Wisteria.Domain.Entities;
using Wisteria.Service.Depend_Injections.Register;

namespace Wisteria.Service.Depend_Injections.Modify
{
    public class Modify : ModifyUser
    {
        private readonly UserBase _db;
        private readonly RegisterChecker _registerchecker;
        public Modify(UserBase db,RegisterChecker registerchecker)
        {
            _db = db;
            _registerchecker = registerchecker;
        }
        public string Modifyname(int id, string name)
        {
            var user = (from u in _db.Users
                        where u.User_ID == id
                        select u).FirstOrDefault();// write first or default to return it as an instance not ennumeruble table
            if (!_registerchecker.Name_validator(name))
            {
                return "Name is already taken";
            }
            user.Name = name;
            _db.SaveChanges();
            return "Complete";
        }
        public string ModifyEmail(int id, string email)
        {
            var user = (from u in _db.Users
                        where u.User_ID == id
                        select u).FirstOrDefault();// write first or default to return it as an instance not ennumeruble table
            if (!_registerchecker.Email_validator(email))
            {
                return "Enter a valid Email";
            }
            user.Email = email;
            _db.SaveChanges();
            return "Complete";
        }
        public string ModifyPassword(int id,string old_password,string new_password)
        {
            var user = (from u in _db.Users
                        where u.User_ID == id
                        select u).FirstOrDefault();// write first or default to return it as an instance not ennumeruble table
            if(old_password != user.Password)
            {
                return "Enter your old password correctly";
            }
            if(new_password == user.Password)
            {
                return "Enter a different password than your old password";
            }
            if (!_registerchecker.Password_validator(new_password))
            {
                return "Enter a valid Password (Must contain an uppercase letter and be atleast 8 characters";
            }
            user.Password = new_password;
            _db.SaveChanges();
            return "Complete";
        }
    }
}
