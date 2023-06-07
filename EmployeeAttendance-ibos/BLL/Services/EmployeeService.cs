using AutoMapper;
using BLL.DTOs;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Update an employee’s Employee Code [Don't allow duplicate employee code]
        public bool UpdateEmployeeCode(EmployeeDTO employee)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<EmployeeDTO, Employee>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Employee>(employee);


            var exstEmployeeByCode = GetByCode(mapped.Code);
            if (exstEmployeeByCode != null && exstEmployeeByCode.Id != mapped.Id)
            {
                throw new Exception("Duplicate employee code not allowed.");
            }

            var exstEmployeeById = GetById(mapped.Id);
            _unitOfWork.Employee.Update(mapped);
            return _unitOfWork.Save();
        }

        // Get all employees based on maximum to minimum salary
        public List<EmployeeDTO> GetEmployeesBySalary()
        {
            var data = GetAll().OrderByDescending(e => e.Salary).ToList();
            return data;
        }

        // Get All Employees
        public List<EmployeeDTO> GetAll()
        {
            var data = _unitOfWork.Employee.GetAll().ToList();
            
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<EmployeeDTO>>(data);
            return mapped;
        }
        // Get Employee by EmpCode
        public EmployeeDTO GetByCode(string code)
        {
            var data = _unitOfWork.Employee.Get(e => e.Code.Equals(code));

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<EmployeeDTO>(data);
            return mapped;
        }
        // Get Employee by Id
        public EmployeeDTO GetById(int id)
        {
            var data = _unitOfWork.Employee.Get( e => e.Id == id );

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<EmployeeDTO>(data);
            return mapped;
        }
        // Add Employee
        public bool Add(EmployeeDTO employee)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<EmployeeDTO, Employee>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Employee>(employee);
            _unitOfWork.Employee.Add(mapped);
            return _unitOfWork.Save();   
        }
        // Update Employee
        public bool Update(EmployeeDTO employee)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<EmployeeDTO, Employee>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Employee>(employee);
            _unitOfWork.Employee.Update(mapped);
            return _unitOfWork.Save();
        }
        // Delete Employee
        public bool Delete(int id)
        {
            _unitOfWork.Employee.Remove(id);
            return _unitOfWork.Save();
        }
    }
}
