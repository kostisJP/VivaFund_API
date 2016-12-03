using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VivaFund.DomainModels
{
    public class Project: BaseModel
    {
        //public Project()
        //{
        //    Rewards = new List<Reward>();
        //}

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }

        [Required]
        public int MemberId { get; set; }

        public virtual Member Member { get; set; }

        [Required]
        public int ProjectCategoryId { get; set; }

        public virtual ProjectCategory ProjectCategory { get; set; }

        public string TitleEn { get; set; }

        public string TitleEl { get; set; }

        public string SubtitleEn { get; set; }

        public string SubtitleEl { get; set; }

        public string BodyEn { get; set; }

        public string BodyEl { get; set; }

        [Required]
        public int Goal { get; set; }

        public int Views { get; set; }

        public bool Completed { get; set; }

        public DateTime ExpirationDate { get; set; } = DateTime.Now.AddDays(60);

        public string Url { get; set; }

        public ICollection<Donation> Donations { get; set; }
        public ICollection<ProjectMedia> ProjectMedia { get; set; }
        public ICollection<Reward> Rewards { get; set; }


    }
}