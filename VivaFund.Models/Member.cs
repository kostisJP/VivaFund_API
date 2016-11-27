using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivaFund.DomainModels
{
    public class Member: BaseModel
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberId { get; set; }

        [Required]
        [MaxLength(128)]
        public string AspNetUserId { get; set; }

        public Guid Token { get; set; } = Guid.NewGuid();

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        public virtual IEnumerable<Project> Projects { get; set; }


        //[Required]
        //public string Password { get; set; }
    }
}
