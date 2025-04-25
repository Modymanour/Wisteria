using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wisteria.Domain.Entities
{
    public class Notifications
    {
        [Required]
        public int Notif_ID { get; set; }

        [Column(TypeName ="varchar(200)")]
        public string content { get; set; }
    }
}
