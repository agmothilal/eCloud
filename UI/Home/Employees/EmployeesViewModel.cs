﻿using Code.Model.Abstract;
using EmployeePortfolio;
using Home.CommandHelper;
using Home.NavigationHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace Home.Employees
{
    public sealed class EmployeesViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IEmployeePortfolio _employeePortfolio;

        public ObservableCollection<IEmployee> AllEmployees { get; }
        public IEmployee Employee { get; private set; }

        public ICommand DeleteEmployeeCommand { get; }
        public ICommand NavigateToEditEmployeeCommand { get; }
        public ICommand NavigateToEmployeesCommand { get; }
        public ICommand UpdateEmployeeCommand { get; }

        public EmployeesViewModel(INavigationService navigationService, IEmployeePortfolio employeePortfolio)
        {
            _navigationService = navigationService;
            _employeePortfolio = employeePortfolio;

            AllEmployees = new ObservableCollection<IEmployee>();
            NavigateToEditEmployeeCommand = new RelayCommand<IEmployee>(NavigateToEditEmployee);
            NavigateToEmployeesCommand = new RelayCommand(() => _navigationService.NavigateTo("Employees"));
            UpdateEmployeeCommand = new RelayCommand(UpdateEmployee);
            DeleteEmployeeCommand = new RelayCommand<IEmployee>(DeletEmployee);

            InitiateEmployees(employeePortfolio.Employees);
        }

        private void InitiateEmployees(IEnumerable<IEmployee> employees)
        {
            AllEmployees.Clear();
            foreach (var employee in employees)
            {
                AllEmployees.Add(employee);
            }
        }

        private void NavigateToEditEmployee(IEmployee employee)
        {
            Employee = employee;
            _navigationService.NavigateTo("EditEmployee");
        }

        private void UpdateEmployee()
        {
            _employeePortfolio.Update(Employee);
            _navigationService.NavigateTo("Employees");
        }

        private void DeletEmployee(IEmployee employee)
        {
            _employeePortfolio.Delete(employee);
            InitiateEmployees(_employeePortfolio.Employees);
        }
    }
}

