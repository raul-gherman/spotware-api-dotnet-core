using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public static ProtoMessage Refresh_Token_Req(string refreshToken)
        {
            ProtoOARefreshTokenReq message = new ProtoOARefreshTokenReq
                                             {
                                                 payloadType  = ProtoOAPayloadType.ProtoOaRefreshTokenReq,
                                                 refreshToken = refreshToken
                                             };

            Persist(message);

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}