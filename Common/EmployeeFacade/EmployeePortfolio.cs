﻿using Code.Model.Abstract;
using SqlDbContext;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePortfolio
{
    public class EmployeePortfolio : IEmployeePortfolio
    {
        private readonly ISqlData _sqlData;
        private readonly IEmployeeFactory _employeeFactory;

        public IEnumerable<IEmployee> Employees => _sqlData.Employees;

        public EmployeePortfolio(ISqlData sqlData, IEmployeeFactory employeeFactory)
        {
            _sqlData = sqlData;
            _employeeFactory = employeeFactory;
        }

        public IEmployee CrateEmptyEmployee()
        {
            return _employeeFactory.Create();
        }

        public IEmployee Add(IEmployee employee)
        {
            employee.Id = _sqlData.Employees.Max(x => x.Id) + 1;
            _sqlData.Employees.Add(employee);
            return employee;
        }

        public void Update(IEmployee employee)
        {
            var dbEmployee = _sqlData.Employees.FirstOrDefault(x => x.Id == employee.Id);
            dbEmployee = employee;
        }

        public bool Delete(IEmployee employee)
        {
            return _sqlData.Employees.Remove(employee);
        }
    }
}
