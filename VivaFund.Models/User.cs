using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace VivaFund.DomainModels
{
    public class User : BaseModel
    {
        public User()
        {
            
        }
        public User(string json)
        {
            JObject jObject = JObject.Parse(json);
            JToken jUser = jObject["user"];
            UserId = (int)jUser["UserId"];
            Token = (Guid)jUser["Token"];
            FirstName = (string)jUser["FirstName"];
            LastName = (string)jUser["LastName"];
            Email = (string)jUser["Email"];
            Password = (string)jUser["Password"];
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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