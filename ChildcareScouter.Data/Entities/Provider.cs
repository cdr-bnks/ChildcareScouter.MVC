using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Data.Entities
{
    public enum TypeOfProvider
    {
        FamilyCare = 1,
        Nanny,
        Manny,
        BabySitters,
        Teacher,
        Counseler,
        SpecailNeeds

    }
    public class Provider : Person
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public TypeOfProvider ProviderType { get; set; }

        [Required]
        public string SpecialSkill { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTimeOffset HiredDateCTU { get; set; }
        
        [Required]
        public bool IsCertified { get; set; }

        public bool AgeNumber 
        {
            get 
            {
                if(Age == 16 || Age > 16)
                {
                    return AgeNumber;
                }

                return false;
            }

        }
    }
}
