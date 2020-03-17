using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public static ProtoMessage Subscribe_Live_Trendbar_Req(long ctidTraderAccountId, ProtoOATrendbarPeriod period, long symbolId)
        {
            ProtoOASubscribeLiveTrendbarReq message = new ProtoOASubscribeLiveTrendbarReq
                                                      {
                                                          payloadType         = ProtoOAPayloadType.ProtoOaSubscribeLiveTrendbarReq,
                                                          ctidTraderAccountId = ctidTraderAccountId,
                                                          Period              = period,
                                                          symbolId            = symbolId
                                                      };

            Log.Info("ProtoOASubscribeLiveTrendbarReq | "             +
                     $"ctidTraderAccountId: {ctidTraderAccountId} | " +
                     $"Period: {period} | "                           +
                     $"symbolId: {symbolId}");

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}