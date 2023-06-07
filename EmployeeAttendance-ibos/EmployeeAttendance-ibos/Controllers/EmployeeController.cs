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
        // Get all employees
        [HttpGet]
        [Route("api/employees")]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var data = _employeeService.GetAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // Get employee by Id
        [HttpGet]
        [Route("api/employees/{id}")]
        public IActionResult GetEmployee(int id)
        {
            try
            {
                var data = _employeeService.GetById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // Add employee
        [HttpPost]
        [Route("api/employees/add")]
        public IActionResult AddEmployee(EmployeeDTO employee)
        {
            try
            {
                var data = _employeeService.Add(employee);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // Update employee
        [HttpPost]
        [Route("api/employees/edit")]
        public IActionResult Edit(EmployeeDTO employee)
        {
            try
            {
                var data = _employeeService.Update(employee);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // Delete employee
        [HttpDelete]
        [Route("api/employees/delete/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var data = _employeeService.Delete(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
