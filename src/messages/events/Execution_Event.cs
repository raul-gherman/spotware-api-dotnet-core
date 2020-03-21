using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Execution_Event()
        {
            ProtoOAExecutionEvent args = Serializer.Deserialize<ProtoOAExecutionEvent>(_processorMemoryStream);

            if (args.Order != null)
            {
                string executionEvent = "ProtoOAExecutionEvent:: "                                                                                               +
                                        $"ctidTraderAccountId: {args.ctidTraderAccountId}; "                                                                     +
                                        $"isServerEvent: {args.isServerEvent}; "                                                                                 +
                                        $"executionType: {args.executionType}; "                                                                                 +
                                        $"errorCode: {args.errorCode}; "                                                                                         +
                                        $"depositWithdraw: {args.depositWithdraw}; "                                                                             +
                                        $"Order: [orderId: {args.Order.orderId}; "                                                                               +
                                        $"positionId: {args.Order.positionId}; "                                                                                 +
                                        $"closingOrder: {args.Order.closingOrder}; "                                                                             +
                                        $"clientOrderId: {args.Order.clientOrderId}; "                                                                           +
                                        $"orderType: {args.Order.orderType}; "                                                                                   +
                                        $"orderStatus: {args.Order.orderStatus}; "                                                                               +
                                        $"executedVolume: {args.Order.executedVolume}; "                                                                         +
                                        $"executionPrice: {args.Order.executionPrice}; "                                                                         +
                                        $"limitPrice: {args.Order.limitPrice}; "                                                                                 +
                                        $"stopPrice: {args.Order.stopPrice}; "                                                                                   +
                                        $"stopLoss: {args.Order.stopLoss}; "                                                                                     +
                                        $"takeProfit: {args.Order.takeProfit}; "                                                                                 +
                                        $"relativeStopLoss: {args.Order.relativeStopLoss}; "                                                                     +
                                        $"relativeTakeProfit: {args.Order.relativeTakeProfit}; "                                                                 +
                                        $"trailingStopLoss: {args.Order.trailingStopLoss}; "                                                                     +
                                        $"baseSlippagePrice: {args.Order.baseSlippagePrice}; "                                                                   +
                                        $"slippageInPoints: {args.Order.slippageInPoints}; "                                                                     +
                                        $"isStopOut: {args.Order.isStopOut}; "                                                                                   +
                                        $"timeInForce: {args.Order.timeInForce}; "                                                                               +
                                        $"tradeData.symbolId: {args.Order.tradeData.symbolId}; "                                                                 +
                                        $"tradeData.tradeSide: {args.Order.tradeData.tradeSide}; "                                                               +
                                        $"tradeData.Volume: {args.Order.tradeData.Volume}; "                                                                     +
                                        $"tradeData.Label: {args.Order.tradeData.Label}; "                                                                       +
                                        $"tradeData.guaranteedStopLoss: {args.Order.tradeData.guaranteedStopLoss}; "                                             +
                                        $"tradeData.openTimestamp: {args.Order.tradeData.openTimestamp} ({EpochToString(args.Order.tradeData.openTimestamp)}); " +
                                        $"expirationTimestamp: {args.Order.expirationTimestamp} ({EpochToString(args.Order.expirationTimestamp)}); "             +
                                        $"stopTriggerMethod: {args.Order.stopTriggerMethod}]";
                Log.Info(executionEvent);
            }

            if (args.Position != null)
            {
                string executionEvent = "ProtoOAExecutionEvent:: "                                                                                                     +
                                        $"ctidTraderAccountId: {args.ctidTraderAccountId}; "                                                                           +
                                        $"executionType: {args.executionType}; "                                                                                       +
                                        $"isServerEvent: {args.isServerEvent}; "                                                                                       +
                                        $"errorCode: {args.errorCode}; "                                                                                               +
                                        $"depositWithdraw: {args.depositWithdraw}; "                                                                                   +
                                        $"Position: [positionId: {args.Position.positionId}; "                                                                         +
                                        $"positionStatus: {args.Position.positionStatus}; "                                                                            +
                                        $"Price: {args.Position.Price}; "                                                                                              +
                                        $"stopLoss: {args.Position.stopLoss}; "                                                                                        +
                                        $"takeProfit: {args.Position.takeProfit}; "                                                                                    +
                                        $"Swap: {args.Position.Swap}; "                                                                                                +
                                        $"Commission: {args.Position.Commission}; "                                                                                    +
                                        $"mirroringCommission: {args.Position.mirroringCommission}; "                                                                  +
                                        $"marginRate: {args.Position.marginRate}; "                                                                                    +
                                        $"usedMargin: {args.Position.usedMargin}; "                                                                                    +
                                        $"guaranteedStopLoss: {args.Position.guaranteedStopLoss}; "                                                                    +
                                        $"tradeData.openTimestamp: {args.Position.tradeData.openTimestamp} ({EpochToString(args.Position.tradeData.openTimestamp)}); " +
                                        $"tradeData.symbolId: {args.Position.tradeData.symbolId}; "                                                                    +
                                        $"tradeData.tradeSide: {args.Position.tradeData.tradeSide}; "                                                                  +
                                        $"tradeData.Volume: {args.Position.tradeData.Volume}; "                                                                        +
                                        $"tradeData.guaranteedStopLoss: {args.Position.tradeData.guaranteedStopLoss}; "                                                +
                                        $"tradeData.Label: {args.Position.tradeData.Label}; "                                                                          +
                                        $"stopLossTriggerMethod: {args.Position.stopLossTriggerMethod}; "                                                              +
                                        $"utcLastUpdateTimestamp: {args.Position.utcLastUpdateTimestamp} ({EpochToString(args.Position.utcLastUpdateTimestamp)})]";
                Log.Info(executionEvent);
            }

            if (args.Deal != null)
            {
                string executionEvent = "ProtoOAExecutionEvent:: "                                                                                          +
                                        $"ctidTraderAccountId: {args.ctidTraderAccountId}; "                                                                +
                                        $"executionType: {args.executionType}; "                                                                            +
                                        $"isServerEvent: {args.isServerEvent}; "                                                                            +
                                        $"errorCode: {args.errorCode}; "                                                                                    +
                                        $"depositWithdraw: {args.depositWithdraw}; "                                                                        +
                                        $"Deal: [dealId: {args.Deal.dealId}; "                                                                              +
                                        $"dealStatus: {args.Deal.dealStatus}; "                                                                             +
                                        $"positionId: {args.Deal.positionId}; "                                                                             +
                                        $"orderId: {args.Deal.orderId}; "                                                                                   +
                                        $"symbolId: {args.Deal.symbolId}; "                                                                                 +
                                        $"tradeSide: {args.Deal.tradeSide}; "                                                                               +
                                        $"Volume: {args.Deal.Volume}; "                                                                                     +
                                        $"filledVolume: {args.Deal.filledVolume}; "                                                                         +
                                        $"executionPrice: {args.Deal.executionPrice}; "                                                                     +
                                        $"createTimestamp: {args.Deal.createTimestamp}; "                                                                   +
                                        $"executionTimestamp: {args.Deal.executionTimestamp} ({EpochToString(args.Deal.executionTimestamp)}); "             +
                                        $"Commission: {args.Deal.Commission}; "                                                                             +
                                        $"marginRate: {args.Deal.marginRate}; "                                                                             +
                                        $"closePositionDetail.Balance: {args.Deal.closePositionDetail.Balance}; "                                           +
                                        $"closePositionDetail.balanceVersion: {args.Deal.closePositionDetail.balanceVersion}; "                             +
                                        $"closePositionDetail.entryPrice: {args.Deal.closePositionDetail.entryPrice}; "                                     +
                                        $"closePositionDetail.closedVolume: {args.Deal.closePositionDetail.closedVolume}; "                                 +
                                        $"closePositionDetail.Commission: {args.Deal.closePositionDetail.Commission}; "                                     +
                                        $"closePositionDetail.Swap: {args.Deal.closePositionDetail.Swap}; "                                                 +
                                        $"closePositionDetail.grossProfit: {args.Deal.closePositionDetail.grossProfit}; "                                   +
                                        $"closePositionDetail.quoteToDepositConversionRate: {args.Deal.closePositionDetail.quoteToDepositConversionRate}; " +
                                        $"baseToUsdConversionRate: {args.Deal.baseToUsdConversionRate}; "                                                   +
                                        $"utcLastUpdateTimestamp: {args.Deal.utcLastUpdateTimestamp} ({EpochToString(args.Deal.utcLastUpdateTimestamp)})]";
                Log.Info(executionEvent);
            }

            if (args.bonusDepositWithdraw != null)
            {
                string executionEvent =
                    "ProtoOAExecutionEvent:: "                                                                                                                                         +
                    $"ctidTraderAccountId: {args.ctidTraderAccountId}; "                                                                                                               +
                    $"executionType: {args.executionType}; "                                                                                                                           +
                    $"isServerEvent: {args.isServerEvent}; "                                                                                                                           +
                    $"errorCode: {args.errorCode}; "                                                                                                                                   +
                    $"depositWithdraw: {args.depositWithdraw}; "                                                                                                                       +
                    $"Bonus: [bonusDepositWithdraw.operationType: {args.bonusDepositWithdraw.operationType}; "                                                                         +
                    $"bonusDepositWithdraw.bonusHistoryId: {args.bonusDepositWithdraw.bonusHistoryId}; "                                                                               +
                    $"bonusDepositWithdraw.changeBonusTimestamp: {args.bonusDepositWithdraw.changeBonusTimestamp} ({EpochToString(args.bonusDepositWithdraw.changeBonusTimestamp)}); " +
                    $"bonusDepositWithdraw.externalNote: {args.bonusDepositWithdraw.externalNote}; "                                                                                   +
                    $"bonusDepositWithdraw.ibBonus: {args.bonusDepositWithdraw.ibBonus}; "                                                                                             +
                    $"bonusDepositWithdraw.ibDelta: {args.bonusDepositWithdraw.ibDelta}; "                                                                                             +
                    $"bonusDepositWithdraw.managerBonus: {args.bonusDepositWithdraw.managerBonus}; "                                                                                   +
                    $"bonusDepositWithdraw.managerDelta: {args.bonusDepositWithdraw.managerDelta}; "                                                                                   +
                    $"bonusDepositWithdraw.introducingBrokerId: {args.bonusDepositWithdraw.introducingBrokerId}; "                                                                     +
                    $"bonusDepositWithdraw.externalNote: {args.bonusDepositWithdraw.externalNote}]";
                Log.Info(executionEvent);
            }

            OnExecutionEventReceived?.Invoke(args);
        }

        public event ExecutionEventReceived OnExecutionEventReceived;

        public delegate void ExecutionEventReceived(ProtoOAExecutionEvent args);
    }
}