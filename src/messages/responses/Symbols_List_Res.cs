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
                TradingSymbol tradingSymbol = new TradingSymbol(this, args.ctidTraderAccountId)
                {
                    LightSymbol = lightSymbol
                };
                TradingAccounts[args.ctidTraderAccountId].TradingSymbols[lightSymbol.symbolId] = tradingSymbol;

                string item = $"symbolId: {lightSymbol.symbolId}; " +
                              $"symbolName: {lightSymbol.symbolName}; " +
                              $"Description: {lightSymbol.Description}; " +
                              $"Enabled: {lightSymbol.Enabled}; " +
                              $"symbolCategoryId: {lightSymbol.symbolCategoryId} ({TradingAccounts[args.ctidTraderAccountId].SymbolCategories[lightSymbol.symbolCategoryId].Name}); " +
                              $"baseAssetId: {lightSymbol.baseAssetId} ({TradingAccounts[args.ctidTraderAccountId].Assets[lightSymbol.baseAssetId].displayName}); " +
                              $"quoteAssetId: {lightSymbol.quoteAssetId} ({TradingAccounts[args.ctidTraderAccountId].Assets[lightSymbol.quoteAssetId].displayName})";

                Log.Info("ProtoOASymbolsListRes:: " +
                         $"ctidTraderAccountId: {args.ctidTraderAccountId}; " +
                         $"Symbol: [{item}]");
            }

            Send(Symbol_By_Id_Req(args.ctidTraderAccountId, TradingAccounts[args.ctidTraderAccountId].TradingSymbols.Keys.ToArray()));

            OnSymbolsListResReceived?.Invoke(args);
        }

        public event SymbolsListResReceived OnSymbolsListResReceived;

        public delegate void SymbolsListResReceived(ProtoOASymbolsListRes args);
    }
}