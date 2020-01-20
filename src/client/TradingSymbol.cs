namespace spotware
{
    public class TradingSymbol
    {
        private readonly long CtidTraderAccount;

        public ProtoOALightSymbol LightSymbol;
        public ProtoOASymbol      Symbol;

        public decimal Bid          { get; private set; }
        public decimal Ask          { get; private set; }
        public decimal Spread       { get; private set; }
        public decimal SpreadInPips { get; private set; }

        public        decimal Pip { get; set; }
        private const decimal DIVIDER = 100000;

        public event SpotEvent OnSpotEvent;

        public delegate void SpotEvent(TradingSymbol args);

        public TradingSymbol(Client client, long ctid)
        {
            client.OnSpotEvent_Received += OnSpotEvent_Received;
            CtidTraderAccount           =  ctid;
        }

        private void OnSpotEvent_Received(ProtoOASpotEvent args)
        {
            if (args.ctidTraderAccountId != CtidTraderAccount)
                return;

            if (args.symbolId != LightSymbol.symbolId)
                return;

            if (args.Ask != 0)
                Ask = args.Ask / DIVIDER;

            if (args.Bid != 0)
                Bid = args.Bid / DIVIDER;

            if (!(Ask > 0) || !(Bid > 0))
                return;

            Spread       = Ask - Bid;
            SpreadInPips = (Ask - Bid) / Pip;
            OnSpotEvent?.Invoke(this);
        }
    }
}