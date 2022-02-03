using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Data.Entities
{
    public enum FoodAllergens
    {
        Wheat = 1,
        Peanut,
        Shellfish,
        Soy,
        Egg,
        Milk,
        TreeNut


    }
    public class Child : Person
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string ChildNeeds { get; set; }
        [Required]
        public bool AgeNumber
        {
            get
            {
                if (Age < 12)
                {
                    return AgeNumber;
                }
                return false;
            }

        }

        [Required]
        public string About { get; set; }

        [Required]
        public FoodAllergens FoodAllergens { get; set; }

    }
}
