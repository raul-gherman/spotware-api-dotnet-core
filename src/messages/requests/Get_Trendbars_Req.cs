using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public static ProtoMessage Get_Trendbars_Req(long                  ctidTraderAccountId,
                                                     long                  fromTimestamp,
                                                     long                  toTimestamp,
                                                     ProtoOATrendbarPeriod period,
                                                     long                  symbolId = 0)
        {
            ProtoOAGetTrendbarsReq message = new ProtoOAGetTrendbarsReq
                                             {
                                                 payloadType         = ProtoOAPayloadType.ProtoOaGetTrendbarsReq,
                                                 ctidTraderAccountId = ctidTraderAccountId,
                                                 fromTimestamp       = fromTimestamp,
                                                 toTimestamp         = toTimestamp,
                                                 Period              = period
                                             };

            if (symbolId > 0)
                message.symbolId = symbolId;

            Log.Info("ProtoOAGetTrendbarsReq: "                      +
                     $"ctidTraderAccountId: {ctidTraderAccountId}; " +
                     $"fromTimestamp: {fromTimestamp}; "             +
                     $"toTimestamp: {toTimestamp}; "                 +
                     $"period: {period}");

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}