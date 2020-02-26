using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public static ProtoMessage Unsubscribe_Spots_Req(long ctidTraderAccountId, long[] symbolIDs)
        {
            ProtoOAUnsubscribeSpotsReq message = new ProtoOAUnsubscribeSpotsReq
                                                 {
                                                     payloadType         = ProtoOAPayloadType.ProtoOaUnsubscribeSpotsReq,
                                                     ctidTraderAccountId = ctidTraderAccountId,
                                                     symbolIds           = symbolIDs
                                                 };

            Persist(message);

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}