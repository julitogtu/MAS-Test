using System;
using System.Linq;
using System.Web.Http;
using MAS.Domain.Domain;

namespace MAS.Web.Controllers
{
    /// <summary>
    /// Employees endpoint.
    /// </summary>
    [RoutePrefix("api/employees")]
    public class EmployeesController : ApiController
    {
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        }

        /// <summary>
        /// Returns all employees.
        /// </summary>
        /// <returns>List of employees.</returns>
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var employees = employeeService.GetAllEmployees();

            return employees.Any() ? (IHttpActionResult) Ok(employees) : NotFound();
        }

        /// <summary>
        /// Returns an employee by id.
        /// </summary>
        /// <param name="id">Employee id.</param>
        /// <returns>An employee.</returns>
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var employee = employeeService.GetEmployeeById(id);

            return employee is null ? (IHttpActionResult) NotFound() : Ok(employee);
        }
    }
}
