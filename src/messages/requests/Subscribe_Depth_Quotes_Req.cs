using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public static ProtoMessage Subscribe_Depth_Quotes_Req(long ctidTraderAccountId, long[] symbolIDs)
        {
            ProtoOASubscribeDepthQuotesReq message = new ProtoOASubscribeDepthQuotesReq
                                                     {
                                                         payloadType         = ProtoOAPayloadType.ProtoOaSubscribeDepthQuotesReq,
                                                         ctidTraderAccountId = ctidTraderAccountId,
                                                         symbolIds           = symbolIDs
                                                     };

            Log.Info("ProtoOASubscribeDepthQuotesReq: "              +
                     $"ctidTraderAccountId: {ctidTraderAccountId}; " +
                     $"symbolIds: [{string.Join("; ", symbolIDs)}]");

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}