﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IEmployeeRepo : IRepo<Employee>
    {
        // Update Employee Code
        void UpdateEmployeeCode(Employee employee);
        // Update all
        void Update(Employee employee);
    }
}
