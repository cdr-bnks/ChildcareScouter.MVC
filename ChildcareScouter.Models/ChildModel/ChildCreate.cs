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
    public class ChildCreate
    {
        public int ParentID { get; set; }
        [Required]
        [MaxLength(80, ErrorMessage ="Name Needs to be 80 characters or less")]
        [Display(Name = "First & Last Name")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings =true)]
        [MaxLength(10)]
        [Display(Name = "Nickname")]
        public string NickName { get; set; }
        
        [Required(AllowEmptyStrings =true)]
        [MaxLength(10)]
        public string Pronouns { get; set; }


        [Required]
        [MaxLength(20, ErrorMessage ="Please enter only 20 characters to describe your Identity.")]
        [Display(Name = "Gender Identity")]
        public string IdentifyAs { get; set; }

        
        [Display(Name = "Date Of Birth", Prompt ="Please enter the Date/Month/Year your were born?")]
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
        
        [Required]
        [Display(Name = "Food Allergens")]
        [Range(1,10, ErrorMessage ="Please select a number between 1-10")]
        public FoodAllergens FoodAllergens { get; set; }
    }
}
