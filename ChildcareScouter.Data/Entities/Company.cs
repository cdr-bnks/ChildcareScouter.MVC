﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Data.Entities
{
    public class Company
    {
        [Key]
        public int CompanyID { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public double Price { get; set; }

       
        public string Policy { get; set; }

        [Required]
        public DateTimeOffset CreatedUTC { get; set; }

        [Required]
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}