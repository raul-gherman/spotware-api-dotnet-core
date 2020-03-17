using System;
using System.Linq;
using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Symbols_List_Res()
        {
            ProtoOASymbolsListRes args = Serializer.Deserialize<ProtoOASymbolsListRes>(_processorMemoryStream);
            
            string Symbols = String.Empty;

            foreach (ProtoOALightSymbol lightSymbol in args.Symbols)
            {
                if (!lightSymbol.Enabled)
                    continue;
                TradingSymbol tradingSymbol = new TradingSymbol(this, args.ctidTraderAccountId)
                                              {
                                                  LightSymbol = lightSymbol
                                              };
                TradingAccounts[args.ctidTraderAccountId].TradingSymbols[lightSymbol.symbolId] = tradingSymbol;
                
                Symbols += $"Description: {lightSymbol.Description} | "   +
                           $"Enabled: {lightSymbol.Enabled} | "           +
                           $"symbolId: {lightSymbol.symbolId} | "         +
                           $"symbolName: {lightSymbol.symbolName} | "     +
                           $"baseAssetId: {lightSymbol.baseAssetId} | "   +
                           $"quoteAssetId: {lightSymbol.quoteAssetId} | " +
                           $"symbolCategoryId: {lightSymbol.symbolCategoryId} | ";
            }

            Log.Info("ProtoOASymbolsListRes | "                            +
                     $"ctidTraderAccountId: {args.ctidTraderAccountId} | " +
                     $"Symbols: [{Symbols}]");

            Send(Symbol_By_Id_Req(args.ctidTraderAccountId, TradingAccounts[args.ctidTraderAccountId].TradingSymbols.Keys.ToArray()));

            OnSymbolsListResReceived?.Invoke(args);
        }

        public event SymbolsListResReceived OnSymbolsListResReceived;

        public delegate void SymbolsListResReceived(ProtoOASymbolsListRes args);
    }
}