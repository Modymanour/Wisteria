using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
namespace Wisteria.Domain.Entities
{
    public class UserBase : DbContext
    {
        public UserBase(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Notifications> Notifications { get; set; }

        public DbSet<Communities> Communities { get; set; }

        public DbSet<Comments> Comments { get; set; }

        public DbSet<Posts> Posts { get; set; }

        public DbSet<Chat> Chat { get; set; }

        public DbSet<GroupChat> GroupChat { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(i => i.User_ID);
            modelBuilder.Entity<Notifications>().HasKey(i => i.Notif_ID);
            modelBuilder.Entity<Communities>().HasKey(i => i.Community_Id);
            modelBuilder.Entity<Comments>().HasKey(i => i.comment_Id);
            modelBuilder.Entity<Posts>().HasKey(i => i.Post_ID);
            modelBuilder.Entity<Chat>().HasKey(i => i.Text_ID);
            modelBuilder.Entity<GroupChat>().HasKey(i => i.GroupChatID);
        }
    }
}
