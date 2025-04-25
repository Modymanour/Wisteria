using System.Collections.Frozen;
using System.Collections.Generic;
using Wisteria.Domain.Entities;

namespace Wisteria.Service.Depend_Injections.Add
{
    public class AddCommunity : ICommunity
    {
        private readonly UserBase _db;
        public AddCommunity(UserBase db)
        {
            _db = db;            
        }

        public string CreateCommunity(string name)
        {
            var check = (from _u in _db.Communities
                         where _u.Name == name
                         select _u).FirstOrDefault();
            if (check is null)
            {
                var community = new Communities
                {
                    Name = name
                };
                _db.Communities.Add(community);
                _db.SaveChanges();
                return "Complete";
            }
            return "Community name already taken";
        }
        public string AddUserToCommunity(int User_ID, int Community_ID)
        {
                var user = (from _u in _db.Users
                            where _u.User_ID == User_ID
                            select _u).FirstOrDefault();

                var Community = (from _u in _db.Communities
                                 where _u.Community_Id == Community_ID
                                 select _u).FirstOrDefault();

            if (user is null || Community is null)
            {
                return "Invalid Info";
            }
            Community.Community_Members.Add(user);
            user.Communities.Add(Community);
            _db.SaveChanges();
            return "Complete";

            
        }
    }
}
