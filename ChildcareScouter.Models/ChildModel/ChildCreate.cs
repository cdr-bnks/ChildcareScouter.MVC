using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Models.ChildModel
{
    public enum FoodAllergens
    {
        None =1,
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
    public class ChildCreate
    {
        [Required]
        public int ParentID { get; set; }

        [Required]
        [MaxLength(80, ErrorMessage ="Name Needs to be 80 characters or less")]
        [Display(Name = "Child's Name")]
        public string Name { get; set; }

        [Display(Name = "Date Of Birth", Prompt = "Please enter the Date/Month/Year your were born?")]
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;

        [Required]
        [MaxLength(20, ErrorMessage = "Please enter only 20 characters to describe your Identity.")]
        [Display(Name = "Gender Identity")]
        public string IdentifyAs { get; set; }
        [Required]
        [Display(Name="Child Needs")]
        public string ChildNeeds { get; set; }
        
        [Required]
        public int Age { get; set; }
        
        [Required]
        [Display(Name = "Food Allergens")]
        [Range(1,10, ErrorMessage ="Please select 1")]
        public FoodAllergens FoodAllergens { get; set; }
    }
}
