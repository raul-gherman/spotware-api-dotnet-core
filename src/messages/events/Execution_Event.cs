using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Execution_Event()
        {
            ProtoOAExecutionEvent args = Serializer.Deserialize<ProtoOAExecutionEvent>(_processorMemoryStream);

            Log.Info($"ProtoOAExecutionEvent | "                                                                                               +
                     $"Deal.Commission: {args.Deal.Commission} | "                                                                             +
                     $"Deal.createTimestamp: {args.Deal.createTimestamp} | "                                                                   +
                     $"Deal.dealId: {args.Deal.dealId} | "                                                                                     +
                     $"Deal.dealStatus: {args.Deal.dealStatus} | "                                                                             +
                     $"Deal.executionPrice: {args.Deal.executionPrice} | "                                                                     +
                     $"Deal.executionTimestamp: {args.Deal.executionTimestamp} | "                                                             +
                     $"Deal.filledVolume: {args.Deal.filledVolume} | "                                                                         +
                     $"Deal.marginRate: {args.Deal.marginRate} | "                                                                             +
                     $"Deal.orderId: {args.Deal.orderId} | "                                                                                   +
                     $"Deal.positionId: {args.Deal.positionId} | "                                                                             +
                     $"Deal.symbolId: {args.Deal.symbolId} | "                                                                                 +
                     $"Deal.tradeSide: {args.Deal.tradeSide} | "                                                                               +
                     $"Deal.Volume: {args.Deal.Volume} | "                                                                                     +
                     $"Deal.closePositionDetail.Balance: {args.Deal.closePositionDetail.Balance} | "                                           +
                     $"Deal.closePositionDetail.balanceVersion: {args.Deal.closePositionDetail.balanceVersion} | "                             +
                     $"Deal.closePositionDetail.closedVolume: {args.Deal.closePositionDetail.closedVolume} | "                                 +
                     $"Deal.closePositionDetail.Commission: {args.Deal.closePositionDetail.Commission} | "                                     +
                     $"Deal.closePositionDetail.entryPrice: {args.Deal.closePositionDetail.entryPrice} | "                                     +
                     $"Deal.closePositionDetail.grossProfit: {args.Deal.closePositionDetail.grossProfit} | "                                   +
                     $"Deal.closePositionDetail.Swap: {args.Deal.closePositionDetail.Swap} | "                                                 +
                     $"Deal.closePositionDetail.quoteToDepositConversionRate: {args.Deal.closePositionDetail.quoteToDepositConversionRate} | " +
                     $"Deal.utcLastUpdateTimestamp: {args.Deal.utcLastUpdateTimestamp} | "                                                     +
                     $"Deal.baseToUsdConversionRate: {args.Deal.baseToUsdConversionRate} | "                                                   +
                     $"depositWithdraw: {args.depositWithdraw} | "                                                                             +
                     $"errorCode: {args.errorCode} | "                                                                                         +
                     $"executionType: {args.executionType} | "                                                                                 +
                     $"Order.closingOrder: {args.Order.closingOrder} | "                                                                       +
                     $"Order.executedVolume: {args.Order.executedVolume} | "                                                                   +
                     $"Order.executionPrice: {args.Order.executionPrice} | "                                                                   +
                     $"Order.expirationTimestamp: {args.Order.expirationTimestamp} | "                                                         +
                     $"Order.limitPrice: {args.Order.limitPrice} | "                                                                           +
                     $"Order.orderId: {args.Order.orderId} | "                                                                                 +
                     $"Order.orderStatus: {args.Order.orderStatus} | "                                                                         +
                     $"Order.orderType: {args.Order.orderType} | "                                                                             +
                     $"Order.positionId: {args.Order.positionId} | "                                                                           +
                     $"Order.stopLoss: {args.Order.stopLoss} | "                                                                               +
                     $"Order.stopPrice: {args.Order.stopPrice} | "                                                                             +
                     $"Order.takeProfit: {args.Order.takeProfit} | "                                                                           +
                     $"Order.tradeData.Label: {args.Order.tradeData.Label} | "                                                                 +
                     $"Order.tradeData.openTimestamp: {args.Order.tradeData.openTimestamp} | "                                                 +
                     $"Order.tradeData.symbolId: {args.Order.tradeData.symbolId} | "                                                           +
                     $"Order.tradeData.tradeSide: {args.Order.tradeData.tradeSide} | "                                                         +
                     $"Order.tradeData.Volume: {args.Order.tradeData.Volume} | "                                                               +
                     $"Order.tradeData.guaranteedStopLoss: {args.Order.tradeData.guaranteedStopLoss} | "                                       +
                     $"Order.baseSlippagePrice: {args.Order.baseSlippagePrice} | "                                                             +
                     $"Order.: {args.Order.clientOrderId} | "                                                                                  +
                     $"Order.clientOrderId: {args.Order.isStopOut} | "                                                                         +
                     $"Order.relativeStopLoss: {args.Order.relativeStopLoss} | "                                                               +
                     $"Order.relativeTakeProfit: {args.Order.relativeTakeProfit} | "                                                           +
                     $"Order.slippageInPoints: {args.Order.slippageInPoints} | "                                                               +
                     $"Order.stopTriggerMethod: {args.Order.stopTriggerMethod} | "                                                             +
                     $"Order.timeInForce: {args.Order.timeInForce} | "                                                                         +
                     $"Order.trailingStopLoss: {args.Order.trailingStopLoss} | "                                                               +
                     $"Order.utcLastUpdateTimestamp: {args.Order.utcLastUpdateTimestamp} | "                                                   +
                     $"Position.Commission: {args.Position.Commission} | "                                                                     +
                     $"Position.marginRate: {args.Position.marginRate} | "                                                                     +
                     $"Position.mirroringCommission: {args.Position.mirroringCommission} | "                                                   +
                     $"Position.positionId: {args.Position.positionId} | "                                                                     +
                     $"Position.positionStatus: {args.Position.positionStatus} | "                                                             +
                     $"Position.Price: {args.Position.Price} | "                                                                               +
                     $"Position.stopLoss: {args.Position.stopLoss} | "                                                                         +
                     $"Position.Swap: {args.Position.Swap} | "                                                                                 +
                     $"Position.takeProfit: {args.Position.takeProfit} | "                                                                     +
                     $"Position.tradeData.Label: {args.Position.tradeData.Label} | "                                                           +
                     $"Position.tradeData.openTimestamp: {args.Position.tradeData.openTimestamp} | "                                           +
                     $"Position.tradeData.symbolId: {args.Position.tradeData.symbolId} | "                                                     +
                     $"Position.tradeData.tradeSide: {args.Position.tradeData.tradeSide} | "                                                   +
                     $"Position.tradeData.Volume: {args.Position.tradeData.Volume} | "                                                         +
                     $"Position.tradeData.guaranteedStopLoss: {args.Position.tradeData.guaranteedStopLoss} | "                                 +
                     $"Position.usedMargin: {args.Position.usedMargin} | "                                                                     +
                     $"Position.guaranteedStopLoss: {args.Position.guaranteedStopLoss} | "                                                     +
                     $"Position.stopLossTriggerMethod: {args.Position.stopLossTriggerMethod} | "                                               +
                     $"Position.utcLastUpdateTimestamp: {args.Position.utcLastUpdateTimestamp} | "                                             +
                     $"bonusDepositWithdraw.externalNote: {args.bonusDepositWithdraw.externalNote} | "                                         +
                     $"bonusDepositWithdraw.ibBonus: {args.bonusDepositWithdraw.ibBonus} | "                                                   +
                     $"bonusDepositWithdraw.ibDelta: {args.bonusDepositWithdraw.ibDelta} | "                                                   +
                     $"bonusDepositWithdraw.managerBonus: {args.bonusDepositWithdraw.managerBonus} | "                                         +
                     $"bonusDepositWithdraw.managerDelta: {args.bonusDepositWithdraw.managerDelta} | "                                         +
                     $"bonusDepositWithdraw.operationType: {args.bonusDepositWithdraw.operationType} | "                                       +
                     $"bonusDepositWithdraw.bonusHistoryId: {args.bonusDepositWithdraw.bonusHistoryId} | "                                     +
                     $"bonusDepositWithdraw.changeBonusTimestamp: {args.bonusDepositWithdraw.changeBonusTimestamp} | "                         +
                     $"bonusDepositWithdraw.introducingBrokerId: {args.bonusDepositWithdraw.introducingBrokerId} | "                           +
                     $"bonusDepositWithdraw.externalNote: {args.bonusDepositWithdraw.externalNote} | "                                         +
                     $"isServerEvent: {args.isServerEvent} | "                                                                                 +
                     $"ctidTraderAccountId: {args.ctidTraderAccountId}");

            OnExecutionEventReceived?.Invoke(args);
        }

        public event ExecutionEventReceived OnExecutionEventReceived;

        public delegate void ExecutionEventReceived(ProtoOAExecutionEvent args);
    }
}