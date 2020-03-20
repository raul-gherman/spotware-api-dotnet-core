using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public static ProtoMessage Trader_Req(long ctidTraderAccountId)
        {
            ProtoOATraderReq message = new ProtoOATraderReq
                                       {
                                           payloadType         = ProtoOAPayloadType.ProtoOaTraderReq,
                                           ctidTraderAccountId = ctidTraderAccountId
                                       };

            Log.Info("ProtoOATraderReq | " +
                     $"ctidTraderAccountId: {ctidTraderAccountId}");

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}