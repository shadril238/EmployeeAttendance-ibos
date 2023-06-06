using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public double Salary { get; set; }

        public virtual ICollection<EmployeeAttendance> EmployeeAttendance { get; }

        public Employee()
        {
            EmployeeAttendance = new List<EmployeeAttendance>();
        }
    }
}
