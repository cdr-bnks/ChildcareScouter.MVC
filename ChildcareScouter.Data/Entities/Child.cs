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
        Wheat = 1,
        Gluten,
        Peanut,
        Shellfish,
        Fish,
        Soy,
        Egg,
        Diary,
        TreeNut,
        Sesame


    }
    public class Child : Person
    {
        [Key]
        public int ChildID { get; set; }

       [ForeignKey(nameof(Parent))]
        public int ParentID { get; set; }
        public virtual Parent Parent  { get; set; }

        public virtual ICollection<Careprovider> ListOfCareProviders { get; set; }

        public Child()
        {
            ListOfCareProviders = new HashSet<Careprovider>();
        }


        [Required]
        public string ChildNeeds { get; set; }

        [Required]
        public FoodAllergens FoodAllergens { get; set; }

        [Required]
        public DateTimeOffset CreatedUTC { get; set; }

        [Required]
        public DateTimeOffset? ModifiedUTC { get; set; }
    }

   /* public enum FoodAllergies
    {
        Wheat = 1,
        Peanut,
        Shellfish,
        Soy,
        Egg,
        Milk,
        TreeNut


    }
    public class Child1 : Person
    {
        [Key]
        public int Child1ID { get; set; }

        public virtual ICollection<CareProvider> ListOfProviders { get; set; }

        public Child1()
        {
            ListOfProviders = new HashSet<CareProvider>();
        }

        [Required]
        public string ChildNeeds { get; set; }

        [Required]
        public FoodAllergies FoodAllergies { get; set; }
    }*/
}
