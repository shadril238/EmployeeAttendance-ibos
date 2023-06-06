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

        public EmployeeDTO Get(int id)
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

        public bool Delete(int id)
        {
            _unitOfWork.Employee.Remove(id);
            return _unitOfWork.Save();
        }
    }
}
