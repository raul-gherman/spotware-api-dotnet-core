using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public static ProtoMessage Get_Tickdata_Req(long             ctidTraderAccountId,
                                                    long             symbolId,
                                                    ProtoOAQuoteType quoteType,
                                                    long             fromTimestamp,
                                                    long             toTimestamp)
        {
            ProtoOAGetTickDataReq message = new ProtoOAGetTickDataReq
                                            {
                                                payloadType         = ProtoOAPayloadType.ProtoOaGetTickdataReq,
                                                ctidTraderAccountId = ctidTraderAccountId,
                                                symbolId            = symbolId,
                                                Type                = quoteType,
                                                fromTimestamp       = fromTimestamp,
                                                toTimestamp         = toTimestamp
                                            };

            Log.Info("ProtoOAGetTickDataReq | "                       +
                     $"ctidTraderAccountId: {ctidTraderAccountId} | " +
                     $"symbolId: {symbolId} | "                       +
                     $"quoteType: {quoteType} | "                     +
                     $"fromTimestamp: {fromTimestamp} | "             +
                     $"toTimestamp: {toTimestamp}");

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}