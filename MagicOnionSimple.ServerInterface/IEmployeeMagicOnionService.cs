

using MagicOnion;
using MagicOnionSimple.Models.Request;
using MagicOnionSimple.Shared.Message;

namespace MagicOnionSimple.ServerInterface {
    public interface IEmployeeMagicOnionService : IService<IEmployeeMagicOnionService> {
        UnaryResult<ReplyMessage<List<Models.Employee>>> GetEmployee(TimeRange request);

        UnaryResult<ReplyMessage<Models.Employee>> GetEmployeeByName(string name);
    }
}
