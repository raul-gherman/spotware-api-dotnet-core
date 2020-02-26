using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public static ProtoMessage Reconcile_Req(long ctidTraderAccountId)
        {
            ProtoOAReconcileReq message = new ProtoOAReconcileReq
                                          {
                                              payloadType         = ProtoOAPayloadType.ProtoOaReconcileReq,
                                              ctidTraderAccountId = ctidTraderAccountId
                                          };

            Persist(message);

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}