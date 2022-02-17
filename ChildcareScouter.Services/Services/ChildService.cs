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
        private readonly string _userID;

        public ChildService(string userID)
        {
            _userID = userID;
        }
        public bool CreateChild(ChildCreate model)
        {
            var entity = new Child()
            {
                User = _userID,
                ParentID = model.ParentID,
                Name = model.Name,
                DateOfBirth = model.DateOfBirth,
                IdentifyAs = model.IdentifyAs,
                ChildNeeds = model.ChildNeeds,
                Age = model.Age,
                FoodAllergens = (Data.Entities.FoodAllergens)model.FoodAllergens,
                CreatedUTC = DateTimeOffset.Now,
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
                var query = ctx.Children.Where(e => e.User == _userID).Select(e => new ChildListItem
                {
                    ParentID = e.Parent.ParentID,
                    ParentName = e.Parent.Name,
                    ChildID = e.ChildID,
                    Name = e.Name,
                    DateOfBirth = e.DateOfBirth,
                    IdentifyAs = e.IdentifyAs,
                    ChildNeeds = e.ChildNeeds,
                    Age = e.Age,
                    FoodAllergens = (Models.ChildModel.FoodAllergens)e.FoodAllergens,
                    NumberOfProviders = e.ListOfCareProviders.Count,
                    CreatedUTC = e.CreatedUTC
                });
                return query.ToArray();
            }
        }

        public IEnumerable<ChildListItem> GetChildByProviderID(int providerID)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var providerNum = ctx.Careproviders.Single(p => p.CareproviderID == providerID && p.User == _userID).ChildrenEnrolled.Select(ce => new ChildListItem
                {
                    ChildID = ce.ChildID,
                    Name = ce.Name
                });

                return providerNum.ToArray();
            }
        }
        public ChildDetail GetChildByID(int iD)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Children.Single(e => e.ChildID == iD && e.User == _userID);

                return new ChildDetail
                {
                    ParentID = entity.Parent.ParentID,
                    Parent = entity.Parent.Name,
                    ChildID = entity.ChildID,
                    ChildName = entity.Name,
                    DateOfBirth = entity.DateOfBirth,
                    IdentifyAs = entity.IdentifyAs,
                    ChildNeeds = entity.ChildNeeds,
                    Age = entity.Age,
                    FoodAllergens = (Models.ChildModel.FoodAllergens)entity.FoodAllergens,
                    NumberOfProviders = entity.ListOfCareProviders.Count,
                    CreatedUTC = entity.CreatedUTC,
                    ModifiedUTC = entity.ModifiedUTC,
                };
            }
        }

        public bool UpdateChild(ChildEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Children.Single(e => e.ChildID == model.ChildID && e.User == _userID);

                entity.Name = model.ChildName;
                entity.DateOfBirth = model.DateOfBirth;
                entity.IdentifyAs = model.IdentifyAs;
                entity.ChildNeeds = model.ChildNeeds;
                entity.Age = model.Age;
                entity.FoodAllergens = (Data.Entities.FoodAllergens)model.FoodAllergens;
                entity.ModifiedUTC = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteChild(int childID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Children.Single(e => e.ChildID == childID && e.User == _userID);
                
                ctx.Children.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
