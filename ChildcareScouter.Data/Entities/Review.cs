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

        //[Required]
        //public Guid User { get; set; }

        [Required]
        public string User { get; set; }

        [ForeignKey(nameof(Careprovider))]
        public int CareproviderID { get; set; }

        public virtual Careprovider Careprovider { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        public bool IsRecommended { get; set; }

        [Required]
        public string Report { get; set; }

        [Required]
        public  bool IsReported { get; set; }

        [Required]
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
