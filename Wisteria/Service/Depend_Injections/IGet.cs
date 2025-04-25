using Wisteria.Domain.Entities;

namespace Wisteria.Service.Depend_Injections
{
    public interface IGet
    {
        public IQueryable<User>? GetUser(int User_ID);

        public IQueryable<Communities>? GetCommunities(int Community_ID);

        public IQueryable<Posts>? GetPosts(int Post_ID);
    }
}
