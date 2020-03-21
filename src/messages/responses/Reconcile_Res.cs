using System.Linq;
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

                string item = $"positionId: {position.positionId}; "                                                                                                                                  +
                              $"positionStatus: {position.positionStatus}; "                                                                                                                          +
                              $"Price: {position.Price}; "                                                                                                                                            +
                              $"stopLoss: {position.stopLoss}; "                                                                                                                                      +
                              $"takeProfit: {position.takeProfit}; "                                                                                                                                  +
                              $"usedMargin: {position.usedMargin}; "                                                                                                                                  +
                              $"marginRate: {position.marginRate}; "                                                                                                                                  +
                              $"Swap: {position.Swap}; "                                                                                                                                              +
                              $"Commission: {position.Commission}; "                                                                                                                                  +
                              $"mirroringCommission: {position.mirroringCommission}; "                                                                                                                +
                              $"tradeData.symbolId: {position.tradeData.symbolId} ({TradingAccounts[args.ctidTraderAccountId].TradingSymbols[position.tradeData.symbolId].LightSymbol.symbolName}); " +
                              $"tradeData.tradeSide: {position.tradeData.tradeSide}; "                                                                                                                +
                              $"tradeData.Volume: {position.tradeData.Volume}; "                                                                                                                      +
                              $"tradeData.guaranteedStopLoss: {position.tradeData.guaranteedStopLoss}; "                                                                                              +
                              $"tradeData.openTimestamp: {position.tradeData.openTimestamp} ({EpochToString(position.tradeData.openTimestamp)}; "                                                     +
                              $"tradeData.Label: {position.tradeData.Label}; "                                                                                                                        +
                              $"stopLossTriggerMethod: {position.stopLossTriggerMethod}; "                                                                                                            +
                              $"utcLastUpdateTimestamp: {position.utcLastUpdateTimestamp} ({EpochToString(position.utcLastUpdateTimestamp)}";

                Log.Info($"ProtoOAReconcileRes:: "                            +
                         $"ctidTraderAccountId: {args.ctidTraderAccountId}; " +
                         $"Position: {item}");
            }

            foreach (ProtoOAOrder order in args.Orders)
            {
                TradingAccounts[args.ctidTraderAccountId].Orders[order.orderId] = order;

                string item = $"orderId: {order.orderId}; "                                                                                                                                     +
                              $"orderType: {order.orderType}; "                                                                                                                                 +
                              $"orderStatus: {order.orderStatus}; "                                                                                                                             +
                              $"positionId: {order.positionId}; "                                                                                                                               +
                              $"closingOrder: {order.closingOrder}; "                                                                                                                           +
                              $"executedVolume: {order.executedVolume}; "                                                                                                                       +
                              $"executionPrice: {order.executionPrice}; "                                                                                                                       +
                              $"stopLoss: {order.stopLoss}; "                                                                                                                                   +
                              $"takeProfit: {order.takeProfit}; "                                                                                                                               +
                              $"limitPrice: {order.limitPrice}; "                                                                                                                               +
                              $"stopPrice: {order.stopPrice}; "                                                                                                                                 +
                              $"expirationTimestamp: {order.expirationTimestamp} ({EpochToString(order.expirationTimestamp)}); "                                                                +
                              $"tradeData.Label: {order.tradeData.Label}; "                                                                                                                     +
                              $"tradeData.openTimestamp: {order.tradeData.openTimestamp} ({EpochToString(order.tradeData.openTimestamp)}); "                                                    +
                              $"tradeData.symbolId: {order.tradeData.symbolId} ({TradingAccounts[args.ctidTraderAccountId].TradingSymbols[order.tradeData.symbolId].LightSymbol.symbolName}); " +
                              $"tradeData.tradeSide: {order.tradeData.tradeSide}; "                                                                                                             +
                              $"tradeData.Volume: {order.tradeData.Volume}; "                                                                                                                   +
                              $"tradeData.guaranteedStopLoss: {order.tradeData.guaranteedStopLoss}; "                                                                                           +
                              $"baseSlippagePrice: {order.baseSlippagePrice}; "                                                                                                                 +
                              $"clientOrderId: {order.clientOrderId}; "                                                                                                                         +
                              $"isStopOut: {order.isStopOut}; "                                                                                                                                 +
                              $"relativeStopLoss: {order.relativeStopLoss}; "                                                                                                                   +
                              $"relativeTakeProfit: {order.relativeTakeProfit}; "                                                                                                               +
                              $"slippageInPoints: {order.slippageInPoints}; "                                                                                                                   +
                              $"stopTriggerMethod: {order.stopTriggerMethod}; "                                                                                                                 +
                              $"timeInForce: {order.timeInForce}; "                                                                                                                             +
                              $"trailingStopLoss: {order.trailingStopLoss}; "                                                                                                                   +
                              $"utcLastUpdateTimestamp: {order.utcLastUpdateTimestamp} ({EpochToString(order.utcLastUpdateTimestamp)})";

                Log.Info($"ProtoOAReconcileRes:: "                            +
                         $"ctidTraderAccountId: {args.ctidTraderAccountId}; " +
                         $"Order: {item};");
            }

            if (_subscribeAllSymbols)
            {
                Send(Subscribe_Spots_Req(args.ctidTraderAccountId, TradingAccounts[args.ctidTraderAccountId].TradingSymbols.Keys.ToArray()));
            }

            OnReconcileResReceived?.Invoke(args);
        }

        public event ReconcileResReceived OnReconcileResReceived;

        public delegate void ReconcileResReceived(ProtoOAReconcileRes args);
    }
}