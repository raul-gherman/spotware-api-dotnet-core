using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Trader_Update_Event()
        {
            ProtoOATraderUpdatedEvent args = Serializer.Deserialize<ProtoOATraderUpdatedEvent>(_processorMemoryStream);

            TradingAccounts[args.ctidTraderAccountId].Trader = args.Trader;

            Log.Info("ProtoOATraderUpdatedEvent | "                                                    +
                     $"Trader.accessRights: {args.Trader.accessRights} | "                             +
                     $"Trader.accountType: {args.Trader.accountType} | "                               +
                     $"Trader.Balance: {args.Trader.Balance} | "                                       +
                     $"Trader.balanceVersion: {args.Trader.balanceVersion} | "                         +
                     $"Trader.brokerName: {args.Trader.brokerName} | "                                 +
                     $"Trader.ibBonus: {args.Trader.ibBonus} | "                                       +
                     $"Trader.managerBonus: {args.Trader.managerBonus} | "                             +
                     $"Trader.maxLeverage: {args.Trader.maxLeverage} | "                               +
                     $"Trader.registrationTimestamp: {args.Trader.registrationTimestamp} | "           +
                     $"Trader.swapFree: {args.Trader.swapFree} | "                                     +
                     $"Trader.traderLogin: {args.Trader.traderLogin} | "                               +
                     $"Trader.depositAssetId: {args.Trader.depositAssetId} | "                         +
                     $"Trader.isLimitedRisk: {args.Trader.isLimitedRisk} | "                           +
                     $"Trader.leverageInCents: {args.Trader.leverageInCents} | "                       +
                     $"Trader.nonWithdrawableBonus: {args.Trader.nonWithdrawableBonus} | "             +
                     $"Trader.ctidTraderAccountId: {args.Trader.ctidTraderAccountId} | "               +
                     $"Trader.totalMarginCalculationType: {args.Trader.totalMarginCalculationType} | " +
                     $"Trader.limitedRiskMarginCalculationStrategy: {args.Trader.limitedRiskMarginCalculationStrategy}");

            OnTraderUpdatedEventReceived?.Invoke(args);
        }

        public event TraderUpdatedEventReceived OnTraderUpdatedEventReceived;

        public delegate void TraderUpdatedEventReceived(ProtoOATraderUpdatedEvent args);
    }
}