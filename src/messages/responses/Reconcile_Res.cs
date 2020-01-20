using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Reconcile_Res()
        {
            ProtoOAReconcileRes args = Serializer.Deserialize<ProtoOAReconcileRes>(_processorMemoryStream);

            foreach (ProtoOAPosition position in args.Positions)
            {
                TradingAccounts[args.ctidTraderAccountId].Positions[position.positionId] = position;

                _log.Info($"TradingAccount: {args.ctidTraderAccountId} | "                  +
                          $"Commission: {position.Commission} | "                           +
                          $"marginRate: {position.marginRate} | "                           +
                          $"mirroringCommission: {position.mirroringCommission} | "         +
                          $"positionId: {position.positionId} | "                           +
                          $"positionStatus: {position.positionStatus} | "                   +
                          $"Price: {position.Price} | "                                     +
                          $"stopLoss: {position.stopLoss} | "                               +
                          $"Swap: {position.Swap} | "                                       +
                          $"takeProfit: {position.takeProfit} | "                           +
                          $"Label: {position.tradeData.Label} | "                           +
                          $"openTimestamp: {position.tradeData.openTimestamp} | "           +
                          $"symbolId: {position.tradeData.symbolId} | "                     +
                          $"tradeSide: {position.tradeData.tradeSide} | "                   +
                          $"Volume: {position.tradeData.Volume} | "                         +
                          $"guaranteedStopLoss: {position.tradeData.guaranteedStopLoss} | " + // TODO: should raise a ticket, position.tradeData.guaranteedStopLoss overlaps position.guaranteedStopLoss
                          $"usedMargin: {position.usedMargin} | "                           +
                          $"guaranteedStopLoss: {position.guaranteedStopLoss} | "           +
                          $"stopLossTriggerMethod: {position.stopLossTriggerMethod} | "     +
                          $"utcLastUpdateTimestamp: {position.utcLastUpdateTimestamp}");
            }

            foreach (ProtoOAOrder order in args.Orders)
            {
                TradingAccounts[args.ctidTraderAccountId].Orders[order.orderId] = order;

                _log.Info($"TradingAccount: {args.ctidTraderAccountId} | "               +
                          $"closingOrder: {order.closingOrder} | "                       +
                          $"executedVolume: {order.executedVolume} | "                   +
                          $"executionPrice: {order.executionPrice} | "                   +
                          $"expirationTimestamp: {order.expirationTimestamp} | "         +
                          $"limitPrice: {order.limitPrice} | "                           +
                          $"orderId: {order.orderId} | "                                 +
                          $"orderStatus: {order.orderStatus} | "                         +
                          $"orderType: {order.orderType} | "                             +
                          $"positionId: {order.positionId} | "                           +
                          $"stopLoss: {order.stopLoss} | "                               +
                          $"stopPrice: {order.stopPrice} | "                             +
                          $"takeProfit: {order.takeProfit} | "                           +
                          $"Label: {order.tradeData.Label} | "                           +
                          $"openTimestamp: {order.tradeData.openTimestamp} | "           +
                          $"symbolId: {order.tradeData.symbolId} | "                     +
                          $"tradeSide: {order.tradeData.tradeSide} | "                   +
                          $"Volume: {order.tradeData.Volume} | "                         +
                          $"guaranteedStopLoss: {order.tradeData.guaranteedStopLoss} | " +
                          $"baseSlippagePrice: {order.baseSlippagePrice} | "             +
                          $"clientOrderId: {order.clientOrderId} | "                     +
                          $"isStopOut: {order.isStopOut} | "                             +
                          $"relativeStopLoss: {order.relativeStopLoss} | "               +
                          $"relativeTakeProfit: {order.relativeTakeProfit} | "           +
                          $"slippageInPoints: {order.slippageInPoints} | "               +
                          $"stopTriggerMethod: {order.stopTriggerMethod} | "             +
                          $"timeInForce: {order.timeInForce} | "                         +
                          $"trailingStopLoss: {order.trailingStopLoss} | "               +
                          $"utcLastUpdateTimestamp: {order.utcLastUpdateTimestamp}");


                OnReconcileRes_Received?.Invoke(args);
            }

            Send(Symbols_List_Req(args.ctidTraderAccountId));
        }

        public event ReconcileResReceived OnReconcileRes_Received;

        public delegate void ReconcileResReceived(ProtoOAReconcileRes args);
    }
}