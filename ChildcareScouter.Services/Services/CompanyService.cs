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
        public bool CreateCompany(CompanyCreate model)
        {
            var entity = new Company()
            {

                CompanyName = model.CompanyName,
                Location = model.Location,
                Price = model.Price,
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
                var query = ctx.Companies.Select(e => new CompanyListItem
                {
                    CompanyID = e.CompanyID,
                    Location = e.Location,
                    Price = e.Price,
                });

                return query.ToArray();
            }
        }

        public CompanyDetail GetCompanyByID(int iD)
        {
            using ( var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Companies.Single(e => e.CompanyID == iD);

                return new CompanyDetail
                {
                    CompanyID = entity.CompanyID,
                    CompanyName = entity.CompanyName,
                    Location = entity.Location,
                    Price = entity.Price,
                    CreatedUTC = entity.CreatedUTC,
                    ModifiedUTC = entity.ModifiedUTC
                };

            }
        }

        public bool UpdateCompany(CompanyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Companies.Single(e => e.CompanyID == model.CompanyID);

                entity.CompanyName = model.CompanyName;
                entity.Location = model.Location;
                entity.Price = model.Price;
                entity.ModifiedUTC = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCompany(int companyID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Companies.Single(e => e.CompanyID == companyID);

                ctx.Companies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}


