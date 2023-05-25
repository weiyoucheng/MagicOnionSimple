using System.ComponentModel.DataAnnotations;
using ProtoBuf;

namespace MagicOnionSimple.Models {

    [MessagePack.MessagePackObject(true)]
    [ProtoContract]
    public class Employee {

        [ProtoMember(1)]
        public int Id { get; set; }

        [Required]
        [StringLength(20,MinimumLength = 3,ErrorMessage = "{0} length is {1} to {2} characters")]
        [ProtoMember(2)]
        public string Name { get; set; }

        [StringLength(11, MinimumLength = 8, ErrorMessage = "{0} length is {1} to {2} characters")]
        [ProtoMember(3)]
        public string Phone { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "{0} rule error")]
        [ProtoMember(4)]
        public string Email { get; set; }

        [DisplayFormat(DataFormatString = "yyyy-MM-dd HH:mm:ss")]
        [ProtoMember(5)]
        public DateTime CreateTime { get; set; }
        public Employee() {
            //Id = 0;
            Name = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            CreateTime = DateTime.Now;
        }
        public Employee(int id, string name, string phone, string email,DateTime createTime) {
            Id = id;
            Name = name;
            Phone = phone;
            Email = email;
            CreateTime = createTime;
        }
    }
}
