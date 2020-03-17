using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public static ProtoMessage Expected_Margin_Req(long   ctidTraderAccountId,
                                                       long   symbolId,
                                                       long[] volumes)
        {
            ProtoOAExpectedMarginReq message = new ProtoOAExpectedMarginReq
                                               {
                                                   payloadType         = ProtoOAPayloadType.ProtoOaExpectedMarginReq,
                                                   ctidTraderAccountId = ctidTraderAccountId,
                                                   symbolId            = symbolId,
                                                   Volumes             = volumes
                                               };

            Log.Info("ProtoOAExpectedMarginReq | "                    +
                     $"ctidTraderAccountId: {ctidTraderAccountId} | " +
                     $"symbolId: {symbolId} | "                       +
                     $"Volumes: [{string.Join(" | ", volumes)}]");

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}