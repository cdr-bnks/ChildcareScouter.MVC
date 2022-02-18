using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Data.Entities
{
    public class Parent: Person
    {
        [Key]
        public int ParentID { get; set; }

        //[ForeignKey(nameof(User))]
        //public string OwnerID { get; set; }
        //public ApplicationUser User { get; set; }

        [Required]
        [Column(TypeName = "OwnerID")]
        public Guid OwnerID { get; set; }

        [ForeignKey(nameof(Company))]
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }

        [Required]
        public double PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
