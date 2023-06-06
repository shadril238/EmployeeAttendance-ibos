using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DAL.Models
{
    public class EmployeeAttendance
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [Required]
        public DateTime AttendanceDate { get; set; }
        [Required]
        [Range(0, 1)]
        public int IsPresent { get; set; }
        [Required]
        [Range(0, 1)]
        public int IsAbsent { get; set; }
        [Required]
        [Range(0, 1)]
        public int IsOffday { get; set; }
        [ValidateNever]
        public virtual Employee Employee { get; set; }
    }
}
