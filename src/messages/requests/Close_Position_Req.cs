using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public static ProtoMessage Close_Position_Req(long ctidTraderAccountId,
                                                      long positionId,
                                                      long volume)
        {
            ProtoOAClosePositionReq message = new ProtoOAClosePositionReq
                                              {
                                                  payloadType         = ProtoOAPayloadType.ProtoOaClosePositionReq,
                                                  ctidTraderAccountId = ctidTraderAccountId,
                                                  positionId          = positionId,
                                                  Volume              = volume
                                              };

            Log.Info("ProtoOAClosePositionReq | "                     +
                     $"ctidTraderAccountId: {ctidTraderAccountId} | " +
                     $"positionId: {positionId} | "                   +
                     $"volume: {volume}");

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}