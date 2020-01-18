using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public ProtoMessage Margin_Call_Update_Req(long ctid, ProtoOAMarginCall marginCall)
        {
            ProtoOAMarginCallUpdateReq message = new ProtoOAMarginCallUpdateReq
                                                 {
                                                     payloadType         = ProtoOAPayloadType.ProtoOaMarginCallUpdateReq,
                                                     ctidTraderAccountId = ctid,
                                                     marginCall          = marginCall
                                                 };

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}