using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class EmployeeRepo : Repo<Employee>, IEmployeeRepo
    {
        private readonly ApplicationDbContext _db;
        public EmployeeRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Employee employee)
        {
            var objFromDb = _db.Employees.FirstOrDefault(e => e.Id == employee.Id);
            if (objFromDb != null)
            {
                _db.Entry(objFromDb).CurrentValues.SetValues(employee);
            }
        }
    }
}
