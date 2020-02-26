using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public static ProtoMessage Account_Auth_Req(long   ctidTraderAccountId,
                                                    string accessToken)
        {
            ProtoOAAccountAuthReq message = new ProtoOAAccountAuthReq
                                            {
                                                payloadType         = ProtoOAPayloadType.ProtoOaAccountAuthReq,
                                                ctidTraderAccountId = ctidTraderAccountId,
                                                accessToken         = accessToken
                                            };

            Persist(message);

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}