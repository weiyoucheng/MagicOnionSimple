using ProtoBuf.Grpc.Configuration;
using MagicOnionSimple.Shared.Message;
using MagicOnionSimple;
using ProtoBuf.Grpc;
using MagicOnionSimple.Models.Request;

namespace MagicOnionSimple.ServerInterface {

    /// <summary>
    /// Using the Grpc method to query the employee list interface
    /// (Marking the service name can eliminate the need for the client 
    /// and server to share the same interface, as long as the interface 
    /// method and parameter type are the same)
    /// </summary>
    [Service("EmployeeService")]
    public interface IEmployeeGrpcService {

        /// <summary>
        /// Query employee list based on time range.
        /// </summary>
        /// <param name="request">Query time range</param>
        /// <param name="callContext">Used for request header submission and backend access to IP information, etc</param>
        /// <returns>employee list</returns>
        [Operation]
        public ReplyMessage<List<Models.Employee>> GetEmployee(
            Models.Request.TimeRange request,CallContext callContext = default);

        /// <summary>
        /// Query employee list based on time range (asynchronous method).
        /// </summary>
        /// <param name="request">Query time range</param>
        /// <param name="callContext">Used for request header submission and backend access to IP information, etc</param>
        /// <returns>employee list</returns>

        [Operation("GetEmployeeAsync")] //To achieve function overloading by adding method names(By default, GetEmployee and GetEmployeeAsync are considered the same method, so a method name must be added to avoid reporting that the method already exists)
        public ValueTask<ReplyMessage<List<Models.Employee>>> GetEmployeeAsync(
            Models.Request.TimeRange request, CallContext callContext = default);

        /// <summary>
        /// Query employee list based on user name
        /// </summary>
        /// <param name="name">Name of employee to query</param>
        /// <param name="callContext">Used for request header submission and backend access to IP information, etc</param>
        /// <returns>employee list</returns>
        [Operation("GetEmployee2")] //Add unique method names to achieve function overloading effect
        public ReplyMessage<Models.Employee> GetEmployee(string name, CallContext callContext = default);

        /// <summary>
        /// Query employee list based on user name(asynchronous method).
        /// </summary>
        /// <param name="name">Name of employee to query</param>
        /// <param name="callContext">Used for request header submission and backend access to IP information, etc</param>
        /// <returns>employee list</returns>
        [Operation("GetEmployeeAsync2")] //Add unique method names to achieve function overloading effect
        public ValueTask<ReplyMessage<Models.Employee>> GetEmployeeAsync(string name, CallContext callContext = default);

    }
}