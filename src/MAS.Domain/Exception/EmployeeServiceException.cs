namespace MAS.Domain.Exception
{
    /// <summary>
    /// Employee service exception.
    /// </summary>
    public class EmployeeServiceException : System.Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeServiceException"/> class.
        /// </summary>
        public EmployeeServiceException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeServiceException"/> class.
        /// </summary>
        /// <param name="code">HTTP response code.</param>
        /// <param name="reason">HTTP error reason.</param>
        public EmployeeServiceException(int code, string reason)
        {
            Code = code;
            Reason = reason;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeServiceException"/> class.
        /// </summary>
        /// <param name="code">HTTP response code.</param>
        /// <param name="reason">HTTP error reason.</param>
        /// <param name="description">HTTP error description.</param>
        public EmployeeServiceException(int code, string reason, string description)
        {
            Code = code;
            Reason = reason;
            Description = description;
        }

        /// <summary>
        /// Gets HTTP Status code.
        /// </summary>
        public int Code { get; }

        /// <summary>
        /// Gets HTTP fail reason.
        /// </summary>
        public string Reason { get; }

        /// <summary>
        /// Gets the error description.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        public dynamic Content { get; set; }
    }
}