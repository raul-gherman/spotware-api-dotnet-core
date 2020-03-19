using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Reconcile_Res()
        {
            ProtoOAReconcileRes args = Serializer.Deserialize<ProtoOAReconcileRes>(_processorMemoryStream);

            string Positions = string.Empty;

            foreach (ProtoOAPosition position in args.Positions)
            {
                TradingAccounts[args.ctidTraderAccountId].Positions[position.positionId] = position;

                Positions += $"Commission: {position.Commission} | "                                     +
                             $"marginRate: {position.marginRate} | "                                     +
                             $"mirroringCommission: {position.mirroringCommission} | "                   +
                             $"positionId: {position.positionId} | "                                     +
                             $"positionStatus: {position.positionStatus} | "                             +
                             $"Price: {position.Price} | "                                               +
                             $"stopLoss: {position.stopLoss} | "                                         +
                             $"Swap: {position.Swap} | "                                                 +
                             $"takeProfit: {position.takeProfit} | "                                     +
                             $"tradeData.Label: {position.tradeData.Label} | "                           +
                             $"tradeData.openTimestamp: {position.tradeData.openTimestamp} | "           +
                             $"tradeData.symbolId: {position.tradeData.symbolId} | "                     +
                             $"tradeData.tradeSide: {position.tradeData.tradeSide} | "                   +
                             $"tradeData.Volume: {position.tradeData.Volume} | "                         +
                             $"tradeData.guaranteedStopLoss: {position.tradeData.guaranteedStopLoss} | " +
                             $"usedMargin: {position.usedMargin} | "                                     +
                             $"stopLossTriggerMethod: {position.stopLossTriggerMethod} | "               +
                             $"utcLastUpdateTimestamp: {position.utcLastUpdateTimestamp} | ";
            }

            string Orders = string.Empty;

            foreach (ProtoOAOrder order in args.Orders)
            {
                TradingAccounts[args.ctidTraderAccountId].Orders[order.orderId] = order;

                Orders += $"closingOrder: {order.closingOrder} | "                                 +
                          $"executedVolume: {order.executedVolume} | "                             +
                          $"executionPrice: {order.executionPrice} | "                             +
                          $"expirationTimestamp: {order.expirationTimestamp} | "                   +
                          $"limitPrice: {order.limitPrice} | "                                     +
                          $"orderId: {order.orderId} | "                                           +
                          $"orderStatus: {order.orderStatus} | "                                   +
                          $"orderType: {order.orderType} | "                                       +
                          $"positionId: {order.positionId} | "                                     +
                          $"stopLoss: {order.stopLoss} | "                                         +
                          $"stopPrice: {order.stopPrice} | "                                       +
                          $"takeProfit: {order.takeProfit} | "                                     +
                          $"tradeData.Label: {order.tradeData.Label} | "                           +
                          $"tradeData.openTimestamp: {order.tradeData.openTimestamp} | "           +
                          $"tradeData.symbolId: {order.tradeData.symbolId} | "                     +
                          $"tradeData.tradeSide: {order.tradeData.tradeSide} | "                   +
                          $"tradeData.Volume: {order.tradeData.Volume} | "                         +
                          $"tradeData.guaranteedStopLoss: {order.tradeData.guaranteedStopLoss} | " +
                          $"baseSlippagePrice: {order.baseSlippagePrice} | "                       +
                          $"clientOrderId: {order.clientOrderId} | "                               +
                          $"isStopOut: {order.isStopOut} | "                                       +
                          $"relativeStopLoss: {order.relativeStopLoss} | "                         +
                          $"relativeTakeProfit: {order.relativeTakeProfit} | "                     +
                          $"slippageInPoints: {order.slippageInPoints} | "                         +
                          $"stopTriggerMethod: {order.stopTriggerMethod} | "                       +
                          $"timeInForce: {order.timeInForce} | "                                   +
                          $"trailingStopLoss: {order.trailingStopLoss} | "                         +
                          $"utcLastUpdateTimestamp: {order.utcLastUpdateTimestamp} | ";
            }

            Log.Info($"ProtoOAReconcileRes | "                             +
                     $"ctidTraderAccountId: {args.ctidTraderAccountId} | " +
                     $"Orders: {Orders} | "                                +
                     $"Positions: {Positions}");

            OnReconcileResReceived?.Invoke(args);

            Send(Symbols_List_Req(args.ctidTraderAccountId));
        }

        public event ReconcileResReceived OnReconcileResReceived;

        public delegate void ReconcileResReceived(ProtoOAReconcileRes args);
    }
}