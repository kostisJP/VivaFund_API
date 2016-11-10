using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VivaFund.DomainModels
{
    public class Project: BaseModel
    {
        [Key]
        public int ProjectId { get; set; }

        public int MemberId { get; set; }

        public virtual Member Member { get; set; }

        public int ProjectCategoryId { get; set; }

        public virtual ProjectCategory ProjectCategory { get; set; }

        public List<ProjectMedia> ProjectMedias { get; set; }

        public string TitleEn { get; set; }

        public string TitleEl { get; set; }

        public string SubtitleEn { get; set; }

        public string SubtitleEl { get; set; }

        public string BodyEn { get; set; }

        public string BodyEl { get; set; }

        public int Goal { get; set; }

        public int Views { get; set; }

        public bool Completed { get; set; }

    }
}