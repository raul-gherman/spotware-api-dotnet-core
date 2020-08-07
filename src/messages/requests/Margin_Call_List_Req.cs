using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public ProtoMessage Margin_Call_List_Req(long ctidTraderAccountId)
        {
            ProtoOAMarginCallListReq message = new ProtoOAMarginCallListReq
            {
                payloadType = ProtoOAPayloadType.ProtoOaMarginCallListReq,
                ctidTraderAccountId = ctidTraderAccountId
            };

            Log.Info("ProtoOAMarginCallListReq:: " +
                     $"ctidTraderAccountId: {ctidTraderAccountId}");

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint)message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}