using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public static ProtoMessage Refresh_Token_Req(string refresh_token)
        {
            ProtoOARefreshTokenReq message = new ProtoOARefreshTokenReq
                                             {
                                                 payloadType  = ProtoOAPayloadType.ProtoOaRefreshTokenReq,
                                                 refreshToken = refresh_token
                                             };

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}