using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Trader_Res()
        {
            ProtoOATraderRes args = Serializer.Deserialize<ProtoOATraderRes>(_processorMemoryStream);

            TradingAccounts[args.ctidTraderAccountId].Trader = args.Trader;

            Persist(args);

            Send(Reconcile_Req(args.ctidTraderAccountId));

            OnTraderResReceived?.Invoke(args);
        }

        public event TraderResReceived OnTraderResReceived;

        public delegate void TraderResReceived(ProtoOATraderRes args);
    }
}