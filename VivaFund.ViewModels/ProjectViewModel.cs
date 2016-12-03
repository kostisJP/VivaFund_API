using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VivaFund.DomainModels;

namespace VivaFund.ViewModels
{
    public class ProjectViewModel: DonationViewModel
    {
        public int ProjectId { get; set; }
        public int MemberId { get; set; }
        public int ProjectCategoryId { get; set; }
        public string TitleEn { get; set; }
        public string SubtitleEn { get; set; }
        public string BodyEn { get; set; }
        public int Goal { get; set; }
        public int Views { get; set; }
        public bool Completed { get; set; }

        public string URL { get; set; }

        public string ThumbnailImage {
            get {
                if (URL != null) {
                    var videoId = URL.Replace("https://www.youtube.com/embed/", "");
                    videoId = "http://img.youtube.com/vi/" + videoId + "/mqdefault.jpg";
                    return videoId;
                }
                return "";
            }

            set {
                this.ThumbnailImage = value;
            }
        }
        public DateTime ExpirationDate { get; set; }

        public int daysToGo {
            get {
                var days = (int)(ExpirationDate - DateTime.Now).TotalDays;
                return days;
            }
            set {
                this.daysToGo = value; 
            }
        }

        public IEnumerable<RewardViewModel> Rewards;
        public IEnumerable<DonationViewModel> Donations;
        public IEnumerable<ProjectMediaViewModel> ProjectMedia;
        public IEnumerable<CommentViewModel> Comments;
    }
}
