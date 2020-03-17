using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public static ProtoMessage Cancel_Order_Req(long ctidTraderAccountId,
                                                    long orderId)
        {
            ProtoOACancelOrderReq message = new ProtoOACancelOrderReq
                                            {
                                                payloadType         = ProtoOAPayloadType.ProtoOaCancelOrderReq,
                                                ctidTraderAccountId = ctidTraderAccountId,
                                                orderId             = orderId
                                            };

            Log.Info("ProtoOACancelOrderReq | "                       +
                     $"ctidTraderAccountId: {ctidTraderAccountId} | " +
                     $"orderId: {orderId}");

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}