using ChildcareScouter.Data;
using ChildcareScouter.Data.Entities;
using ChildcareScouter.Models.ParentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Services.Services
{
   public class ParentService
    {
        public readonly Guid _userID;

        public ParentService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateParent(ParentCreate model)
        {
            var entity = new Parent()
            {
                Name = model.Name,
                IdentifyAs = model.IdentifyAs,
                Age = model.Age,
                Email = model.Email,
                CreatedUTC = DateTimeOffset.Now,
                CompanyID = model.CompanyID
            };

            using( var ctx = new ApplicationDbContext())
            {
                ctx.Parents.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ParentListItem> GetParents()
        {
            using( var ctx = new ApplicationDbContext())
            {
                var query = ctx.Parents.Select(e => new ParentListItem
                {
                    CompanyID = e.Company. CompanyID,
                    Name = e.Name,
                    IdentifyAs = e.IdentifyAs,
                    Age = e.Age,
                    Email = e.Email,
                });

                return query.ToArray();
            }
        }

        public ParentDetail GetParentByID(int iD)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Parents.Single(e => e.ParentID == iD);

                return new ParentDetail
                {
                    CompanyID = entity.CompanyID,
                    Name = entity.Name,
                    IdentifyAs = entity.IdentifyAs,
                    Age = entity.Age,
                    Email = entity.Email,
                    CreatedUTC = entity.CreatedUTC,
                    ModifiedUTC = entity.ModifiedUTC
                };
            }
        }

        public bool UpdateParent(ParentEdit model)
        {
            using( var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Parents.Single(e => e.ParentID == model.ParentID);

                entity.Name = model.Name;
                entity.IdentifyAs = model.IdentifyAs;
                entity.Age = model.Age;
                entity.Email = model.Email;
                entity.ModifiedUTC = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteParent(int parentID)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Parents.Single(e => e.ParentID == parentID);

                ctx.Parents.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
