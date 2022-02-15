using ChildcareScouter.Data;
using ChildcareScouter.Data.Entities;
using ChildcareScouter.Models.LicensedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Services.Services
{
    public class LicensedService
    {
        public bool CreateLicense(LicensedCreate model)
        {
            var entity = new Licensed()
            {
                LicensedID = model.CareproviderID,
                CertificateName = model.CertificateName,
                DateRequired = model.DateRequired,
                CriminalBackground = model.CriminalBackground,
                Inspection = model.Inspection,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Licenses.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LicensedListItem> GetLicenses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Licenses.Select(e => new LicensedListItem
                {
                    LicensedID = e.CareproviderID.CareproviderID,
                    CertificateName = e.CertificateName,
                    DateRequired = e.DateRequired,
                    CriminalBackground = e.CriminalBackground,
                    Inspection = e.Inspection,
                    ProviderName = e.CareproviderID.ProviderName
                });

                return query.ToArray();
            }
        }

        public LicensedDetail GetLicenseByID(int iD)
        {
            using( var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Licenses.Single(e => e.CareproviderID.CareproviderID == iD);

                return new LicensedDetail
                {
                    LicensedID = entity.CareproviderID.CareproviderID,
                    CertificateName = entity.CertificateName,
                    DateRequired = entity.DateRequired,
                    CriminalBackground = entity.CriminalBackground,
                    Inspection = entity.Inspection,
                    ProviderName = entity.CareproviderID.ProviderName
                };
            }
        }

        public bool UpdateLicense(LicensedEdit model)
        {
            using( var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Licenses.Single(e => e.CareproviderID.CareproviderID == model.LicensedID);

                entity.CertificateName = model.CertificateName;
                entity.DateRequired = model.DateRequired;
                entity.CriminalBackground = model.CriminalBackground;
                entity.Inspection = model.Inspection;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteLicense( int careproviderID)
        {
            using ( var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Licenses.Single(e => e.CareproviderID.CareproviderID == careproviderID);

                ctx.Licenses.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
