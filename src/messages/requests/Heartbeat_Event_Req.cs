using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private static ProtoMessage Heartbeat()
        {
            ProtoHeartbeatEvent message = new ProtoHeartbeatEvent
                                          {
                                              payloadType = ProtoPayloadType.HeartbeatEvent
                                          };

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}