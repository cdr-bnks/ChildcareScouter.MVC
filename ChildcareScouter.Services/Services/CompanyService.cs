using ChildcareScouter.Data;
using ChildcareScouter.Data.Entities;
using ChildcareScouter.Models.CompanyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Services.Services
{
    public class CompanyService
    {
        private readonly Guid _userID;

        public CompanyService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateCompany(CompanyCreate model)
        {
            var entity = new Company()
            {
                OwnerID = _userID,
                CompanyName = model.CompanyName,
                Location = model.Location,
                Price = model.Price,
                Policy = model.Policy,
                CreatedUTC = DateTimeOffset.Now
               
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Companies.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        
        }

        public IEnumerable<CompanyListItem> GetCompanies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Companies.Where(e => e.OwnerID == _userID).Select(e => new CompanyListItem
                {
                    CompanyID = e.CompanyID,
                   CompanyName = e.CompanyName,
                    Location = e.Location,
                    Price = e.Price,
                    Policy = e.Policy,
                    CreatedUTC = e.CreatedUTC
                });

                return query.ToArray();
            }
        }

        public CompanyDetail GetCompanyByID(int iD)
        {
            using ( var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Companies.Single(e => e.CompanyID == iD && e.OwnerID == _userID);

                return new CompanyDetail
                {
                    CompanyID = entity.CompanyID,
                    CompanyName = entity.CompanyName,
                    Location = entity.Location,
                    Price = entity.Price,
                    Policy = entity.Policy,
                    CreatedUTC = entity.CreatedUTC,
                    ModifiedUTC = entity.ModifiedUTC
                };

            }
        }

        public bool UpdateCompany(CompanyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Companies.Single(e => e.CompanyID == model.CompanyID && e.OwnerID == _userID);

                entity.CompanyName = model.CompanyName;
                entity.Location = model.Location;
                entity.Price = model.Price;
                entity.Policy = model.Policy;
                entity.ModifiedUTC = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCompany(int companyID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Companies.Single(e => e.CompanyID == companyID && e.OwnerID == _userID);

                ctx.Companies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}


