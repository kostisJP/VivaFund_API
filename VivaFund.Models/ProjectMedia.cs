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
        public string URL {
            get {
                return this.URL;
            }
            set {
                if (value.Contains("https://www.youtube.com/")) {
                    value.Replace("https://www.youtube.com/watch?v=", "https://www.youtube.com/embed/");
                    this.URL = value;
                }

                this.URL = value;
            }
        }

        public int ProjectId { get; set; }
        
        public virtual Project Project { get; set; }
    }
}
