using System.ComponentModel.DataAnnotations;

namespace Wisteria.Domain.Entities
{
    public class Comments
    {
        [Required]
        public int comment_Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string comment { get; set; }
    }
}
