using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Trader_Update_Event()
        {
            ProtoOATraderUpdatedEvent args = Serializer.Deserialize<ProtoOATraderUpdatedEvent>(_processorMemoryStream);

            TradingAccounts[(long) args.ctidTraderAccountId].Trader = args.Trader;

            _log.Info($"ProtoOATraderUpdatedEvent | "                                  +
                      $"ctidTraderAccountId: {args.ctidTraderAccountId} | "            +
                      $"accessRights: {args.Trader.accessRights} | "                   +
                      $"accountType: {args.Trader.accountType} | "                     +
                      $"Balance: {args.Trader.Balance} | "                             +
                      $"balanceVersion: {args.Trader.balanceVersion} | "               +
                      $"brokerName: {args.Trader.brokerName} | "                       +
                      $"frenchRisk: {args.Trader.frenchRisk} | "                       +
                      $"ibBonus: {args.Trader.ibBonus} | "                             +
                      $"managerBonus: {args.Trader.managerBonus} | "                   +
                      $"maxLeverage: {args.Trader.maxLeverage} | "                     +
                      $"registrationTimestamp: {args.Trader.registrationTimestamp} | " +
                      $"swapFree: {args.Trader.swapFree} | "                           +
                      $"traderLogin: {args.Trader.traderLogin} | "                     +
                      $"depositAssetId: {args.Trader.depositAssetId} | "               +
                      $"leverageInCents: {args.Trader.leverageInCents} | "             +
                      $"nonWithdrawableBonus: {args.Trader.nonWithdrawableBonus} | "   +
                      $"totalMarginCalculationType: {args.Trader.totalMarginCalculationType}");

            OnTraderUpdatedEventReceived?.Invoke(args);
        }

        public event TraderUpdatedEventReceived OnTraderUpdatedEventReceived;

        public delegate void TraderUpdatedEventReceived(ProtoOATraderUpdatedEvent args);
    }
}