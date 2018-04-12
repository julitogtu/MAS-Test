using System.Collections.Generic;
using MAS.Domain.Dao;
using MAS.Domain.Domain;
using MAS.Domain.Dtos;
using Moq;
using Shouldly;
using Xunit;

namespace MAS.Tests
{
    [Trait("Category", "Unit")]
    public class EmployeeServiceTests
    {
        [Fact(DisplayName = "When not employees should return empty list")]
        public void WhenNotEmployeesShouldReturnEmptyList()
        {
            var employeeRepositoryMock = new Mock<IEmployeeRepository>();
            employeeRepositoryMock.Setup(c => c.GetAllEmployees()).Returns(() => null);

            var employeeService = new EmployeeService(employeeRepositoryMock.Object);

            var result = employeeService.GetAllEmployees();

            result.ShouldNotBeNull();
            result.ShouldBeEmpty();
        }

        [Fact(DisplayName = "When has employees should return employee list")]
        public void WhenHasEmployeesShouldReturnEmplpoyeeList()
        {
            var employeeRepositoryMock = new Mock<IEmployeeRepository>();
            employeeRepositoryMock.Setup(c => c.GetAllEmployees()).Returns(() => new List<BaseEmployeeDto>()
            {
                new BaseEmployeeDto()
                {
                    Id = 1,
                    Name = "Bruce Wayne",
                    MonthlySalary = 100,
                    HourlySalary = 200,
                    RoleName = "Hero",
                    RoleId = 1,
                    RoleDescription = "Hero description",
                    ContractTypeName = "HourlySalaryEmployee"
                }
            });

            var employeeService = new EmployeeService(employeeRepositoryMock.Object);

            var result = employeeService.GetAllEmployees();

            result.ShouldNotBeEmpty();
        }

        [Fact(DisplayName = "When employee does not exist should return null")]
        public void WhenEmployeesDoesNotExistShouldReturnNull()
        {
            var employeeRepositoryMock = new Mock<IEmployeeRepository>();
            employeeRepositoryMock.Setup(c => c.GetEmployeeById(It.IsAny<int>())).Returns(() => new EmployeeDto());
            employeeRepositoryMock.Setup(c => c.GetEmployeeById(It.Is<int>(x => x == 10))).Returns(() => null);

            var employeeService = new EmployeeService(employeeRepositoryMock.Object);

            var result = employeeService.GetEmployeeById(10);

            result.ShouldBeNull();
        }

        [Fact(DisplayName = "When employee exist should return employee")]
        public void WhenEmployeesExistShouldReturnEmployee()
        {
            var employeeRepositoryMock = new Mock<IEmployeeRepository>();
            employeeRepositoryMock.Setup(c => c.GetEmployeeById(It.IsAny<int>())).Returns(() => new EmployeeDto()
            {
                Id = 1,
                Name = "Bruce Wayne",
                MonthlySalary = 100,
                HourlySalary = 200,
                RoleName = "Hero",
                RoleId = 1,
                RoleDescription = "Hero description",
                ContractTypeName = "HourlySalaryEmployee"
            });

            var employeeService = new EmployeeService(employeeRepositoryMock.Object);

            var result = employeeService.GetEmployeeById(10);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<EmployeeDto>();
        }
    }
}