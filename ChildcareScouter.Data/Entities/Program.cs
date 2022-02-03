﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Data.Entities
{
    public enum TypeOfRegion
    {
        Rural = 1,
        Urban,
        Suberbs
    } 
   public class Program
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Address { get; set; }
        
        [Required]
        public TypeOfRegion RegionType  {  get; set; }

        [Required]
        public string County { get; set; }

        [Required]
        public string Curriculum { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public DateTime BusinessHours { get; set; }
        public string Policy { get; set; }
    }
}
