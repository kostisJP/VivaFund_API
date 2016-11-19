using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivaFund.DomainModels
{
    public class ProjectMedia: BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectMediaId { get; set; }

        public bool IsCoverImage { get; set; }  //main image

        public int ProjectMediaType { get; set; }

        [MaxLength(500)]
        public string URL { get; set; }

        public int ProjectId { get; set; }
        
        public Project Project { get; set; }
    }
}
