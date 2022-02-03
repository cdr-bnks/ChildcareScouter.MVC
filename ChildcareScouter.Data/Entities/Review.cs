using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Data.Entities
{
   public class Review
    {
        [Key]
        public int ReviewID { get; set; } 

        [ForeignKey(nameof(Enrollment))]
        public int? EnrollmentID { get; set; }
        public virtual Enrollment Enrolled { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public bool IsEnrolled { get; set; }

        [Display]
        public int? Stars { get; set; }


        public string Report { get; set; }


        public bool IsLiked { get; set; }
        public bool IsHearted { get; set; }

        public bool IsRecomended { get; set; }

        [Required]
        public DateTimeOffset CreatedCTU { get; set; }
        public DateTimeOffset? ModifiededCTU { get; set; }


    }
}
