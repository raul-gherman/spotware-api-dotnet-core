using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Trader_Update_Event()
        {
            ProtoOATraderUpdatedEvent args = Serializer.Deserialize<ProtoOATraderUpdatedEvent>(_processorMemoryStream);

            TradingAccounts[args.ctidTraderAccountId].Trader = args.Trader;

            Log.Info("ProtoOATraderUpdatedEvent: "                                             +
                     $"ctidTraderAccountId: {args.Trader.ctidTraderAccountId}; "               +
                     $"brokerName: {args.Trader.brokerName}; "                                 +
                     $"traderLogin: {args.Trader.traderLogin}; "                               +
                     $"accountType: {args.Trader.accountType}; "                               +
                     $"accessRights: {args.Trader.accessRights}; "                             +
                     $"Balance: {args.Trader.Balance}; "                                       +
                     $"balanceVersion: {args.Trader.balanceVersion}; "                         +
                     $"ibBonus: {args.Trader.ibBonus}; "                                       +
                     $"managerBonus: {args.Trader.managerBonus}; "                             +
                     $"leverageInCents: {args.Trader.leverageInCents}; "                       +
                     $"maxLeverage: {args.Trader.maxLeverage}; "                               +
                     $"swapFree: {args.Trader.swapFree}; "                                     +
                     $"depositAssetId: {args.Trader.depositAssetId}; "                         +
                     $"registrationTimestamp: {args.Trader.registrationTimestamp}; "           +
                     $"nonWithdrawableBonus: {args.Trader.nonWithdrawableBonus}; "             +
                     $"totalMarginCalculationType: {args.Trader.totalMarginCalculationType}; " +
                     $"isLimitedRisk: {args.Trader.isLimitedRisk}; "                           +
                     $"limitedRiskMarginCalculationStrategy: {args.Trader.limitedRiskMarginCalculationStrategy}");

            OnTraderUpdatedEventReceived?.Invoke(args);
        }

        public event TraderUpdatedEventReceived OnTraderUpdatedEventReceived;

        public delegate void TraderUpdatedEventReceived(ProtoOATraderUpdatedEvent args);
    }
}