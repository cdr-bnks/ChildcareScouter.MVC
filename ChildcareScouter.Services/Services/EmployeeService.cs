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
        private readonly string _userID;

        public EmployeeService(string userID)
        {
            _userID = userID;
        }
        public bool CreateEmployee(EmployeeCreate model)
        {
            var entity = new Employee()
            {
                User = _userID,
                Name = model.Name,
                DateOfBirth = model.DateOfBirth,
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
                var query = ctx.Employees.Where(e => e.User == _userID).Select(e => new EmployeeListItem
                {
                    EmployeeID = e.EmployeeID,
                    Name = e.Name,
                    DateOfBirth = e.DateOfBirth,
                    IdentifyAs = e.IdentifyAs,
                    Email = e.Email,
                    Salary = e.Salary,
                    Age = e.Age,
                    PhoneNumber = e.PhoneNumber,
                    MaritalStatus = (Models.EmployeeModel.MaritalStatus)e.MaritalStatus,
                    ListOfPositions = e.ListOfPositions.Count,
                    CreatedUTC = e.CreatedUTC
                });

                return query.ToArray();
            }
        }

        public EmployeeDetail GetEmployeeByID(int iD)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Employees.Single(e => e.EmployeeID == iD && e.User == _userID);

                return new EmployeeDetail
                {
                    EmployeeID = entity.EmployeeID,
                    Name = entity.Name,
                    DateOfBirth = entity.DateOfBirth,
                    IdentifyAs = entity.IdentifyAs,
                    Salary = entity.Salary,
                    Age = entity.Age,
                    PhoneNumber = entity.PhoneNumber,
                    MaritalStatus = (Models.EmployeeModel.MaritalStatus)entity.MaritalStatus,
                    ListOfPostions = entity.ListOfPositions.Count,
                    CreatedUTC = entity.CreatedUTC,
                    ModifiedUTC = entity.ModifiedUTC
                };
            }
        }

        public bool UpdateEmployee(EmployeeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Employees.Single(e => e.EmployeeID == model.EmployeeID && e.User == _userID);
                
                entity.Name = model.Name;
                entity.DateOfBirth = model.DateOfBirth;
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

        public bool DeleteEmployee(int employeeID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Employees.Single(e => e.EmployeeID == employeeID && e.User == _userID);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
