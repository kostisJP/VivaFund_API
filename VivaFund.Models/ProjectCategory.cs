using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivaFund.DomainModels
{
    public class ProjectCategory : BaseModel
    {
        [Key]
        public int ProjectCategoryId { get; set; }

        public Guid Token { get; set; } = Guid.NewGuid();

        [MaxLength(50)]
        [Required]
        public string CategoryName { get; set; }

    }
}
