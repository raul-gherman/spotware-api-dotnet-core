using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Symbols_For_Conversion_Res()
        {
            ProtoOASymbolsForConversionRes args = Serializer.Deserialize<ProtoOASymbolsForConversionRes>(_processorMemoryStream);

            foreach (ProtoOALightSymbol symbol in args.Symbols)
            {
                _log.Info($"TradingAccount: {args.ctidTraderAccountId} | " +
                          $"Description: {symbol.Description} | "          +
                          $"Enabled: {symbol.Enabled} | "                  +
                          $"symbolId: {symbol.symbolId} | "                +
                          $"symbolName: {symbol.symbolName} | "            +
                          $"baseAssetId: {symbol.baseAssetId} | "          +
                          $"quoteAssetId: {symbol.quoteAssetId} | "        +
                          $"symbolCategoryId: {symbol.symbolCategoryId}");
            }

            OnSymbolsForConversionRes_Received?.Invoke(args);
        }

        public event SymbolsForConversionResReceived OnSymbolsForConversionRes_Received;

        public delegate void SymbolsForConversionResReceived(ProtoOASymbolsForConversionRes args);
    }
}