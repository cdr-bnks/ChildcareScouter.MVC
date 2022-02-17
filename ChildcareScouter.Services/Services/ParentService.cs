using ChildcareScouter.Data;
using ChildcareScouter.Data.Entities;
using ChildcareScouter.Models.ParentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ChildcareScouter.Services.Services
{
    public class ParentService
    {
        private readonly Guid _userID;
        public ParentService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateParent(ParentCreate model)
        {
            var entity = new Parent()
            {
                User = _userID,
                CompanyID = model.CompanyID,
                Name = model.Name,
                DateOfBirth = model.DateOfBirth,
                IdentifyAs = model.IdentifyAs,
                Email = model.Email,
                Age = model.Age,
                PhoneNumber = model.PhoneNumber,
                CreatedUTC = DateTimeOffset.Now,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Parents.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ParentListItem> GetParents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Parents.Where(e => e.User == _userID).Select(e => new ParentListItem
                {
                    CompanyID = e.Company.CompanyID,
                    Name = e.Name,
                    DateOfBirth = e.DateOfBirth,
                    IdentifyAs = e.IdentifyAs,
                    Email = e.Email,
                    Age = e.Age,
                    PhoneNumber = e.PhoneNumber
                });

                return query.ToArray();
            }
        }

        public ParentDetail GetParentByID(int iD)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Parents.Single(e => e.ParentID == iD && e.User ==_userID);

                return new ParentDetail
                {
                    CompanyID = entity.CompanyID,
                    Name = entity.Name,
                    IdentifyAs = entity.IdentifyAs,
                    Email = entity.Email,
                    Age = entity.Age,
                    PhoneNumber = entity.PhoneNumber,
                    CreatedUTC = entity.CreatedUTC,
                    ModifiedUTC = entity.ModifiedUTC
                };
            }
        }

        public bool UpdateParent(ParentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Parents.Single(e => e.ParentID == model.ParentID && e.User == _userID);

                entity.CompanyID = model.CompanyID;
                entity.Name = model.Name;
                entity.DateOfBirth = model.DateOfBirth;
                entity.IdentifyAs = model.IdentifyAs;
                entity.Email = model.Email;
                entity.Age = model.Age;
                entity.PhoneNumber = model.PhoneNumber;
                entity.ModifiedUTC = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteParent(int parentID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Parents.Single(e => e.ParentID == parentID && e.User == _userID);

                ctx.Parents.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
