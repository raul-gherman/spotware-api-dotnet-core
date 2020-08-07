using System;

namespace spotware
{
    public partial class TradingSymbol
    {
        private readonly long CtidTraderAccount;

        public ProtoOALightSymbol LightSymbol;
        public ProtoOASymbol Symbol;

        public DateTime LastTimestamp { get; private set; }
        public double Bid { get; private set; }
        public double Ask { get; private set; }
        public double Spread { get; private set; }
        public double SpreadInPips { get; private set; }
        public double Weight { get; private set; }
        public bool IsTradable { get; private set; }

        public double Pip { get; set; }
        private const double Divider = 100_000;

        public TradingSymbol(Client client, long ctid)
        {
            client.OnSpotEventReceived += ProcessSpotEvent;
            CtidTraderAccount = ctid;
        }
    }
}