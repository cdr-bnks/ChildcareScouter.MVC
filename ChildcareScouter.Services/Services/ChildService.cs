using ChildcareScouter.Data;
using ChildcareScouter.Data.Entities;
using ChildcareScouter.Models.ChildModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Services.Services
{
    public class ChildService
    {
        public bool CreateChild(ChildCreate model)
        {
            var entity = new Child()
            {
                Name = model.Name,
                IdentifyAs = model.IdentifyAs,
                DateOfBirth = model.DateOfBirth,
                FoodAllergens = (Data.Entities.FoodAllergens)model.FoodAllergens,
                CreatedUTC = DateTimeOffset.Now,
                ParentID = model.ParentID
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Children.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ChildListItem> GetChildren()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Children.Select(e => new ChildListItem
                {
                    ChildID = e.ChildID,
                    Name = e.Name,
                    IdentifyAs = e.IdentifyAs,
                    DateOfBirth = e.DateOfBirth,
                    FoodAllergens = (Models.ChildModel.FoodAllergens)e.FoodAllergens,
                    ParentID = e.Parent.ParentID
                });
                return query.ToArray();
            }
        }

        public ChildDetail GetChildByID(int iD)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Children.Single(e => e.ChildID == iD);

                return new ChildDetail
                {
                    ParentID = entity.ParentID,
                    ChildID = entity.ChildID,
                    Name = entity.Name,
                    IdentifyAs = entity.IdentifyAs,
                    DateOfBirth = entity.DateOfBirth,
                    FoodAllergens = (Models.ChildModel.FoodAllergens)entity.FoodAllergens,
                    CreatedUTC = entity.CreatedUTC,
                    ModifiedUTC = entity.ModifiedUTC,
                };
            }
        }

        public bool UpdateChild(ChildEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Children.Single(e => e.ChildID == model.ChildID);

                entity.Name = model.Name;
                entity.IdentifyAs = model.IdentifyAs;
                entity.DateOfBirth = model.DateOfBirth;
                entity.FoodAllergens = (Data.Entities.FoodAllergens)model.FoodAllergens;
                entity.ModifiedUTC = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteChild(int childID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Children.Single(e => e.ChildID == childID);
                
                ctx.Children.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
