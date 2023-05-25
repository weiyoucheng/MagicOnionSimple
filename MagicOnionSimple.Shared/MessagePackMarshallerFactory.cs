
using Grpc.Core;
using ProtoBuf.Grpc.Configuration;

namespace MagicOnionSimple.Shared {
    public class MessagePackMarshallerFactory : MarshallerFactory {
        public static MarshallerFactory Default { get; } = new MessagePackMarshallerFactory();

        public static MarshallerFactory MessagePackMarshaller => MessagePackMarshallerFactory.Default;

        protected override bool CanSerialize(Type type) {
            return true;
        }

        protected override byte[] Serialize<T>(T value) {
            return CreateMarshaller<T>().Serializer.Invoke(value);
        }

        protected override T Deserialize<T>(byte[] payload) {
            return CreateMarshaller<T>().Deserializer.Invoke(payload);
        }

        protected override Marshaller<T> CreateMarshaller<T>() {
            Marshaller<T> marshaller = new Marshaller<T>(
                x => MessagePack.MessagePackSerializer.Serialize(x), 
                x => MessagePack.MessagePackSerializer.Deserialize<T>(x)!
                );
            return marshaller;
        }
    }
}
