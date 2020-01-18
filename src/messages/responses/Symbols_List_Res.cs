using System.Linq;
using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Symbols_List_Res()
        {
            ProtoOASymbolsListRes args = Serializer.Deserialize<ProtoOASymbolsListRes>(_processorMemoryStream);

            foreach (ProtoOALightSymbol lightSymbol in args.Symbols)
            {
                if (lightSymbol.Enabled)
                {
                    TradingSymbol tradingSymbol = new TradingSymbol(this, args.ctidTraderAccountId)
                    {
                        LightSymbol = lightSymbol
                    };
                    TradingAccounts[args.ctidTraderAccountId].TradingSymbols[lightSymbol.symbolId] = tradingSymbol;

                    _log.Info($"TradingAccount {args.ctidTraderAccountId} | TradingSymbol {lightSymbol.symbolId} {lightSymbol.symbolName} : {lightSymbol.Description} | enabled");
                }
                else
                {
                    _log.Info($"TradingAccount {args.ctidTraderAccountId} | TradingSymbol {lightSymbol.symbolId} {lightSymbol.symbolName} : {lightSymbol.Description} | disabled");
                }
            }

            Send(Symbol_By_Id_Req(args.ctidTraderAccountId, TradingAccounts[args.ctidTraderAccountId].TradingSymbols.Keys.ToArray()));

            OnSymbolsListRes_Received?.Invoke(args);
        }

        public event SymbolsListResReceived OnSymbolsListRes_Received;

        public delegate void SymbolsListResReceived(ProtoOASymbolsListRes args);
    }
}