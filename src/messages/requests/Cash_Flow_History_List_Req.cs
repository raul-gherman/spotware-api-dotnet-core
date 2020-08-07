using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public static ProtoMessage Cash_Flow_History_List_Req(long ctidTraderAccountId,
                                                              long fromTimestamp,
                                                              long toTimestamp)
        {
            ProtoOACashFlowHistoryListReq message = new ProtoOACashFlowHistoryListReq
            {
                payloadType = ProtoOAPayloadType.ProtoOaCashFlowHistoryListReq,
                ctidTraderAccountId = ctidTraderAccountId,
                fromTimestamp = fromTimestamp,
                toTimestamp = toTimestamp
            };

            Log.Info("ProtoOACashFlowHistoryListReq:: " +
                     $"ctidTraderAccountId: {ctidTraderAccountId}; " +
                     $"fromTimestamp: {fromTimestamp} ({EpochToString(fromTimestamp)}; " +
                     $"toTimestamp: {toTimestamp} ({EpochToString(toTimestamp)}");

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint)message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}