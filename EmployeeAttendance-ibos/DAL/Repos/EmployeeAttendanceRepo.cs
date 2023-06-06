using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class EmployeeAttendanceRepo : Repo<EmployeeAttendance>, IEmployeeAttendanceRepo
    {
        private readonly ApplicationDbContext _db;
        public EmployeeAttendanceRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(EmployeeAttendance entity)
        {
            var objFromDb = _db.EmployeeAttendances.FirstOrDefault(e => e.Id == entity.Id);
            if (objFromDb != null)
            {
                _db.Entry(objFromDb).CurrentValues.SetValues(entity);
            }
        }
    }
}
