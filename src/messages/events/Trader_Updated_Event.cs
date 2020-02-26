using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Trader_Update_Event()
        {
            ProtoOATraderUpdatedEvent args = Serializer.Deserialize<ProtoOATraderUpdatedEvent>(_processorMemoryStream);

            TradingAccounts[(long) args.ctidTraderAccountId].Trader = args.Trader;

            Persist(args);

            OnTraderUpdatedEventReceived?.Invoke(args);
        }

        public event TraderUpdatedEventReceived OnTraderUpdatedEventReceived;

        public delegate void TraderUpdatedEventReceived(ProtoOATraderUpdatedEvent args);
    }
}