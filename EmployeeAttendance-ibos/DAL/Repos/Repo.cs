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
    internal class Repo<T> : IRepo<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repo(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>(); //dbSet == _db.Employee; when T == Employee
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public void Remove(int id)
        {
            var employeesToRemove = _db.Employees.FirstOrDefault(e => e.Id == id);
            if(employeesToRemove != null)
            {
                _db.Employees.Remove(employeesToRemove);
            }
        }
    }
}
