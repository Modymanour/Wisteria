using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wisteria.Domain.Entities
{
    public class GroupChat
    {
        [Required]
        public int GroupChatID { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(60)")]
        public string Name { get; set; }

        [Column(TypeName ="nvarchar(400)")]
        public string? Bio { get; set; }

        public List<User> users { get; set; } = new List<User>();

        public List<Chat> chats { get; set; } = new List<Chat>();
    }
}
