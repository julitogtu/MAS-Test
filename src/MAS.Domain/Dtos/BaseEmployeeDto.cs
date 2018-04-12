namespace MAS.Domain.Dtos
{
    /// <summary>
    /// Represents an employee.
    /// </summary>
    public class BaseEmployeeDto
    {
        /// <summary>
        /// Gets or sets the employee id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the employee name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the contract type of a given employee.
        /// </summary>
        public string ContractTypeName { get; set; }

        /// <summary>
        /// Gets or sets the role of a given employee.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets the role name of a given employee.
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// Gets or sets the role description.
        /// </summary>
        public string RoleDescription { get; set; }

        /// <summary>
        /// Gets or sets the hourly salary.
        /// </summary>
        public double HourlySalary { get; set; }

        /// <summary>
        /// Gets or sets the monthly salary.
        /// </summary>
        public double MonthlySalary { get; set; }
    }
}