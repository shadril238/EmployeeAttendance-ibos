using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAttendance_ibos.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;
        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // Update an employee’s Employee Code [Don't allow duplicate employee code]
        [HttpPost]
        [Route("api/employees/updatecode")]
        public IActionResult UpdateEmployeeCode(EmployeeDTO employee)
        {
            try
            {
                var data = _employeeService.UpdateEmployeeCode(employee);
                return Ok(new { Message = "Row updated successfully.", Data = data });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // Get all employees based on maximum to minimum salary
        [HttpGet]
        [Route("api/employees/getbysalarydesc")]
        public IActionResult GetAllEmployeesBySalaryDesc()
        {
            try
            {
                var data = _employeeService.GetEmployeesBySalary();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
