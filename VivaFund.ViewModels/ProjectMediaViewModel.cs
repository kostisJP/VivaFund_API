using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivaFund.ViewModels
{
    public class ProjectMediaViewModel
    {
        public int ProjectMediaId { get; set; }

        public bool IsCoverImage { get; set; }  //main image

        public int ProjectMediaType { get; set; }

        public string URL { get; set; }

        //public string ThumbnailImage {
        //    get {

        //    }

        //    set;
        //}
    }
}
