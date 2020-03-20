using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public static ProtoMessage Amend_Order_Req(long                      ctidTraderAccountId,
                                                   long                      orderId,
                                                   long                      volume              = 0,
                                                   double                    limitPrice          = 0,
                                                   double                    stopPrice           = 0,
                                                   long                      expirationTimestamp = 0,
                                                   double                    stopLoss            = 0,
                                                   double                    takeProfit          = 0,
                                                   int                       slippageInPoints    = 0,
                                                   long                      relativeStopLoss    = 0,
                                                   long                      relativeTakeProfit  = 0,
                                                   bool                      guaranteedStopLoss  = false,
                                                   bool                      trailingStopLoss    = false,
                                                   ProtoOAOrderTriggerMethod stopTriggerMethod   = ProtoOAOrderTriggerMethod.Trade)
        {
            ProtoOAAmendOrderReq message = new ProtoOAAmendOrderReq
                                           {
                                               payloadType         = ProtoOAPayloadType.ProtoOaAmendOrderReq,
                                               ctidTraderAccountId = ctidTraderAccountId,
                                               orderId             = orderId
                                           };

            if (volume > 0)
                message.Volume = volume;
            if (limitPrice > 0)
                message.limitPrice = limitPrice;
            if (stopPrice > 0)
                message.stopPrice = stopPrice;
            if (expirationTimestamp > 0)
                message.expirationTimestamp = expirationTimestamp;
            if (stopLoss > 0)
                message.stopLoss = stopLoss;
            if (takeProfit > 0)
                message.takeProfit = takeProfit;
            if (slippageInPoints > 0)
                message.slippageInPoints = slippageInPoints;
            if (relativeStopLoss > 0)
                message.relativeStopLoss = relativeStopLoss;
            if (relativeTakeProfit > 0)
                message.relativeTakeProfit = relativeTakeProfit;
            if (guaranteedStopLoss)
                message.guaranteedStopLoss = true;
            if (trailingStopLoss)
                message.trailingStopLoss = true;
            if (stopTriggerMethod != ProtoOAOrderTriggerMethod.Trade)
                message.stopTriggerMethod = stopTriggerMethod;

            Log.Info("ProtoOAAmendOrderReq:: "                       +
                     $"ctidTraderAccountId: {ctidTraderAccountId}; " +
                     $"volume: {volume}; "                           +
                     $"limitPrice: {limitPrice}; "                   +
                     $"stopPrice: {stopPrice}; "                     +
                     $"expirationTimestamp: {expirationTimestamp}; " +
                     $"stopLoss: {stopLoss}; "                       +
                     $"takeProfit: {takeProfit}; "                   +
                     $"slippageInPoints: {slippageInPoints}; "       +
                     $"relativeStopLoss: {relativeStopLoss}; "       +
                     $"relativeTakeProfit: {relativeTakeProfit}; "   +
                     $"guaranteedStopLoss: {guaranteedStopLoss}; "   +
                     $"trailingStopLoss: {trailingStopLoss}; "       +
                     $"stopTriggerMethod: {stopTriggerMethod}");

            InnerMemoryStream.SetLength(0);
            Serializer.Serialize(InnerMemoryStream, message);

            return Encode((uint) message.payloadType, InnerMemoryStream.ToArray());
        }
    }
}