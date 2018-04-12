using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using MAS.Domain.Dtos;
using MAS.Domain.Exception;
using MAS.Domain.Services;
using Newtonsoft.Json;
using RestSharp;

namespace MAS.Domain.Dao
{
    /// <summary>
    /// Manages employees.
    /// </summary>
    public class EmployeeRepository : BaseService, IEmployeeRepository
    {
        private readonly RestClient client;

        public EmployeeRepository()
        {
            client = CreateRestClient(ConfigurationManager.AppSettings[Constants.EmployeeBaseServiceUrl]);
        }

        /// <inheritdoc />
        public List<BaseEmployeeDto> GetAllEmployees()
        {
            var request = CreateRestRequest(Constants.GetAllEmployeesRoute, Method.GET);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.InternalServerError)
            {
                var ex = new EmployeeServiceException(Convert.ToInt32(response.StatusCode), "");
                throw ex;
            }

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseDto = JsonConvert.DeserializeObject<List<BaseEmployeeDto>>(response.Content);
                return responseDto;
            }

            throw new EmployeeServiceException(500, "General error calling the employee service");
        }

        /// <inheritdoc />
        public BaseEmployeeDto GetEmployeeById(int id)
        {
            var employees = GetAllEmployees();

            return !employees.Any() ? null : employees.FirstOrDefault(c => c.Id.Equals(id));
        }
    }
}