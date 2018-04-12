using System.Collections.Generic;
using MAS.Domain.Dtos;

namespace MAS.Domain.Dao
{
    /// <summary>
    /// Manages employees.
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Gets all employees.
        /// </summary>
        /// <returns>A list of <see cref="BaseEmployeeDto"/></returns>
        List<BaseEmployeeDto> GetAllEmployees();

        /// <summary>
        /// Gets an employee by id.
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <returns>An employee</returns>
        BaseEmployeeDto GetEmployeeById(int id);
    }
}