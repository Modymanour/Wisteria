using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wisteria.Domain.Entities
{
    public class Communities
    {
        [Required]
        public int Community_Id { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(30)")]
        public string Name { get; set; }

        [Column(TypeName ="nvarchar(300)")]
        public string? Bio { get; set; }

        public List<User>? Community_Members { get; set; } = new List<User>();

        public List<Posts> Community_Posts { get; set; } = new List<Posts>();


    }
}
