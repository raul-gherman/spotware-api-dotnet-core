using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public ProtoMessage Margin_Call_Update_Req(long ctidTraderAccountId, ProtoOAMarginCall marginCall)
        {
            ProtoOAMarginCallUpdateReq message = new ProtoOAMarginCallUpdateReq
                                                 {
                                                     payloadType         = ProtoOAPayloadType.ProtoOaMarginCallUpdateReq,
                                                     ctidTraderAccountId = ctidTraderAccountId,
                                                     marginCall          = marginCall
                                                 };

            Log.Info("ProtoOAMarginCallUpdateReq:: "                 +
                     $"ctidTraderAccountId: {ctidTraderAccountId}; " +
                     $"marginCall: {marginCall}");

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}