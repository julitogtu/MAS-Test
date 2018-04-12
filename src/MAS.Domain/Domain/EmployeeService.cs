using System;
using System.Collections.Generic;
using System.Linq;
using MAS.Domain.Dao;
using MAS.Domain.Dtos;

namespace MAS.Domain.Domain
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public List<EmployeeDto> GetAllEmployees()
        {
            var employees = employeeRepository.GetAllEmployees();

            if (employees is null || !employees.Any()) return new List<EmployeeDto>();

            var result = new List<EmployeeDto>();
            employees.ForEach(c =>
            {
                result.Add(EmployeeDto.ConvertFrom(c));
            });

            return result;
        }

        public EmployeeDto GetEmployeeById(int id)
        {
            var employee = employeeRepository.GetEmployeeById(id);

            return employee is null ? null : EmployeeDto.ConvertFrom(employee);
        }
    }
}