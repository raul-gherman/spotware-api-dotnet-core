using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public static ProtoMessage Subscribe_Spots_Req(long ctidTraderAccountId, long[] symbolIDs)
        {
            ProtoOASubscribeSpotsReq message = new ProtoOASubscribeSpotsReq
                                               {
                                                   payloadType         = ProtoOAPayloadType.ProtoOaSubscribeSpotsReq,
                                                   ctidTraderAccountId = ctidTraderAccountId,
                                                   symbolIds           = symbolIDs
                                               };

            Persist(message);

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}