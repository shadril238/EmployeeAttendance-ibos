using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAttendance_ibos.Controllers
{
    [ApiController]
    public class EmployeeAttendanceController : ControllerBase
    {
        private readonly EmployeeAttendanceService _employeeAttendanceService;
        public EmployeeAttendanceController(EmployeeAttendanceService employeeAttendanceService)
        {
            _employeeAttendanceService = employeeAttendanceService;
        }
        // Find all employee who is absent at least one day
        [HttpGet]
        [Route("api/attendances/absent")]
        public IActionResult GetAllEmployeesWithAbsent()
        {
            try
            {
                var data = _employeeAttendanceService.GetAllEmployeesWithAbsent();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // Get monthly attendance report of all employee
        [HttpGet]
        [Route("api/attendances/monthlyreport")]
        public IActionResult GetMonthlyAttendanceReport() 
        {
            try
            {
                var data = _employeeAttendanceService.MonthlyAttendanceReport();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
