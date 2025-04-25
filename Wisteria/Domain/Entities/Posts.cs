using Microsoft.AspNetCore.Antiforgery;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wisteria.Domain.Entities
{
    public class Posts
    {
        [Required]
        public int Post_ID { get; set; }
        [Column(TypeName ="varchar(500)")]//rough estimation
        public string? Url { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string? Bio { get; set; }

        [Column(TypeName = "varchar(300)")]
        public string? Music_Track { get; set; }
        
        [Column(TypeName = "varchar(300)")]
        public string? Img { get; set; }

        public List<Comments>? Comments { get; set; } = new List<Comments>();


    }
}
