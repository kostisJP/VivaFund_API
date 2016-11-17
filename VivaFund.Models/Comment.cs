using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivaFund.DomainModels
{
    public class Comment : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentID { get; set; }

        public int MemberId { get; set; }
        [ForeignKey("MemberId")]
        public virtual Member Member { get; set; }

        public int? ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }

        [Required]
        [MaxLength(50)]
        public string CommentBody { get; set; }

        public int CounterPlus { get; set; }

        public int CounterMinus { get; set; }
    }
}
