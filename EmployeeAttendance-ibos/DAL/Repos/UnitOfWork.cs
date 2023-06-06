using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IEmployeeRepo Employee { get;  private set; }
        public IEmployeeAttendanceRepo EmployeeAttendance { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Employee = new EmployeeRepo(_db);
            EmployeeAttendance = new EmployeeAttendanceRepo(_db);
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }
    }
}
