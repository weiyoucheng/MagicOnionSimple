using ProtoBuf;

namespace MagicOnionSimple.Dto {

    [MessagePack.MessagePackObject(true)]
    [ProtoContract]
    public class Employee {
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public string Phone { get; set; }
        [ProtoMember(4)]
        public string Email { get; set; }
        [ProtoMember(5)]
        public DateTime CreateTime { get; set; }
        public Employee() {
            Name = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            CreateTime = DateTime.Now;
        }
        public Employee(string name, string phone, string email, DateTime createTime) {
            Name = name;
            Phone = phone;
            Email = email;
            CreateTime = createTime;
        }
    }
}
