using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public static ProtoMessage Version_Req()
        {
            ProtoOAVersionReq message = new ProtoOAVersionReq
                                        {
                                            payloadType = ProtoOAPayloadType.ProtoOaVersionReq
                                        };

            Persist(message);

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}