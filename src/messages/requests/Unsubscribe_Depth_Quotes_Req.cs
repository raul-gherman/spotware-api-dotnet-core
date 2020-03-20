using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public static ProtoMessage Unsubscribe_Depth_Quotes_Req(long ctidTraderAccountId, long[] symbolIDs)
        {
            ProtoOAUnsubscribeDepthQuotesReq message = new ProtoOAUnsubscribeDepthQuotesReq
                                                       {
                                                           payloadType         = ProtoOAPayloadType.ProtoOaUnsubscribeDepthQuotesReq,
                                                           ctidTraderAccountId = ctidTraderAccountId,
                                                           symbolIds           = symbolIDs
                                                       };

            Log.Info("ProtoOAUnsubscribeDepthQuotesReq | "            +
                     $"ctidTraderAccountId: {ctidTraderAccountId} | " +
                     $"symbolIDs: [{string.Join(" | ", symbolIDs)}]");

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}