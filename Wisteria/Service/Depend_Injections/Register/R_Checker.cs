using System.Data.SqlTypes;
using System.Net;
using Wisteria.Domain.Entities;
using Wisteria.Service.Depend_Injections.Modify;

namespace Wisteria.Service.Depend_Injections.Register
{
    public class R_Checker : RegisterChecker
    {
        private readonly UserBase _db;

        public R_Checker(UserBase db)
        {
            _db = db;
        }
        public bool Email_validator(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            string[] parts = email.Split('@');
            if (parts.Length != 2)
            {
                return false; // email must have exactly one @ symbol
            }

            string localPart = parts[0];
            string domainPart = parts[1];

            try
            {
                // check if domain name has a valid MX record
                var hostEntry = Dns.GetHostEntry(domainPart);
                return hostEntry.HostName.Length > 0;
            }
            catch
            {
                return false; // domain name is invalid or does not have a valid MX record
            }
        }

        public bool Name_validator(string name)//checks if the name is already taken
        {
            var n = (from u in _db.Users
                     where u.Name == name
                     select u).FirstOrDefault();
            if(n is null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Password_validator(string password)
        {
            if (password.Length >= 8)//checks if it is bigger than or equal 8 cahracters
            {
                foreach (char i in password)
                {
                    if (char.IsUpper(i))//the password must have a upper character
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
