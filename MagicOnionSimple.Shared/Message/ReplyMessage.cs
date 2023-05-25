using ProtoBuf;
namespace MagicOnionSimple.Shared.Message
{

    [MessagePack.MessagePackObject(true)]
    [ProtoContract]
    public class ReplyMessage<T>
    {

        [ProtoMember(1)]
        public string Message { get; set; }

        [ProtoMember(2)]
        public bool IsSuccess { get; set; }

        [ProtoMember(3)]
        public T Result { get; set; }

        [ProtoMember(4)]
        public string Description { get; set; }

        public ReplyMessage()
        {
            Message = string.Empty;
            IsSuccess = false;
            Result = default!;
            Description = string.Empty;
        }
        public ReplyMessage(string message, bool isSuccess, T result = default!)
        {
            Message = message;
            IsSuccess = isSuccess;
            Result = result;
            Description = string.Empty;
        }
    }
}
