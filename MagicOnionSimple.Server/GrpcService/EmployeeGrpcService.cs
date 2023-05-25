using MagicOnionSimple.Models;
using MagicOnionSimple.Models.Request;
using MagicOnionSimple.Shared.Message;
using ProtoBuf.Grpc;

namespace MagicOnionSimple.Server.GrpcService {

    public class EmployeeGrpcService: ServerInterface.IEmployeeGrpcService
    {
        private DbContextBase _dbContext;
        public EmployeeGrpcService(DbContextBase dbContext) {
            _dbContext = dbContext;
        }

        public ReplyMessage<List<Employee>> GetEmployee(
            Models.Request.TimeRange request, CallContext callContext = default) {
            var result = new ReplyMessage<List<Employee>>();
            try {
                result.IsSuccess = true;
                result.Result = _dbContext.Employees
                    .Where(x => x.CreateTime >= request.StartTime && x.CreateTime <= request.EndTime)
                    .ToList();
                result.Message = "Query successful";
                result.Description = $"Query successful, with a total of {result.Result.Count} pieces of data.";
            } catch (Exception ex) {
                result.Message = "Query failed";
                result.Description = ex.Message;
            }
            return result;
        }

        public ReplyMessage<Employee> GetEmployee(string name, CallContext callContext = default) {
            var result = new ReplyMessage<Employee>();
            try {
                result.IsSuccess = true;
                result.Result = _dbContext.Employees.First(x=>x.Name == name);
                result.Message = "Query successful";
                result.Description = $"Query successful, with a total of 1 pieces of data.";
            } catch (Exception ex) {
                result.Message = "Query failed";
                result.Description = ex.Message;
            }
            return result;
        }

        public ValueTask<ReplyMessage<List<Employee>>> GetEmployeeAsync(
            Models.Request.TimeRange request, CallContext callContext = default) {
            return new(GetEmployee(request, callContext));
        }

        public ValueTask<ReplyMessage<Employee>> GetEmployeeAsync(string name, CallContext callContext = default) {
            return new(GetEmployee(name, callContext));
        }
    }
}
