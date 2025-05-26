using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wisteria.Domain.Entities
{
    public class User
    {
        [Required]
        public int User_ID { get; set; }

        [Required]
        [Column(TypeName ="varchar(30)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(40)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string? Password { get; set; }

        [Column(TypeName ="nvarchar(200)")]
        public string? Bio { get; set; }

        public List<Notifications>? Notif { get; set; } = new List<Notifications>();

        public List<Communities>? Communities { get; set; } = new List<Communities>();

        public List<Comments>? User_Comments { get; set; } = new List<Comments>();

        public List<Posts>? Posts { get; set; } = new List<Posts>();

        public List<GroupChat>? groupChats { get; set; } = new List<GroupChat>();

        //public List<User>? Friends { get; set; } = new List<User>();

    }
}
