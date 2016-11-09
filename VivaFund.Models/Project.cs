using System.ComponentModel.DataAnnotations;

namespace VivaFund.Models
{
    public class Project: BaseModel
    {
        [Key]
        public int ProjectId { get; set; }

        public int MemberId { get; set; }

        public Member Member { get; set; }

        // ADD CATEGORY

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