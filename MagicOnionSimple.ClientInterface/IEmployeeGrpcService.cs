using MagicOnionSimple.Dto.Request;
using MagicOnionSimple.Shared.Message;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace MagicOnionSimple.ClientInterface {
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
        public ReplyMessage<List<Dto.Employee>> GetEmployee(Dto.Request.TimeRange request, CallContext callContext = default);

        /// <summary>
        /// Query employee list based on time range (asynchronous method).
        /// </summary>
        /// <param name="request">Query time range</param>
        /// <param name="callContext">Used for request header submission and backend access to IP information, etc</param>
        /// <returns>employee list</returns>

        [Operation("GetEmployeeAsync")] //To achieve function overloading by adding method names(By default, GetEmployee and GetEmployeeAsync are considered the same method, so a method name must be added to avoid reporting that the method already exists)
        public ValueTask<ReplyMessage<List<Dto.Employee>>> GetEmployeeAsync(Dto.Request.TimeRange request, CallContext callContext = default);

        /// <summary>
        /// Query employee list based on user name
        /// </summary>
        /// <param name="name">QName of employee to query</param>
        /// <param name="callContext">Used for request header submission and backend access to IP information, etc</param>
        /// <returns>employee list</returns>
        [Operation("GetEmployee2")] //Add unique method names to achieve function overloading effect
        public ReplyMessage<Dto.Employee> GetEmployee(string name, CallContext callContext = default);

        /// <summary>
        /// Query employee list based on user name(asynchronous method).
        /// </summary>
        /// <param name="name">Name of employee to query</param>
        /// <param name="callContext">Used for request header submission and backend access to IP information, etc</param>
        /// <returns>employee list</returns>
        [Operation("GetEmployeeAsync2")] //Add unique method names to achieve function overloading effect
        public ValueTask<ReplyMessage<Dto.Employee>> GetEmployeeAsync(string name, CallContext callContext = default);

    }
}