using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Deal_List_Res()
        {
            ProtoOADealListRes args = Serializer.Deserialize<ProtoOADealListRes>(_processorMemoryStream);

            foreach (ProtoOADeal deal in args.Deals)
            {
                _log.Info($"ProtoOADealListRes | "                                                                    +
                          $"ctidTraderAccountId {args.ctidTraderAccountId} | "                                        +
                          $"Commission: {deal.Commission} | "                                                         +
                          $"createTimestamp: {deal.createTimestamp} | "                                               +
                          $"dealId: {deal.dealId} | "                                                                 +
                          $"dealStatus: {deal.dealStatus} | "                                                         +
                          $"executionPrice: {deal.executionPrice} | "                                                 +
                          $"executionTimestamp: {deal.executionTimestamp} | "                                         +
                          $"filledVolume: {deal.filledVolume} | "                                                     +
                          $"marginRate: {deal.marginRate} | "                                                         +
                          $"marginRate: {deal.marginRate} | "                                                         +
                          $"orderId: {deal.orderId} | "                                                               +
                          $"positionId: {deal.positionId} | "                                                         +
                          $"symbolId: {deal.symbolId} | "                                                             +
                          $"tradeSide: {deal.tradeSide} | "                                                           +
                          $"Volume: {deal.Volume} | "                                                                 +
                          $"Balance: {deal.closePositionDetail.Balance} | "                                           +
                          $"balanceVersion: {deal.closePositionDetail.balanceVersion} | "                             +
                          $"closedVolume: {deal.closePositionDetail.closedVolume} | "                                 +
                          $"Commission: {deal.closePositionDetail.Commission} | "                                     +
                          $"entryPrice: {deal.closePositionDetail.entryPrice} | "                                     +
                          $"grossProfit: {deal.closePositionDetail.grossProfit} | "                                   +
                          $"Swap: {deal.closePositionDetail.Swap} | "                                                 +
                          $"quoteToDepositConversionRate: {deal.closePositionDetail.quoteToDepositConversionRate} | " +
                          $"utcLastUpdateTimestamp: {deal.utcLastUpdateTimestamp} | "                                 +
                          $"baseToUsdConversionRate: {deal.baseToUsdConversionRate}");
            }

            OnDealListResReceived?.Invoke(args);
        }

        public event DealListResReceived OnDealListResReceived;

        public delegate void DealListResReceived(ProtoOADealListRes args);
    }
}