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
                OwnerID = _userID,
                CompanyID = model.CompanyID,
                Name = model.Name,
                DateOfBirth = model.DateOfBirth,
                IdentifyAs = model.IdentifyAs,
                Email = model.Email,
                Age = model.Age,
                PhoneNumber = model.PhoneNumber,
                Race = model.Race,
                Religion = model.Religion,
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
                var query = ctx.Parents.Where(e => e.OwnerID == _userID).Select(e => new ParentListItem
                {
                    CompanyID= e.Company.CompanyID,
                    ParentID = e.ParentID,
                    Name = e.Name,
                    DateOfBirth = e.DateOfBirth,
                    IdentifyAs = e.IdentifyAs,
                    Email = e.Email,
                    Age = e.Age,
                    PhoneNumber = e.PhoneNumber,
                    Race = e.Race,
                    Religion = e.Religion
                });

                return query.ToArray();
            }
        }

        public ParentDetail GetParentByID(int iD)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Parents.Single(e => e.ParentID == iD && e.OwnerID == _userID);

                return new ParentDetail
                {
                    CompanyID = entity.CompanyID,
                    ParentID = entity.ParentID,
                    Name = entity.Name,
                    DateOfBirth = entity.DateOfBirth,
                    IdentifyAs = entity.IdentifyAs,
                    Email = entity.Email,
                    Age = entity.Age,
                    PhoneNumber = entity.PhoneNumber,
                    Race = entity.Race,
                    Religion = entity.Religion,
                    CreatedUTC = entity.CreatedUTC,
                    ModifiedUTC = entity.ModifiedUTC
                };
            }
        }

        public bool UpdateParent(ParentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Parents.Single(e => e.ParentID == model.ParentID && e.OwnerID == _userID);

                entity.ParentID = model.ParentID;
                entity.Name = model.Name;
                entity.DateOfBirth = model.DateOfBirth;
                entity.IdentifyAs = model.IdentifyAs;
                entity.Email = model.Email;
                entity.Age = model.Age;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Race = model.Race;
                entity.Religion = model.Religion;
                entity.ModifiedUTC = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteParent(int parentID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Parents.Single(e => e.ParentID == parentID && e.OwnerID == _userID);

                ctx.Parents.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
