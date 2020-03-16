using System;
using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Deal_List_Res()
        {
            ProtoOADealListRes args = Serializer.Deserialize<ProtoOADealListRes>(_processorMemoryStream);

            string Deals = String.Empty;
            foreach (ProtoOADeal deal in args.Deals)
            {
                Deals += $"Commission: {deal.Commission} | "                                                                             +
                         $"createTimestamp: {deal.createTimestamp} | "                                                                   +
                         $"dealId: {deal.dealId} | "                                                                                     +
                         $"dealStatus: {deal.dealStatus} | "                                                                             +
                         $"executionPrice: {deal.executionPrice} | "                                                                     +
                         $"executionTimestamp: {deal.executionTimestamp} | "                                                             +
                         $"filledVolume: {deal.filledVolume} | "                                                                         +
                         $"marginRate: {deal.marginRate} | "                                                                             +
                         $"orderId: {deal.orderId} | "                                                                                   +
                         $"positionId: {deal.positionId} | "                                                                             +
                         $"symbolId: {deal.symbolId} | "                                                                                 +
                         $"tradeSide: {deal.tradeSide} | "                                                                               +
                         $"Volume: {deal.Volume} | "                                                                                     +
                         $"closePositionDetail.Balance: {deal.closePositionDetail.Balance} | "                                           +
                         $"closePositionDetail.balanceVersion: {deal.closePositionDetail.balanceVersion} | "                             +
                         $"closePositionDetail.closedVolume: {deal.closePositionDetail.closedVolume} | "                                 +
                         $"closePositionDetail.Commission: {deal.closePositionDetail.Commission} | "                                     +
                         $"closePositionDetail.entryPrice: {deal.closePositionDetail.entryPrice} | "                                     +
                         $"closePositionDetail.grossProfit: {deal.closePositionDetail.grossProfit} | "                                   +
                         $"closePositionDetail.Swap: {deal.closePositionDetail.Swap} | "                                                 +
                         $"closePositionDetail.quoteToDepositConversionRate: {deal.closePositionDetail.quoteToDepositConversionRate} | " +
                         $"utcLastUpdateTimestamp: {deal.utcLastUpdateTimestamp} | "                                                     +
                         $"baseToUsdConversionRate: {deal.baseToUsdConversionRate}";
            }

            Log.Info($"ProtoOADealListRes | "                              +
                     $"ctidTraderAccountId: {args.ctidTraderAccountId} | " +
                     $"hasMore: {args.hasMore} | "                         +
                     $"Deals: {Deals}");

            OnDealListResReceived?.Invoke(args);
        }

        public event DealListResReceived OnDealListResReceived;

        public delegate void DealListResReceived(ProtoOADealListRes args);
    }
}