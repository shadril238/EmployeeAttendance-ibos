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
        [HttpGet]
        [Route("api/employees/{id}")]
        public IActionResult GetEmployee(int id)
        {
            try
            {
                var data = _employeeService.Get(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
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
        [HttpPost]
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
