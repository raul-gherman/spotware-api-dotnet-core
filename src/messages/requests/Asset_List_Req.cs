using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public static ProtoMessage Asset_List_Req(long ctidTraderAccountId)
        {
            ProtoOAAssetListReq message = new ProtoOAAssetListReq
                                          {
                                              payloadType         = ProtoOAPayloadType.ProtoOaAssetListReq,
                                              ctidTraderAccountId = ctidTraderAccountId
                                          };

            Persist(message);

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}