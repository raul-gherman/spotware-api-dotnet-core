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
                string Deals = string.Empty;
                Deals += $"dealId: {deal.dealId}; "                                                                                     +
                         $"dealStatus: {deal.dealStatus}; "                                                                             +
                         $"orderId: {deal.orderId}; "                                                                                   +
                         $"positionId: {deal.positionId}; "                                                                             +
                         $"symbolId: {deal.symbolId}; "                                                                                 +
                         $"tradeSide: {deal.tradeSide}; "                                                                               +
                         $"executionPrice: {deal.executionPrice}; "                                                                     +
                         $"Volume: {deal.Volume}; "                                                                                     +
                         $"filledVolume: {deal.filledVolume}; "                                                                         +
                         $"marginRate: {deal.marginRate}; "                                                                             +
                         $"Commission: {deal.Commission}; "                                                                             +
                         $"createTimestamp: {deal.createTimestamp}; "                                                                   +
                         $"executionTimestamp: {deal.executionTimestamp}; "                                                             +
                         $"closePositionDetail.Balance: {deal.closePositionDetail.Balance}; "                                           +
                         $"closePositionDetail.balanceVersion: {deal.closePositionDetail.balanceVersion}; "                             +
                         $"closePositionDetail.closedVolume: {deal.closePositionDetail.closedVolume}; "                                 +
                         $"closePositionDetail.entryPrice: {deal.closePositionDetail.entryPrice}; "                                     +
                         $"closePositionDetail.quoteToDepositConversionRate: {deal.closePositionDetail.quoteToDepositConversionRate}; " +
                         $"closePositionDetail.Swap: {deal.closePositionDetail.Swap}; "                                                 +
                         $"closePositionDetail.Commission: {deal.closePositionDetail.Commission}; "                                     +
                         $"closePositionDetail.grossProfit: {deal.closePositionDetail.grossProfit}; "                                   +
                         $"utcLastUpdateTimestamp: {deal.utcLastUpdateTimestamp}; "                                                     +
                         $"baseToUsdConversionRate: {deal.baseToUsdConversionRate}";

                Log.Info("ProtoOADealListRes:: "                              +
                         $"ctidTraderAccountId: {args.ctidTraderAccountId}; " +
                         $"Deal: {Deals}; "                                   +
                         $"hasMore: {args.hasMore}");
            }

            OnDealListResReceived?.Invoke(args);
        }

        public event DealListResReceived OnDealListResReceived;

        public delegate void DealListResReceived(ProtoOADealListRes args);
    }
}