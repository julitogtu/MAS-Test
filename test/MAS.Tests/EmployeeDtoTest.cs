using MAS.Domain.Dtos;
using Shouldly;
using Xunit;

namespace MAS.Tests
{
    [Trait("Category", "Unit")]
    public class EmployeeDtoTest
    {
        [Fact(DisplayName = "When new employee is create anual salary should be null")]
        public void WhenNewEmployeeIsCreateAnualSalaryShouldBeNull()
        {
            var employee = new EmployeeDto();

            employee.AnualSalary.ShouldBeNull();
        }

        [Fact(DisplayName = "When employee has monthly salary must calculate anual salary")]
        public void WhenEmployeeHasMonthlySalaryMustCalculateAnualSalary()
        {
            var baseEmployee = new BaseEmployeeDto()
            {
                Id = 1,
                Name = "Bruce Wayne",
                MonthlySalary = 100,
                HourlySalary = 200,
                RoleName = "Hero",
                RoleId = 1,
                RoleDescription = "Hero description",
                ContractTypeName = "MonthlySalaryEmployee"
            };

            var employee = EmployeeDto.ConvertFrom(baseEmployee);

            employee.AnualSalary.ShouldNotBeNull();
            employee.AnualSalary.ShouldBe(100 * 12);
        }

        [Fact(DisplayName = "When employee has hourly salary must calculate anual salary")]
        public void WhenEmployeeHasHourlySalaryMustCalculateAnualSalary()
        {
            var baseEmployee = new BaseEmployeeDto()
            {
                Id = 1,
                Name = "Bruce Wayne",
                MonthlySalary = 100,
                HourlySalary = 200,
                RoleName = "Hero",
                RoleId = 1,
                RoleDescription = "Hero description",
                ContractTypeName = "HourlySalaryEmployee"
            };

            var employee = EmployeeDto.ConvertFrom(baseEmployee);

            employee.AnualSalary.ShouldNotBeNull();
            employee.AnualSalary.ShouldBe(120 * 200 * 12);
        }

        [Fact(DisplayName = "When employee does not have salary anual salary should be null")]
        public void WhenEmployeeDoesNotHaveSalaryAnualSalaryShouldBeNull()
        {
            var baseEmployee = new BaseEmployeeDto()
            {
                Id = 1,
                Name = "Bruce Wayne",
                MonthlySalary = 100,
                HourlySalary = 200,
                RoleName = "Hero",
                RoleId = 1,
                RoleDescription = "Hero description",
                ContractTypeName = string.Empty
            };

            var employee = EmployeeDto.ConvertFrom(baseEmployee);

            employee.AnualSalary.ShouldBeNull();
        }
    }
}