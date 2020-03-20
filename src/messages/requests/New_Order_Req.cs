using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        public static ProtoMessage New_Order_Req(long                      ctidTraderAccountId,
                                                 long                      symbolId,
                                                 ProtoOAOrderType          orderType,
                                                 ProtoOATradeSide          tradeSide,
                                                 long                      volume,
                                                 double                    limitPrice          = 0,
                                                 double                    stopPrice           = 0,
                                                 ProtoOATimeInForce        timeInForce         = ProtoOATimeInForce.GoodTillCancel,
                                                 long                      expirationTimestamp = 0,
                                                 double                    stopLoss            = 0,
                                                 double                    takeProfit          = 0,
                                                 string                    comment             = "",
                                                 double                    baseSlippagePrice   = 0,
                                                 int                       slippageInPoints    = 0,
                                                 string                    label               = "",
                                                 long                      positionId          = 0,
                                                 string                    clientOrderId       = "",
                                                 long                      relativeStopLoss    = 0,
                                                 long                      relativeTakeProfit  = 0,
                                                 bool                      guaranteedStopLoss  = false,
                                                 bool                      trailingStopLoss    = false,
                                                 ProtoOAOrderTriggerMethod stopTriggerMethod   = ProtoOAOrderTriggerMethod.Trade)
        {
            ProtoOANewOrderReq message = new ProtoOANewOrderReq
                                         {
                                             payloadType         = ProtoOAPayloadType.ProtoOaNewOrderReq,
                                             ctidTraderAccountId = ctidTraderAccountId,
                                             symbolId            = symbolId,
                                             orderType           = orderType,
                                             tradeSide           = tradeSide,
                                             Volume              = volume
                                         };

            if (limitPrice > 0)
                message.limitPrice = limitPrice;
            if (stopPrice > 0)
                message.stopPrice = stopPrice;
            if (timeInForce > 0)
                message.timeInForce = timeInForce;
            if (expirationTimestamp > 0)
                message.expirationTimestamp = expirationTimestamp;
            if (stopLoss > 0)
                message.stopLoss = stopLoss;
            if (takeProfit > 0)
                message.takeProfit = takeProfit;
            if (comment != "")
                message.Comment = comment;
            if (baseSlippagePrice > 0)
                message.baseSlippagePrice = baseSlippagePrice;
            if (slippageInPoints > 0)
                message.slippageInPoints = slippageInPoints;
            if (label != "")
                message.Label = label;
            if (positionId > 0)
                message.positionId = positionId;
            if (clientOrderId != "")
                message.clientOrderId = clientOrderId;
            if (relativeStopLoss != 0)
                message.relativeStopLoss = relativeStopLoss;
            if (relativeTakeProfit != 0)
                message.relativeTakeProfit = relativeTakeProfit;
            if (guaranteedStopLoss)
                message.guaranteedStopLoss = true;
            if (trailingStopLoss)
                message.trailingStopLoss = true;
            if (stopTriggerMethod != ProtoOAOrderTriggerMethod.Trade)
                message.stopTriggerMethod = stopTriggerMethod;

            Log.Info("ProtoOANewOrderReq:: "                         +
                     $"ctidTraderAccountId: {ctidTraderAccountId}; " +
                     $"symbolId: {symbolId}; "                       +
                     $"orderType: {orderType}; "                     +
                     $"tradeSide: {tradeSide}; "                     +
                     $"volume: {volume}; "                           +
                     $"limitPrice: {limitPrice}; "                   +
                     $"stopPrice: {stopPrice}; "                     +
                     $"timeInForce: {timeInForce}; "                 +
                     $"expirationTimestamp: {expirationTimestamp}; " +
                     $"stopLoss: {stopLoss}; "                       +
                     $"takeProfit: {takeProfit}; "                   +
                     $"comment: {comment}; "                         +
                     $"baseSlippagePrice: {baseSlippagePrice}; "     +
                     $"slippageInPoints: {slippageInPoints}; "       +
                     $"label: {label}; "                             +
                     $"positionId: {positionId}; "                   +
                     $"clientOrderId: {clientOrderId}; "             +
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