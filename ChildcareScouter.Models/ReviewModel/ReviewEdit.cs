using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Models.ReviewModel
{
    public class ReviewEdit
    {
        [Display(Name ="Reviews:")]
        public int ReviewID { get; set; }
        public string Report { get; set; }
        public string Description { get; set; }
        public int Score { get; set; }

        [Display(Name ="Recommended")]
        public bool IsRecommended { get; set; }
        
        [Display(Name ="Reported:")]

        public bool IsReported { get; set; }
    }
}
