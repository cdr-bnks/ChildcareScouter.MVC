using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Data.Entities
{
    public enum FoodAllergens
    {
        None = 1,
        Wheat,
        Gluten,
        Peanut,
        Shellfish,
        Fish,
        Soy,
        Egg,
        Diary,
        TreeNut,
        Sesame,
        All


    }
    public class Child : Person
    {
        [Key]
        public int ChildID { get; set; }

        [ForeignKey(nameof(Parent))]
        public int ParentID { get; set; }
        public virtual Parent Parent { get; set; }

        public virtual ICollection<Careprovider> ListOfCareProviders { get; set; }

        public Child()
        {
            ListOfCareProviders = new HashSet<Careprovider>();
        }


        [Required]
        public Guid OwnerID { get; set; }

        [Required]
        public string ChildNeeds { get; set; }

        [Required]
        public FoodAllergens FoodAllergens { get; set; }

        [Required]
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
