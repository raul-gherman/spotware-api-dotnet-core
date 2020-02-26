using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public static ProtoMessage Asset_Class_List_Req(long ctidTraderAccountId)
        {
            ProtoOAAssetClassListRes message = new ProtoOAAssetClassListRes
                                               {
                                                   payloadType         = ProtoOAPayloadType.ProtoOaAssetClassListReq,
                                                   ctidTraderAccountId = ctidTraderAccountId
                                               };

            Persist(message);

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}