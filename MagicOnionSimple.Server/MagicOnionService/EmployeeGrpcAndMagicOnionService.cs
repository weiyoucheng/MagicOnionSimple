using MagicOnion;
using MagicOnion.Server;
using MagicOnionSimple.Models;
using MagicOnionSimple.Models.Request;
using MagicOnionSimple.ServerInterface;
using MagicOnionSimple.Shared.Message;
using ProtoBuf.Grpc;

namespace MagicOnionSimple.Server.MagicOnionService
{

    public class EmployeeGrpcAndMagicOnionService : ServiceBase<IEmployeeGrpcAndMagicOnionService>, IEmployeeGrpcAndMagicOnionService {
        private DbContextBase _dbContext;
        public EmployeeGrpcAndMagicOnionService(DbContextBase dbContext)
        {
            _dbContext = dbContext;
        }

        public UnaryResult<ReplyMessage<List<Employee>>> GetEmployeeAsync(
            TimeRange request)
        {
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

        public UnaryResult<ReplyMessage<Employee>> GetEmployeeAsync2(string name)
        {
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

    }
}
