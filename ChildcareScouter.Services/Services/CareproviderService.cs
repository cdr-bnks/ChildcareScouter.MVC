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
        private readonly Guid _userID;

        public CareproviderService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateCareprovider(CareproviderCreate model)
        {
            var entity =
                        new Careprovider()
                        {
                            OwnerID = _userID,
                            CompanyID = model.CompanyID,
                            ProviderName = model.ProviderName,
                            ProviderTitle = model.ProviderTitle,
                            ContactInfo = model.ContactInfo,
                            FullTime = model.FullTime,
                            CreatedUTC = DateTimeOffset.Now,
                        };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Careproviders.Add(entity);
                return ctx.SaveChanges() == 1;
            }
            
        }

        public bool AddChildToCareprovider(int providerID, int childID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                //var childModel = new Child();
                //var provModel = new Careprovider();

                var providerProcured = ctx.Careproviders.SelectMany(care => care.ChildrenEnrolled.Where(pp => pp.ChildID == providerID)).ToHashSet();

                var childProcured = ctx.Children.SelectMany(c => c.ListOfCareProviders.Where(cp => cp.CompanyID == childID)).ToHashSet();


                foreach(var child in ctx.Children)
                {
                    providerProcured.Add(child);
                }

                foreach(var prov in ctx.Careproviders)
                {
                    childProcured.Add(prov);
                }
                //providerProcured.Add(childModel);

                //childProcured.Add(provModel);
                
                return ctx.SaveChanges() == 2;
            }
        }

        public bool AddEmployeeToCareprovider(int employeeID, int careproviderID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                //var provModel = new Careprovider();
                //var empModel = new Employee();

                var employeeProcured = ctx.Employees.SelectMany(emp => emp.ListOfPositions.Where(e => e.CareproviderID == employeeID)).ToHashSet();
                
                var providerProcured = ctx.Careproviders.SelectMany(care => care.ListOfEmployees.Where(prov => prov.EmployeeID == careproviderID)).ToHashSet();
                
                foreach(var emp in ctx.Employees)
                {
                    providerProcured.Add(new Employee 
                    {
                        EmployeeID = emp.EmployeeID,
                        Name = emp.Name
                    });
                }

                foreach(var prov in ctx.Careproviders)
                {
                    employeeProcured.Add(new Careprovider 
                    {
                        CareproviderID = prov.CareproviderID,
                        ProviderName = prov.ProviderName
                    });
                }

                //employeeProcured.Add(provModel);

                //providerProcured.Add(empModel);
                
                return ctx.SaveChanges() == 2;
            }
        }

        public IEnumerable<CareproviderListItem> GetCareprovider()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Careproviders.Where(e => e.OwnerID == _userID).Select(e => new CareproviderListItem
                {
                    CompanyID = e.CompanyID,
                    CareproviderID = e.CareproviderID,
                    ProviderName = e.ProviderName,
                    ProviderTitle = e.ProviderTitle,
                    ContactInfo = e.ContactInfo,
                    ChildrenEnrolled = e.ChildrenEnrolled.Count,
                    Staff = e.ListOfEmployees.Count,
                    FullTIme = e.FullTime,
                    CreatedUTC =e.CreatedUTC
                });

                return query.ToArray();
            }
        }

        public CareproviderDetail GetCareproviderByID(int iD)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Careproviders.Single(c => c.CareproviderID == iD && c.OwnerID == _userID);

                return new CareproviderDetail()
                {
                    CompanyID = entity.CompanyID,
                    CareproviderID = entity.CareproviderID,
                    CompanyPrices = entity.Company.Price,            
                    ProviderName = entity.ProviderName,
                    ProviderTitle = entity.ProviderTitle,
                    ContactInfo = entity.ContactInfo,
                    FullTime =entity.FullTime,
                    CreatedUTC = entity.CreatedUTC,
                    ModifiedUTC = entity.ModifiedUTC
                };
            }
        }

        public bool UpdateCareprovider(CareproviderEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Careproviders.Single(e => e.CareproviderID == model.CareproviderID && e.OwnerID == _userID);
                
                entity.ProviderName = model.ProviderName;
                entity.ProviderTitle = model.ProviderTitle;
                entity.ContactInfo = model.ContactInfo;
                entity.FullTime = model.FullTime;
                entity.ModifiedUTC = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCareprovider(int careproviderID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Careproviders.Single(e => e.CareproviderID == careproviderID && e.OwnerID == _userID);

                ctx.Careproviders.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
