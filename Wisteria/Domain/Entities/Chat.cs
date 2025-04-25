using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wisteria.Domain.Entities
{
    public class Chat
    {
        [Required]
        public int Text_ID { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(1000)")]
        public string Text { get; set; }
    }
}
