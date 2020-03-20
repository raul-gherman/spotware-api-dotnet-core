using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public static ProtoMessage Application_Auth_Req(string clientId,
                                                        string clientSecret)
        {
            ProtoOAApplicationAuthReq message = new ProtoOAApplicationAuthReq
                                                {
                                                    payloadType  = ProtoOAPayloadType.ProtoOaApplicationAuthReq,
                                                    clientId     = clientId,
                                                    clientSecret = clientSecret
                                                };

            Log.Info("ProtoOAApplicationAuthReq: "  +
                     $"clientId: {clientId}; "      +
                     $"clientSecret: {clientSecret}");

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}