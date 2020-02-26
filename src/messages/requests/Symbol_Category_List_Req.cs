using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public static ProtoMessage Symbol_Category_List_Req(long ctidTraderAccountId)
        {
            ProtoOASymbolCategoryListReq message = new ProtoOASymbolCategoryListReq
                                                   {
                                                       payloadType         = ProtoOAPayloadType.ProtoOaSymbolCategoryReq,
                                                       ctidTraderAccountId = ctidTraderAccountId
                                                   };

            Persist(message);

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}