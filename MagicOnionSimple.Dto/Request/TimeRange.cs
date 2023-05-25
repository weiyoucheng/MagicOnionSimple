using ProtoBuf;
namespace MagicOnionSimple.Dto.Request {
    [MessagePack.MessagePackObject(true)]
    [ProtoContract]
    public class TimeRange {
        [ProtoMember(1)]
        public DateTime StartTime { get; set; }

        [ProtoMember(2)]
        public DateTime EndTime { get; set; }

        public TimeRange() {
            StartTime = DateTime.Now.Date;
            EndTime = StartTime.Add(new TimeSpan(23, 59, 59));
        }

        public TimeRange(DateTime startTime, DateTime endTime) {
            StartTime = startTime;
            EndTime = endTime;
        }

    }
}
