﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Data.Entities
{
    public enum MaritalStatus
    {
        Married = 1,
        Single,
        Seperated,
        Widowed,
        Divorced,

    }
    public class Employee : Person
    {
        [Key]
        public int EmployeeID { get; set; }

        //public Guid OwnerID { get; set; }

        public virtual ICollection<Careprovider> ListOfPositions { get; set; }

        public Employee()
        {
            ListOfPositions = new HashSet<Careprovider>();
        }


        [Required]
        public MaritalStatus MaritalStatus { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public double  Salary { get; set; }

        [Required]
        public DateTimeOffset CreatedUTC { get; set; }

        [Required]
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}