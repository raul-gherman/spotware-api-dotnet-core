using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Execution_Event()
        {
            ProtoOAExecutionEvent args = Serializer.Deserialize<ProtoOAExecutionEvent>(_processorMemoryStream);

            string executionEvent = "ProtoOAExecutionEvent | "                            +
                                    $"ctidTraderAccountId: {args.ctidTraderAccountId} | " +
                                    $"executionType: {args.executionType} | "             +
                                    $"isServerEvent: {args.isServerEvent} | "             +
                                    $"errorCode: {args.errorCode} | "                     +
                                    $"depositWithdraw: {args.depositWithdraw} | ";

            executionEvent += "Orders: [";
            if (args.Order != null)
            {
                executionEvent += $"closingOrder: {args.Order.closingOrder} | "                                 +
                                  $"executedVolume: {args.Order.executedVolume} | "                             +
                                  $"executionPrice: {args.Order.executionPrice} | "                             +
                                  $"expirationTimestamp: {args.Order.expirationTimestamp} | "                   +
                                  $"limitPrice: {args.Order.limitPrice} | "                                     +
                                  $"orderId: {args.Order.orderId} | "                                           +
                                  $"orderStatus: {args.Order.orderStatus} | "                                   +
                                  $"orderType: {args.Order.orderType} | "                                       +
                                  $"positionId: {args.Order.positionId} | "                                     +
                                  $"stopLoss: {args.Order.stopLoss} | "                                         +
                                  $"stopPrice: {args.Order.stopPrice} | "                                       +
                                  $"takeProfit: {args.Order.takeProfit} | "                                     +
                                  $"tradeData.Label: {args.Order.tradeData.Label} | "                           +
                                  $"tradeData.openTimestamp: {args.Order.tradeData.openTimestamp} | "           +
                                  $"tradeData.symbolId: {args.Order.tradeData.symbolId} | "                     +
                                  $"tradeData.tradeSide: {args.Order.tradeData.tradeSide} | "                   +
                                  $"tradeData.Volume: {args.Order.tradeData.Volume} | "                         +
                                  $"tradeData.guaranteedStopLoss: {args.Order.tradeData.guaranteedStopLoss} | " +
                                  $"baseSlippagePrice: {args.Order.baseSlippagePrice} | "                       +
                                  $"clientOrderId: {args.Order.clientOrderId} | "                               +
                                  $"clientOrderId: {args.Order.isStopOut} | "                                   +
                                  $"isStopOut: {args.Order.relativeStopLoss} | "                                +
                                  $"relativeTakeProfit: {args.Order.relativeTakeProfit} | "                     +
                                  $"slippageInPoints: {args.Order.slippageInPoints} | "                         +
                                  $"stopTriggerMethod: {args.Order.stopTriggerMethod} | "                       +
                                  $"timeInForce: {args.Order.timeInForce} | "                                   +
                                  $"trailingStopLoss: {args.Order.trailingStopLoss}";
            }

            executionEvent += "] ";
            executionEvent += "Positions: [";
            if (args.Position != null)
            {
                executionEvent += $"Commission: {args.Position.Commission} | "                                     +
                                  $"marginRate: {args.Position.marginRate} | "                                     +
                                  $"mirroringCommission: {args.Position.mirroringCommission} | "                   +
                                  $"positionId: {args.Position.positionId} | "                                     +
                                  $"positionStatus: {args.Position.positionStatus} | "                             +
                                  $"Price: {args.Position.Price} | "                                               +
                                  $"stopLoss: {args.Position.stopLoss} | "                                         +
                                  $"Swap: {args.Position.Swap} | "                                                 +
                                  $"takeProfit: {args.Position.takeProfit} | "                                     +
                                  $"tradeData.Label: {args.Position.tradeData.Label} | "                           +
                                  $"tradeData.openTimestamp: {args.Position.tradeData.openTimestamp} | "           +
                                  $"tradeData.symbolId: {args.Position.tradeData.symbolId} | "                     +
                                  $"tradeData.tradeSide: {args.Position.tradeData.tradeSide} | "                   +
                                  $"tradeData.Volume: {args.Position.tradeData.Volume} | "                         +
                                  $"tradeData.guaranteedStopLoss: {args.Position.tradeData.guaranteedStopLoss} | " +
                                  $"usedMargin: {args.Position.usedMargin} | "                                     +
                                  $"guaranteedStopLoss: {args.Position.guaranteedStopLoss} | "                     +
                                  $"stopLossTriggerMethod: {args.Position.stopLossTriggerMethod} | "               +
                                  $"utcLastUpdateTimestamp: {args.Position.utcLastUpdateTimestamp}";
            }

            executionEvent += "] ";
            executionEvent += "Deals: [";
            if (args.Deal != null)
            {
                executionEvent += $"Commission: {args.Deal.Commission} | "                                                                             +
                                  $"createTimestamp: {args.Deal.createTimestamp} | "                                                                   +
                                  $"dealId: {args.Deal.dealId} | "                                                                                     +
                                  $"dealStatus: {args.Deal.dealStatus} | "                                                                             +
                                  $"executionPrice: {args.Deal.executionPrice} | "                                                                     +
                                  $"executionTimestamp: {args.Deal.executionTimestamp} | "                                                             +
                                  $"filledVolume: {args.Deal.filledVolume} | "                                                                         +
                                  $"marginRate: {args.Deal.marginRate} | "                                                                             +
                                  $"orderId: {args.Deal.orderId} | "                                                                                   +
                                  $"positionId: {args.Deal.positionId} | "                                                                             +
                                  $"symbolId: {args.Deal.symbolId} | "                                                                                 +
                                  $"tradeSide: {args.Deal.tradeSide} | "                                                                               +
                                  $"Volume: {args.Deal.Volume} | "                                                                                     +
                                  $"closePositionDetail.Balance: {args.Deal.closePositionDetail.Balance} | "                                           +
                                  $"closePositionDetail.balanceVersion: {args.Deal.closePositionDetail.balanceVersion} | "                             +
                                  $"closePositionDetail.closedVolume: {args.Deal.closePositionDetail.closedVolume} | "                                 +
                                  $"closePositionDetail.Commission: {args.Deal.closePositionDetail.Commission} | "                                     +
                                  $"closePositionDetail.entryPrice: {args.Deal.closePositionDetail.entryPrice} | "                                     +
                                  $"closePositionDetail.grossProfit: {args.Deal.closePositionDetail.grossProfit} | "                                   +
                                  $"closePositionDetail.Swap: {args.Deal.closePositionDetail.Swap} | "                                                 +
                                  $"closePositionDetail.quoteToDepositConversionRate: {args.Deal.closePositionDetail.quoteToDepositConversionRate} | " +
                                  $"utcLastUpdateTimestamp: {args.Deal.utcLastUpdateTimestamp} | "                                                     +
                                  $"baseToUsdConversionRate: {args.Deal.baseToUsdConversionRate}";
            }

            executionEvent += "] ";
            executionEvent += "Bonuses: [";
            if (args.bonusDepositWithdraw != null)
            {
                executionEvent += $"bonusDepositWithdraw.externalNote: {args.bonusDepositWithdraw.externalNote} | "                 +
                                  $"bonusDepositWithdraw.ibBonus: {args.bonusDepositWithdraw.ibBonus} | "                           +
                                  $"bonusDepositWithdraw.ibDelta: {args.bonusDepositWithdraw.ibDelta} | "                           +
                                  $"bonusDepositWithdraw.managerBonus: {args.bonusDepositWithdraw.managerBonus} | "                 +
                                  $"bonusDepositWithdraw.managerDelta: {args.bonusDepositWithdraw.managerDelta} | "                 +
                                  $"bonusDepositWithdraw.operationType: {args.bonusDepositWithdraw.operationType} | "               +
                                  $"bonusDepositWithdraw.bonusHistoryId: {args.bonusDepositWithdraw.bonusHistoryId} | "             +
                                  $"bonusDepositWithdraw.changeBonusTimestamp: {args.bonusDepositWithdraw.changeBonusTimestamp} | " +
                                  $"bonusDepositWithdraw.introducingBrokerId: {args.bonusDepositWithdraw.introducingBrokerId} | "   +
                                  $"bonusDepositWithdraw.externalNote: {args.bonusDepositWithdraw.externalNote}";
            }

            executionEvent += "] ";

            Log.Info(executionEvent);

            OnExecutionEventReceived?.Invoke(args);
        }

        public event ExecutionEventReceived OnExecutionEventReceived;

        public delegate void ExecutionEventReceived(ProtoOAExecutionEvent args);
    }
}