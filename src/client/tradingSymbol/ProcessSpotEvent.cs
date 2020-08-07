using System;

namespace spotware
{
    public partial class TradingSymbol
    {
        public event SpotEvent OnSpotEvent;

        public delegate void SpotEvent(TradingSymbol args);

        private void ProcessSpotEvent(ProtoOASpotEvent args)
        {
            if (args.ctidTraderAccountId != CtidTraderAccount)
                return;

            if (args.symbolId != LightSymbol.symbolId)
                return;

            LastTimestamp = DateTime.UtcNow;

            if (args.Ask != 0)
                Ask = args.Ask / Divider;

            if (args.Bid != 0)
                Bid = args.Bid / Divider;

            if (!(Ask > 0) || !(Bid > 0))
                return;

            IsTradable = true;
            Spread = Ask - Bid;
            SpreadInPips = (Ask - Bid) / Pip;
            Weight = Ask / Pip;

            OnSpotEvent?.Invoke(this);
        }
    }
}