using System;
using System.ComponentModel.DataAnnotations;

namespace ChildcareScouter.Models.ChildModel
{
    public class ChildListItem
    {
        public int ParentID { get; set; }

        [Display(Name="Parent")]
        public string  ParentName { get; set; }

        [Display(Name = "Children")]
        public int ChildID { get; set; }

        [Display(Name="Child's Name")]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;

        [Display(Name = "Gender Identity")]
        public string IdentifyAs { get; set; }

        [Display(Name ="Child Needs")]
        public string ChildNeeds { get; set; }

        public int Age { get; set; }

        [Display(Name = "Food Allergens")]
        public FoodAllergens FoodAllergens { get; set; }

        [Display(Name="Number of Providers")]
        public int NumberOfProviders { get; set; }

        [Display(Name="")]
        public DateTimeOffset CreatedUTC { get; set; }
    }
}
