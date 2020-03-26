namespace spotware
{
    public class TradingSymbol
    {
        private readonly long CtidTraderAccount;

        public ProtoOALightSymbol LightSymbol;
        public ProtoOASymbol      Symbol;

        public double Bid          { get; private set; }
        public double Ask          { get; private set; }
        public double Spread       { get; private set; }
        public double SpreadInPips { get; private set; }
        public double Weight       { get; private set; }
        public bool   IsTradable   { get; private set; }

        public        double Pip { get; set; }
        private const double Divider = 100_000;

        public event SpotEvent OnSpotEvent;

        public delegate void SpotEvent(TradingSymbol args);

        public TradingSymbol(Client client, long ctid)
        {
            client.OnSpotEventReceived += OnSpotEvent_Received;
            CtidTraderAccount          =  ctid;
        }

        private void OnSpotEvent_Received(ProtoOASpotEvent args)
        {
            if (args.ctidTraderAccountId != CtidTraderAccount)
                return;

            if (args.symbolId != LightSymbol.symbolId)
                return;

            if (args.Ask != 0)
                Ask = args.Ask / Divider;

            if (args.Bid != 0)
                Bid = args.Bid / Divider;

            if (!(Ask > 0) || !(Bid > 0))
                return;
            IsTradable   = true;
            Spread       = Ask - Bid;
            SpreadInPips = (Ask - Bid) / Pip;
            Weight       = Ask         / Pip;

            OnSpotEvent?.Invoke(this);
        }
    }
}