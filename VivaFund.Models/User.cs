using System;
using System.ComponentModel.DataAnnotations;

namespace VivaFund.DomainModels
{
    public class User: BaseModel
    {
        [Key]
        public int UserId { get; set; }

        public Guid Token { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}