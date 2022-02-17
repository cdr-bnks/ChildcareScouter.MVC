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
        private readonly string _userID;

        public LicensedService( string userID)
        {
            _userID = userID;
        }
        public bool CreateLicense(LicensedCreate model)
        {
            var entity = new Licensed()
            {
                User = _userID,
                LicensedID =  model.CarproviderID,
                CertificateName = model.CertificateName,
                DateRequired = model.DateRequired,
                BackgroundChecks = model.BackgroundChecks,
                Inspection = model.Inspection,
                Certified = model.Certified,
                CreatedUTC = DateTimeOffset.Now
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
                var query = ctx.Licenses.Where(e => e.User == _userID).Select(e => new LicensedListItem
                {
                    LicensedID = e.Careproviders.CareproviderID,
                    CertificateName = e.CertificateName,
                    DateRequired = e.DateRequired,
                    BackgroundChecks = e.BackgroundChecks,
                    Inspection = e.Inspection,
                    Certified = e.Certified,
                    ProviderName = e.Careproviders.ProviderName,
                    CreatedUTC = e.CreatedUTC
                });

                return query.ToArray();
            }
        }

        public LicensedDetail GetLicenseByID(int iD)
        {
            using( var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Licenses.Single(e => e.Careproviders.CareproviderID == iD && e.User == _userID);

                return new LicensedDetail
                {
                    ProviderName = entity.Careproviders.ProviderName,
                    LicensedID = entity.Careproviders.CareproviderID,
                    CertificateName = entity.CertificateName,
                    DateRequired = entity.DateRequired,
                    BackgroundChecks = entity.BackgroundChecks,
                    Inspection = entity.Inspection,
                    Certified = entity.Certified,
                    ModifiedUTC = entity.ModifiedUTC,
                };
            }
        }

        public bool UpdateLicense(LicensedEdit model)
        {
            using( var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Licenses.Single(e => e.Careproviders.CareproviderID == model.LicensedID && e.User == _userID);

                entity.CertificateName = model.CertificateName;
                entity.DateRequired = model.DateRequired;
                entity.BackgroundChecks = model.BackgroundChecks;
                entity.Inspection = model.Inspection;
                entity.Certified = model.Certified;
                entity.ModifiedUTC = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteLicense( int careproviderID)
        {
            using ( var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Licenses.Single(e => e.Careproviders.CareproviderID == careproviderID && e.User == _userID);

                ctx.Licenses.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
