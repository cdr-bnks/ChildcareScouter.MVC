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
        //private readonly ApplicationUser _userID;

        //public LicensedService( ApplicationUser userID)
        //{
        //    _userID = userID;
        //}
        public bool CreateLicense(LicensedCreate model, int provID)
        {
            var entity = new Licensed()
            {
                LicensedID = provID,
                CertificateName = model.CertificateName,
                DateRequired = model.DateRequired,
                BackgroundChecks = model.BackgroundChecks,
                Inspection = model.Inspection,
                Certified = model.Certified,
                CPRTraining = model.CPRTraining,
                ChildNumber = model.ChildNumber,
                StateRegistered = model.StateRegistered,
                CreatedUTC = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Licenses.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LicensedListItem> GetLicenses(int provID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Licenses/*.Where(e => e.OwnerID == provID.ToString())*/.Select(e => new LicensedListItem
                {
                    ProviderName = e.Careprovider.ProviderName,
                    LicensedID = provID,
                    CertificateName = e.CertificateName,
                    DateRequired = e.DateRequired,
                    BackgroundChecks = e.BackgroundChecks,
                    Inspection = e.Inspection,
                    Certified = e.Certified,
                    CPRTraining = e.CPRTraining,
                    StateRegistered = e.StateRegistered,
                    CreatedUTC = e.CreatedUTC
                });

                return query.ToArray();
            }
        }

        public LicensedDetail GetLicenseByID(int iD)
        {
            using( var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Licenses.Single(e => e.LicensedID == iD /*&& e.OwnerID == _userID.ToString()*/);

                return new LicensedDetail
                {
                    ProviderName = entity.Careprovider.ProviderName,
                    LicensedID = iD,
                    CertificateName = entity.CertificateName,
                    DateRequired = entity.DateRequired,
                    BackgroundChecks = entity.BackgroundChecks,
                    Inspection = entity.Inspection,
                    Certified = entity.Certified,
                    CPRTraining = entity.CPRTraining,
                    ChildNumber = entity.ChildNumber,
                    StateRegistered = entity.StateRegistered,
                    ModifiedUTC = entity.ModifiedUTC,
                };
            }
        }

        public bool UpdateLicense(LicensedEdit model)
        {
            using( var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Licenses.Single(e => e.LicensedID == model.LicensedID /*&& e.OwnerID == provID.ToString()*/);

                entity.CertificateName = model.CertificateName;
                entity.DateRequired = model.DateRequired;
                entity.BackgroundChecks = model.BackgroundChecks;
                entity.Inspection = model.Inspection;
                entity.Certified = model.Certified;
                entity.CPRTraining = model.CPRTraining;
                entity.ChildNumber = model.ChildNumber;
                entity.StateRegistered = model.StateRegistered;
                entity.ModifiedUTC = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteLicense( int provID)
        {
            using ( var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Licenses.Single(e => e.LicensedID == provID /*&& e.OwnerID == _userID.ToString()*/);

                ctx.Licenses.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
