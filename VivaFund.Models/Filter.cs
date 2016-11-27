using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivaFund.DomainModels
{
    public class Filter : BaseModel
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FilterId { get; set; }

        [Required]
        public string FilterType { get; set; }

        [Required]
        [MaxLength(50)]
        public string FilterName { get; set; }

    }
}
