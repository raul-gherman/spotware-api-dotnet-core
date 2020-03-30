using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public static ProtoMessage Get_Accounts_By_Access_Token_Req(string accessToken)
        {
            ProtoOAGetAccountListByAccessTokenReq message = new ProtoOAGetAccountListByAccessTokenReq
                                                            {
                                                                payloadType = ProtoOAPayloadType.ProtoOaGetAccountsByAccessTokenReq,
                                                                accessToken = accessToken
                                                            };

            Log.Info("ProtoOAGetAccountListByAccessTokenReq:: " +
                     $"accessToken: {accessToken}");

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}