using System.Collections.Generic;
using MAS.Domain.Dtos;

namespace MAS.Domain.Domain
{
    /// <summary>
    /// Defines methods to magane the employees.
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// Gets all employees.
        /// </summary>
        /// <returns>A list of <see cref="EmployeeDto"/></returns>
        List<EmployeeDto> GetAllEmployees();

        /// <summary>
        /// Gets an employee by id.
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <returns>An employee</returns>
        EmployeeDto GetEmployeeById(int id);
    }
}