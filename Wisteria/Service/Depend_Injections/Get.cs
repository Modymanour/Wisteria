using Wisteria.Domain.Entities;
using Wisteria.Migrations;

namespace Wisteria.Service.Depend_Injections
{
    public class Get : IGet
    {
        private readonly UserBase _db;
        public Get(UserBase db)
        {
            _db = db;
        }
        public IQueryable<Communities>? GetCommunities(int Community_ID)
        {
            var community = from _u in _db.Communities
                       where _u.Community_Id == Community_ID
                       select _u;
            if (community is null)
            {
                return null;
            }
            return community;
        }

        public IQueryable<Posts>? GetPosts(int Post_ID)
        {
            var post = from _u in _db.Posts
                       where _u.Post_ID == Post_ID
                       select _u;
            if (post is null)
            {
                return null;
            }
            return post;
        }

        public IQueryable<User>? GetUser(int User_ID)
        {
            var user = from _u in _db.Users
                       where _u.User_ID == User_ID
                       select _u;
            if (user is null)
            {
                return null;
            }
            return user;
        }
    }
}
