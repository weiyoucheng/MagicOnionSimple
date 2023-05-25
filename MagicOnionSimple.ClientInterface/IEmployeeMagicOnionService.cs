

using MagicOnion;
using MagicOnionSimple.Dto.Request;
using MagicOnionSimple.Shared.Message;

namespace MagicOnionSimple.ClientInterface {
    public interface IEmployeeMagicOnionService: MagicOnion.IService<IEmployeeMagicOnionService>
    {
        UnaryResult<ReplyMessage<List<Dto.Employee>>> GetEmployee(Dto.Request.TimeRange request);

        UnaryResult<ReplyMessage<List<Dto.Employee>>> GetEmployeeByName(string name);
    }
}
