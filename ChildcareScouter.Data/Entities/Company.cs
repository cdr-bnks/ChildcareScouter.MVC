using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Data.Entities
{
    public class Company
    {
        [Key]
        public int CompanyID { get; set; }

        //[ForeignKey(nameof(User))]
        //public string OwnerID { get; set; }
        //public ApplicationUser User { get; set; }

        [Required]
        [Column(TypeName = "OwnerID")]
        public Guid OwnerID { get; set; }



        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public double Price { get; set; }

       [Required]
        public string Policy { get; set; }

        [Required]
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
