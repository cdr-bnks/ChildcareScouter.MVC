using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Data.Entities
{
    public enum MaritalStatus
    {
        Married =1,
        Single,
        Seperated,
        Widowed,
        Divorced,

    }
    public class Staff : Person
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public bool AgeNumber 
        { 
            get
            {
                if(Age == 18 || Age > 18)
                {

                    return AgeNumber;
                }
                return false;
            } 
        }

        [Required]
        public MaritalStatus MaritalStatus { get; set; }

        [Required]
        public bool IsVolunteer { get; set; }

        [Required]
        public bool HasDependent { get; set; }

        [Required]
        public int NumberOfDependent { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public bool IsImmunized { get; set; }


    }
}
