using Wisteria.Domain.Entities;

namespace Wisteria.Service.Depend_Injections.Add
{
    public class AddPost : IPosts
    {
        private readonly UserBase _db;
        private readonly IGet _get;
        public AddPost(UserBase db, IGet get)
        {
            _db = db;
            _get = get;
        }
        public string CreatePost(int User_ID, string url, string bio, string music_track, string img)
        {
            var user = (from _u in _db.Users
                       where _u.User_ID == User_ID
                       select _u).FirstOrDefault();
            if (user == null)
            {
                return "Invalid User";
            }

            var post = new Posts
            {
                Url = url,
                Bio = bio,
                Music_Track = music_track,
                Img = img

            };
            user.Posts.Add(post);
            _db.Posts.Add(post);
            _db.SaveChanges();
            return "Complete";
        }
    }
}
