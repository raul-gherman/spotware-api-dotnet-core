using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public static ProtoMessage Deal_List_Req(long ctidTraderAccountId,
                                                 long fromTimestamp,
                                                 long toTimestamp,
                                                 int  maxRows = 0)
        {
            ProtoOADealListReq message = new ProtoOADealListReq
                                         {
                                             payloadType         = ProtoOAPayloadType.ProtoOaDealListReq,
                                             ctidTraderAccountId = ctidTraderAccountId,
                                             fromTimestamp       = fromTimestamp,
                                             toTimestamp         = toTimestamp
                                         };

            if (maxRows > 0)
                message.maxRows = maxRows;

            Log.Info("ProtoOADealListReq | "                          +
                     $"ctidTraderAccountId: {ctidTraderAccountId} | " +
                     $"fromTimestamp: {fromTimestamp} | "             +
                     $"toTimestamp: {toTimestamp} | "                 +
                     $"maxRows: {maxRows}");

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}