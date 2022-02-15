using ChildcareScouter.Data;
using ChildcareScouter.Data.Entities;
using ChildcareScouter.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildcareScouter.Services.Services
{
    public class EmployeeService
    {
        private readonly Guid _userID;

        public EmployeeService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateEmployee(EmployeeCreate model)
        {
            var entity = new Employee()
            {
                Name = model.Name,
                IdentifyAs = model.IdentifyAs,
                Email = model.Email,
                Salary = model.Salary,
                Age = model.Age,
                PhoneNumber = model.PhoneNumber,
                MaritalStatus = (Data.Entities.MaritalStatus)model.MaritalStatus,
                CreatedUTC = DateTimeOffset.Now
            };
            
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Employees.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EmployeeListItem> GetEmployees()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Employees.Select(e => new EmployeeListItem
                {
                    EmployeeID = e.EmployeeID,
                    Name = e.Name,
                    IdentifyAs = e.IdentifyAs,
                    Salary = e.Salary,
                    PhoneNumber = e.PhoneNumber
                });

                return query.ToArray();
            }
        }

        public EmployeeDetail GetEmployeeByID( int iD)
        {
            using( var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Employees.Single(e => e.EmployeeID == iD);

                return new EmployeeDetail
                {
                    EmployeeID = entity.EmployeeID,
                    Name = entity.Name,
                    IdentifyAs = entity.IdentifyAs,
                    Salary = entity.Salary,
                    PhoneNumber = entity.PhoneNumber,
                    CreatedUTC = entity.CreatedUTC,
                    ModifiedUTC = entity.ModifiedUTC
                };
            }
        }

        public bool UpdateEmployee(EmployeeEdit model)
        {
            using ( var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Employees.Single(e => e.EmployeeID == model.EmployeeID);

                entity.Name = model.Name;
                entity.IdentifyAs = model.IdentifyAs;
                entity.Email = model.Email;
                entity.Salary = model.Salary;
                entity.Age = model.Age;
                entity.PhoneNumber = model.PhoneNumber;
                entity.MaritalStatus = (Data.Entities.MaritalStatus)model.MaritalStatus;
                entity.ModifiedUTC = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEmployee( int employeeID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Employees.Single(e => e.EmployeeID == employeeID);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
