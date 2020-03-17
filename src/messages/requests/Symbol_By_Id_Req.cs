using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public static ProtoMessage Symbol_By_Id_Req(long ctidTraderAccountId, long[] symbolIDs)
        {
            ProtoOASymbolByIdReq message = new ProtoOASymbolByIdReq
                                           {
                                               payloadType         = ProtoOAPayloadType.ProtoOaSymbolByIdReq,
                                               ctidTraderAccountId = ctidTraderAccountId,
                                               symbolIds           = symbolIDs
                                           };

            Log.Info("ProtoOASymbolByIdReq | "                        +
                     $"ctidTraderAccountId: {ctidTraderAccountId} | " +
                     $"symbolIds: [{string.Join(" | ", symbolIDs)}]");

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}