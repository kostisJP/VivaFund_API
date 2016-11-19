using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivaFund.DomainModels
{
    public class ProjectUpdate : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UpdateID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
