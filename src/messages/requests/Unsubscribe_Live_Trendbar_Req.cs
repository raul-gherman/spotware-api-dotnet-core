using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public static ProtoMessage Unsubscribe_Live_Trendbar_Req(long ctidTraderAccountId, ProtoOATrendbarPeriod period, long symbolId)
        {
            ProtoOAUnsubscribeLiveTrendbarReq message = new ProtoOAUnsubscribeLiveTrendbarReq
                                                        {
                                                            payloadType         = ProtoOAPayloadType.ProtoOaUnsubscribeLiveTrendbarReq,
                                                            ctidTraderAccountId = ctidTraderAccountId,
                                                            Period              = period,
                                                            symbolId            = symbolId
                                                        };

            Persist(message);

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}