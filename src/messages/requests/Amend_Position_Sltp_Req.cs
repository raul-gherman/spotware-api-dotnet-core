using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public static ProtoMessage Amend_Position_SLTP_Req(long                      ctidTraderAccountId,
                                                           long                      positionId,
                                                           double                    stopLoss              = 0,
                                                           double                    takeProfit            = 0,
                                                           bool                      guaranteedStopLoss    = false,
                                                           bool                      trailingStopLoss      = false,
                                                           ProtoOAOrderTriggerMethod stopLossTriggerMethod = ProtoOAOrderTriggerMethod.Trade)
        {
            ProtoOAAmendPositionSLTPReq message = new ProtoOAAmendPositionSLTPReq
                                                  {
                                                      payloadType         = ProtoOAPayloadType.ProtoOaAmendPositionSltpReq,
                                                      ctidTraderAccountId = ctidTraderAccountId,
                                                      positionId          = positionId
                                                  };

            if (stopLoss > 0)
                message.stopLoss = stopLoss;
            if (takeProfit > 0)
                message.takeProfit = takeProfit;
            if (guaranteedStopLoss)
                message.guaranteedStopLoss = true;
            if (trailingStopLoss)
                message.trailingStopLoss = true;
            if (stopLossTriggerMethod != ProtoOAOrderTriggerMethod.Trade)
                message.stopLossTriggerMethod = stopLossTriggerMethod;

            Log.Info("Amend_Position_SLTP_Req: "                     +
                     $"ctidTraderAccountId: {ctidTraderAccountId}; " +
                     $"positionId: {positionId}; "                   +
                     $"stopLoss: {stopLoss}; "                       +
                     $"takeProfit: {takeProfit}; "                   +
                     $"guaranteedStopLoss: {guaranteedStopLoss}; "   +
                     $"trailingStopLoss: {trailingStopLoss}; "       +
                     $"stopLossTriggerMethod: {stopLossTriggerMethod}");

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}