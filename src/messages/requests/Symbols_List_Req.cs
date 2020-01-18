using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public static ProtoMessage Symbols_List_Req(long ctidTraderAccountId)
        {
            ProtoOASymbolsListReq message = new ProtoOASymbolsListReq
                                            {
                                                payloadType         = ProtoOAPayloadType.ProtoOaSymbolsListReq,
                                                ctidTraderAccountId = ctidTraderAccountId
                                            };

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}