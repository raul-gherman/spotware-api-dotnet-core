using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public ProtoMessage Margin_Call_List_Req(long ctid)
        {
            ProtoOAMarginCallListReq message = new ProtoOAMarginCallListReq
                                               {
                                                   payloadType         = ProtoOAPayloadType.ProtoOaMarginCallListReq,
                                                   ctidTraderAccountId = ctid
                                               };

            Persist(message);

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}