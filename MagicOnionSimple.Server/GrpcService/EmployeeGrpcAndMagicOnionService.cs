using Grpc.Core;
using MagicOnion;
using MagicOnionSimple.Models;
using MagicOnionSimple.Models.Request;
using MagicOnionSimple.ServerInterface;
using MagicOnionSimple.Shared.Message;

namespace MagicOnionSimple.Server.GrpcService {
    public class EmployeeGrpcAndMagicOnionService2  {
        private DbContextBase _dbContext;
        public EmployeeGrpcAndMagicOnionService2(DbContextBase dbContext) {
            _dbContext = dbContext;
        }

        public UnaryResult<ReplyMessage<List<Employee>>> GetEmployeeAsync(
            TimeRange request) {
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
            return new(result);
        }

        public UnaryResult<ReplyMessage<Employee>> GetEmployeeAsync2(string name) {
            var result = new ReplyMessage<Employee>();
            try {
                result.IsSuccess = true;
                result.Result = _dbContext.Employees.First(x => x.Name == name);
                result.Message = "Query successful";
                result.Description = $"Query successful, with a total of 1 pieces of data.";
            } catch (Exception ex) {
                result.Message = "Query failed";
                result.Description = ex.Message;
            }
            return new(result);
        }

        public IEmployeeGrpcAndMagicOnionService WithCancellationToken(CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }

        public IEmployeeGrpcAndMagicOnionService WithDeadline(DateTime deadline) {
            throw new NotImplementedException();
        }

        public IEmployeeGrpcAndMagicOnionService WithHeaders(Metadata headers) {
            throw new NotImplementedException();
        }

        public IEmployeeGrpcAndMagicOnionService WithHost(string host) {
            throw new NotImplementedException();
        }

        public IEmployeeGrpcAndMagicOnionService WithOptions(CallOptions option) {
            throw new NotImplementedException();
        }
    }
}
