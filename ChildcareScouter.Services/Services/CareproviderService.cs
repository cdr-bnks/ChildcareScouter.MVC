using ChildcareScouter.Data;
using ChildcareScouter.Data.Entities;
using ChildcareScouter.Models.CareproviderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Services.Services
{
    public class CareproviderService
    {
        public bool CreateCareprovider(CareproviderCreate model)
        {
            var entity =
                        new Careprovider()
                        {

                            ProviderName = model.ProviderName,
                            ProviderTitle = model.ProviderTitle,
                            ContactInfo = model.ContactInfo,
                            FullTime = model.FullTime,
                            CreatedUTC = DateTimeOffset.Now,
                            CompanyID = model.CompanyID
                        };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CareproviderID.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool AddChildToCareprovider( int childID, int careproviderID)
        {
            using (var ctx = new ApplicationDbContext())
            {
               /* var careproviderProcured = ctx.CareproviderID.SelectMany(care => new Careprovider()
                {
                    CareproviderID = care.CareproviderID,
                    ChildrenEnrolled = care.ChildrenEnrolled
                });*/

                var careproviderProcured = ctx.CareproviderID.Single(care => care.CareproviderID == careproviderID);
                var childProcured = ctx.Children.Single(c => c.ChildID == childID);

                careproviderProcured.ChildrenEnrolled.Add(childProcured);

                return ctx.SaveChanges() == 2;
            }
        }

        public bool AddEmployeeToCareprovider(int employeeID, int careproviderID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var employeeProcured = ctx.Employees.Single(emp => emp.EmployeeID == employeeID);
                
                var careproviderProcured = ctx.CareproviderID.Single(care => care.CareproviderID == careproviderID);
                
                careproviderProcured.ListOfEmployees.Add(employeeProcured);
                
                return ctx.SaveChanges() == 2;
            }
        }

       /* public bool AddReviewsToCareProvider(int reviewID, int careproviderID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var reviewProcured = ctx.Reviews.Single(emp => emp.ReviewID == reviewID);

                var careproviderProcured = ctx.CareProviders.Single(care => care.CareProviderID == careproviderID);

                careproviderProcured.ListOfReviews.Add(reviewProcured);

                return ctx.SaveChanges() == 2;
            }
        }*/

        public IEnumerable<CareproviderListItem> GetCareprovider()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.CareproviderID.Select(e => new CareproviderListItem
                {
                    CompanyID = e.CompanyID,
                    CareproviderID = e.CareproviderID,
                    ProviderName = e.ProviderName,
                    ProviderTitle = e.ProviderTitle,
                    ContactInfo = e.ContactInfo,
                });

                return query.ToArray();
            }
        }

        public CareproviderDetail GetCareproviderByID(int iD)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.CareproviderID.Single(c => c.CareproviderID == iD);

                return new CareproviderDetail()
                {
                    CompanyID = entity.CompanyID,
                    CareproviderID = entity.CareproviderID,
                    ProviderName = entity.ProviderName,
                    ProviderTitle = entity.ProviderTitle,
                    ContactInfo = entity.ContactInfo,
                };
            }
        }

        public bool UpdateCareprovider(CareproviderEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.CareproviderID.Single(e => e.CareproviderID == model.CareproviderID);

                entity.ProviderName = model.ProviderName;
                entity.ProviderTitle = model.ProviderTitle;
                entity.ContactInfo = model.ContactInfo;
                entity.ModifiedUTC = DateTimeOffset.Now;
                entity.FullTime = model.FullTime;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCareprovider(int careproviderID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.CareproviderID.Single(e => e.CareproviderID == careproviderID);

                ctx.CareproviderID.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
