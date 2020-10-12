using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Symbols_For_Conversion_Res()
        {
            ProtoOASymbolsForConversionRes args = Serializer.Deserialize<ProtoOASymbolsForConversionRes>(_processorMemoryStream);

            foreach (ProtoOALightSymbol lightSymbol in args.Symbols)
            {
                string item = $"symbolId: {lightSymbol.symbolId}; "                                                                                                 +
                              $"symbolName: {lightSymbol.symbolName}; "                                                                                             +
                              $"Description: {lightSymbol.Description}; "                                                                                           +
                              $"Enabled: {lightSymbol.Enabled}; "                                                                                                   +
                              $"symbolCategoryId: {lightSymbol.symbolCategoryId} "                                                                                  +
                              $"({TradingAccounts[args.ctidTraderAccountId].SymbolCategories[lightSymbol.symbolCategoryId].Name}); "                                +
                              $"baseAssetId: {lightSymbol.baseAssetId} ({TradingAccounts[args.ctidTraderAccountId].Assets[lightSymbol.baseAssetId].displayName}); " +
                              $"quoteAssetId: {lightSymbol.quoteAssetId} ({TradingAccounts[args.ctidTraderAccountId].Assets[lightSymbol.quoteAssetId].displayName})";

                Log.Info("ProtoOASymbolsForConversionRes:: "                  +
                         $"ctidTraderAccountId: {args.ctidTraderAccountId}; " +
                         $"Symbol: [{item}]");
            }

            OnSymbolsForConversionResReceived?.Invoke(args);
        }

        public event SymbolsForConversionResReceived OnSymbolsForConversionResReceived;

        public delegate void SymbolsForConversionResReceived(ProtoOASymbolsForConversionRes args);
    }
}