using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public static ProtoMessage Get_Ctid_Profile_By_Token_Req(string accessToken)
        {
            ProtoOAGetCtidProfileByTokenReq message = new ProtoOAGetCtidProfileByTokenReq
                                                      {
                                                          payloadType = ProtoOAPayloadType.ProtoOaGetCtidProfileByTokenReq,
                                                          accessToken = accessToken
                                                      };

            Persist(message);

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}