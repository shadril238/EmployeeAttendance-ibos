using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class MonthlyAttendanceReportDTO
    {
        public string EmployeeName { get; set; }
        public string MonthName { get; set; }
        public int TotalPresent { get; set; }
        public int TotalAbsent { get; set; }
        public int TotalOffDay { get; set; }

    }
}
