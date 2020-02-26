using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public static ProtoMessage Account_Logout_Req(long ctidTraderAccountId)
        {
            ProtoOAAccountLogoutReq message = new ProtoOAAccountLogoutReq
                                              {
                                                  payloadType         = ProtoOAPayloadType.ProtoOaAccountAuthReq,
                                                  ctidTraderAccountId = ctidTraderAccountId
                                              };

            Persist(message);

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}