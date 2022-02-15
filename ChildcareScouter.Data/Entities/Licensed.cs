using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Data.Entities
{
   public class Licensed
    {
        [ForeignKey(nameof(CareproviderID))]
        public int LicensedID { get; set; }
      
        public virtual Careprovider CareproviderID { get; set; }

        public string CertificateName { get; set; }
        public bool Certified { get; set; }
        public bool CPRTraining { get; set; }
        public bool CriminalBackground  { get; set; }
        public int ChildNumber { get; set; }
        public bool Inspection { get; set; }
        public bool StateRegistered { get; set; }
        public DateTime DateRequired { get; set; }

        //public DateTimeOffset CreatedUTC { get; set; }
        //public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
