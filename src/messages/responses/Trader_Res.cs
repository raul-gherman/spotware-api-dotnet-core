using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Trader_Res()
        {
            ProtoOATraderRes args = Serializer.Deserialize<ProtoOATraderRes>(_processorMemoryStream);

            TradingAccounts[args.ctidTraderAccountId].Trader = args.Trader;

            Log.Info("ProtoOATraderRes | "                                                      +
                     $"ctidTraderAccountId: {args.ctidTraderAccountId} | "                      +
                     $"brokerName: {args.Trader.brokerName} | "                                 +
                     $"traderLogin: {args.Trader.traderLogin} | "                               +
                     $"accountType: {args.Trader.accountType} | "                               +
                     $"accessRights: {args.Trader.accessRights} | "                             +
                     $"Balance: {args.Trader.Balance} | "                                       +
                     $"balanceVersion: {args.Trader.balanceVersion} | "                         +
                     $"ibBonus: {args.Trader.ibBonus} | "                                       +
                     $"managerBonus: {args.Trader.managerBonus} | "                             +
                     $"maxLeverage: {args.Trader.maxLeverage} | "                               +
                     $"swapFree: {args.Trader.swapFree} | "                                     +
                     $"depositAssetId: {args.Trader.depositAssetId} | "                         +
                     $"isLimitedRisk: {args.Trader.isLimitedRisk} | "                           +
                     $"leverageInCents: {args.Trader.leverageInCents} | "                       +
                     $"registrationTimestamp: {args.Trader.registrationTimestamp} | "           +
                     $"nonWithdrawableBonus: {args.Trader.nonWithdrawableBonus} | "             +
                     $"ctidTraderAccountId: {args.Trader.ctidTraderAccountId} | "               +
                     $"totalMarginCalculationType: {args.Trader.totalMarginCalculationType} | " +
                     $"limitedRiskMarginCalculationStrategy: {args.Trader.limitedRiskMarginCalculationStrategy}");

            Send(Reconcile_Req(args.ctidTraderAccountId));

            OnTraderResReceived?.Invoke(args);
        }

        public event TraderResReceived OnTraderResReceived;

        public delegate void TraderResReceived(ProtoOATraderRes args);
    }
}