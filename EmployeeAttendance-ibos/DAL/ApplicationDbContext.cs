using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> tblEmployee { get; set; }
        public DbSet<EmployeeAttendance> tblEmployeeAttendance { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // for unique employeeCode
            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.Code)
                .IsUnique();
            // for AttendanceDate to be only Date format
            modelBuilder.Entity<EmployeeAttendance>()
                .Property(e => e.AttendanceDate)
                .HasColumnType("date");

            // seed data for Employee
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 502030, Name = "Mehedi Hasan", Code = "EMP319", Salary = 50000 },
                new Employee { Id = 502031, Name = "Ashikur Rahman", Code = "EMP321", Salary = 45000 },
                new Employee { Id = 502032, Name = "Rakibul Islam", Code = "EMP322", Salary = 52000 }
            );

            // seed data for EmlpoyeeAttendance
            modelBuilder.Entity<EmployeeAttendance>().HasData(
                new EmployeeAttendance { Id = 1, EmployeeId = 502030, AttendanceDate = new DateTime(2023, 6, 24), IsPresent = 1, IsAbsent = 0, IsOffday = 0 },
                new EmployeeAttendance { Id = 2, EmployeeId = 502030, AttendanceDate = new DateTime(2023, 6, 25), IsPresent = 0, IsAbsent = 1, IsOffday = 0 },
                new EmployeeAttendance { Id = 3, EmployeeId = 502031, AttendanceDate = new DateTime(2023, 6, 25), IsPresent = 1, IsAbsent = 0, IsOffday = 0 }
            );
        }
    }
}