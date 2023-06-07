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
        // All attendances
        [HttpGet]
        [Route("api/attendances")]
        public IActionResult GetEmployeeAttendances()
        {
            try
            {
                var data = _employeeAttendanceService.
                    GetAllEmployeesAttendance().
                    Select(a => new
                    {
                        a.Id,
                        a.EmployeeId,
                        a.AttendanceDate,
                        a.IsPresent,
                        a.IsAbsent,
                        a.IsOffday,
                    }).ToList();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // Add attendance
        [HttpPost]
        [Route("api/attendances/add")]
        public IActionResult AddEmployeeAttendance(AttendanceDTO attendance)
        {
            try
            {
                var data = _employeeAttendanceService.Add(attendance);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // Update attendance
        [HttpPost]
        [Route("api/attendances/edit")]
        public IActionResult EditEmployeeAttendance(AttendanceDTO attendance)
        {
            try
            {
                var data = _employeeAttendanceService.Edit(attendance);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // Delete attendance
        [HttpPost]
        [Route("api/attendances/delete/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var data = _employeeAttendanceService.Delete(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
