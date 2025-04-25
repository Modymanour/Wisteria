using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Wisteria.Domain.Entities;

namespace Wisteria.Domain.Dtos
{
    public class UserDto
    {
        public int User_ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Bio { get; set; }

    }
}
