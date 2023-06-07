using AutoMapper;
using BLL.DTOs;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BLL.Services
{
    public class EmployeeAttendanceService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeAttendanceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // Find all employee who is absent at least one day
        public List<EmployeeDTO> GetAllEmployeesWithAbsent()
        {
            var employeeAttendanceData = GetAllEmployeesAttendance();
            var employees = _unitOfWork.Employee.GetAll().ToList();

            var data = employees
                .Where(e => employeeAttendanceData.Any(a => a.EmployeeId == e.Id && a.IsAbsent == 1 && a.IsOffday == 0)).ToList();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<EmployeeDTO>>(data);
            return mapped;
        }
        // Get monthly attendance report of all employee
        public List<MonthlyAttendanceReportDTO> MonthlyAttendanceReport()
        {
            var monthName = DateTime.Now.ToString("MMMM");
            var employeeAttendanceData = GetAllEmployeesAttendance();
            var employees = _unitOfWork.Employee.GetAll().ToList();

            var report = employees
                .Select(e => new MonthlyAttendanceReportDTO
                {
                    EmployeeName = e.Name,
                    MonthName = monthName,
                    TotalPresent = employeeAttendanceData.Count(a => a.EmployeeId == e.Id && a.IsPresent == 1),
                    TotalAbsent = employeeAttendanceData.Count(a => a.EmployeeId == e.Id && a.IsAbsent == 1),
                    TotalOffDay = employeeAttendanceData.Count(a => a.EmployeeId == e.Id && a.IsOffday == 1)
                }).ToList();
            return report;
        }

        // Get all employees attendance
        public List<AttendanceDTO> GetAllEmployeesAttendance()
        {
            var attendances = _unitOfWork.EmployeeAttendance.GetAll().ToList();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<EmployeeAttendance, AttendanceDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<AttendanceDTO>>(attendances);
            return mapped;
        }
        // Get employee attendance
        public AttendanceDTO GetEmployeeAttendance(int id)
        {
            var data = _unitOfWork.EmployeeAttendance.Get(a => a.Id == id);

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<EmployeeAttendance, AttendanceDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<AttendanceDTO>(data);
            return mapped;
        }
        // Add attendance
        public bool Add(AttendanceDTO attendance)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<AttendanceDTO, EmployeeAttendance>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<EmployeeAttendance>(attendance);
            _unitOfWork.EmployeeAttendance.Add(mapped);
            return _unitOfWork.Save();
        }
        // Update attendance
        public bool Edit(AttendanceDTO attendance)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<AttendanceDTO, EmployeeAttendance>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<EmployeeAttendance>(attendance);
            _unitOfWork.EmployeeAttendance.Update(mapped);
            return _unitOfWork.Save();
        }
        // Delete attendance
        public bool Delete(int id)
        {
            _unitOfWork.EmployeeAttendance.Remove(id);
            return _unitOfWork.Save();
        }
    }
}
