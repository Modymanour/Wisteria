using Wisteria.Domain.Entities;

namespace Wisteria.Service.Depend_Injections.Add
{
    public class AddPost : IPosts
    {
        private readonly UserBase _db;
        public AddPost(UserBase db)
        {
            _db = db;
        }
        public string CreatePost(int User_ID, string url, string bio, string music_track, string img)
        {
            return "";
        }
    }
}
