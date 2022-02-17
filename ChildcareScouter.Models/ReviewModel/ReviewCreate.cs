using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Models.ReviewModel
{
    public class ReviewCreate
    {
        [Required]
        public int CareproviderID { get; set; }
        [Required]
        public string Report { get; set; }

        [Required]
        public string Descritption { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        [Display(Name = "Recommended")]
        public bool IsRecommended { get; set; }
        
        [Required]
        [Display(Name = "Reproted")]
        public bool IsReported { get; set; }
    }
}
