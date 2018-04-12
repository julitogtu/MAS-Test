using System;
using MAS.Domain.Enums;

namespace MAS.Domain.Dtos
{
    /// <summary>
    /// Represents an employee.
    /// </summary>
    public class EmployeeDto : BaseEmployeeDto
    {
        /// <summary>
        /// Gets or sets the anual salary.
        /// </summary>
        public double? AnualSalary { get; private set; }

        /// <summary>
        /// Calculates the anual salary based on the contract type.
        /// </summary>
        private void CalculateAnualSalary()
        {
            if (string.IsNullOrWhiteSpace(ContractTypeName))
                return;

            if (ContractTypeName.Equals(EmployeeContractType.HourlySalaryEmployee.ToString(),
                StringComparison.InvariantCultureIgnoreCase))
                AnualSalary = 120 * HourlySalary * 12;
            else if (ContractTypeName.Equals(EmployeeContractType.MonthlySalaryEmployee.ToString(),
                StringComparison.InvariantCultureIgnoreCase))
                AnualSalary = MonthlySalary * 12;
        }

        public static EmployeeDto ConvertFrom(BaseEmployeeDto entity)
        {
            var employee = new EmployeeDto
            {
                Id = entity.Id,
                ContractTypeName = entity.ContractTypeName,
                HourlySalary = entity.HourlySalary,
                MonthlySalary = entity.MonthlySalary,
                Name = entity.Name,
                RoleDescription = entity.RoleDescription,
                RoleId = entity.RoleId,
                RoleName = entity.RoleName
            };

            employee.CalculateAnualSalary();

            return employee;
        }
    }
}