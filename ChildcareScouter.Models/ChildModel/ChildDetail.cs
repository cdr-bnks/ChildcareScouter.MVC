using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Models.ChildModel
{
    public class ChildDetail
    {
        public int ParentID { get; set; }

        [Display(Name="Child #")]
        public int ChildID { get; set; }

        [Display(Name = "First & Last Name")]
        public string Name { get; set; }

        [Display(Name = "Nickname")]
        public string NickName { get; set; }
        public string Pronouns { get; set; }

        [Display(Name = "Gender Identity")]
        public string IdentifyAs { get; set; }

        [Display(Name = "Date Of Birth", Prompt = "Please enter the Date/Month/Year your were born?")]
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;

        [Display(Name = "Food Allergens")]
        public FoodAllergens FoodAllergens { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUTC { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
