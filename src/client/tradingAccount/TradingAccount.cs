using System.Collections.Generic;

namespace spotware
{
    public partial class TradingAccount
    {
        public readonly long          CtidTraderAccount;
        public          ProtoOATrader Trader { get; set; }

        public readonly Dictionary<long, ProtoOAAssetClass>     AssetClasses     = new Dictionary<long, ProtoOAAssetClass>();
        public readonly Dictionary<long, ProtoOAAsset>          Assets           = new Dictionary<long, ProtoOAAsset>();
        public readonly Dictionary<long, ProtoOASymbolCategory> SymbolCategories = new Dictionary<long, ProtoOASymbolCategory>();
        public readonly Dictionary<long, TradingSymbol>         TradingSymbols   = new Dictionary<long, TradingSymbol>();
        public readonly Dictionary<long, ProtoOAPosition>       Positions        = new Dictionary<long, ProtoOAPosition>();
        public readonly Dictionary<long, ProtoOAOrder>          Orders           = new Dictionary<long, ProtoOAOrder>();

        public TradingAccount(Client client, long ctid)
        {
            CtidTraderAccount               =  ctid;
            client.OnExecutionEventReceived += ProcessExecutionEvent;
        }
    }
}