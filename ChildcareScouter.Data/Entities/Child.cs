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
        Wheat =1,

    }
   public class Child
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string ChildNeeds  { get; set; }
        [Required]
        public int AgeNumber  { get; set; }

        [Required]
        public string About { get; set; }
        
        [Required]
        public FoodAllergens FoodAllergens { get; set; }

    }
}
