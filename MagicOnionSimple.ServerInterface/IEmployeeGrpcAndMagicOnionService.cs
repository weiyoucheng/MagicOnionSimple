using ProtoBuf.Grpc.Configuration;
using MagicOnionSimple.Shared.Message;
using MagicOnionSimple;
using ProtoBuf.Grpc;
using MagicOnionSimple.Models.Request;
using MagicOnion;

namespace MagicOnionSimple.ServerInterface {

    /// <summary>
    /// Using the Grpc method to query the employee list interface
    /// (Marking the service name can eliminate the need for the client 
    /// and server to share the same interface, as long as the interface 
    /// method and parameter type are the same)
    /// </summary>
    [Service("EmployeeGrpcAndMagicOnionService")]
    public interface IEmployeeGrpcAndMagicOnionService : IService<IEmployeeGrpcAndMagicOnionService> {

        /// <summary>
        /// Query employee list based on time range (asynchronous method).
        /// </summary>
        /// <param name="request">Query time range</param>
        /// <param name="callContext">Used for request header submission and backend access to IP information, etc</param>
        /// <returns>employee list</returns>
        [Operation]
        public UnaryResult<ReplyMessage<List<Models.Employee>>> GetEmployeeAsync(
            Models.Request.TimeRange request);

        /// <summary>
        /// Query employee list based on user name(asynchronous method).
        /// </summary>
        /// <param name="name">Name of employee to query</param>
        /// <param name="callContext">Used for request header submission and backend access to IP information, etc</param>
        /// <returns>employee list</returns>
        [Operation]
        public UnaryResult<ReplyMessage<Models.Employee>> GetEmployeeAsync2(string name);

    }
}