using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivaFund.DomainModels
{
    public class Reward : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RewardID { get; set; }

        public int? ProjectID { get; set; }

        public virtual Project Project { get; set; }

        [Required]
        public int Value { get; set; }

        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string RewardDescription { get; set; }


    }
}
