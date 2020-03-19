using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Symbols_For_Conversion_Res()
        {
            ProtoOASymbolsForConversionRes args = Serializer.Deserialize<ProtoOASymbolsForConversionRes>(_processorMemoryStream);

            string Symbols = string.Empty;
            foreach (ProtoOALightSymbol lightSymbol in args.Symbols)
            {
                Symbols += $"Description: {lightSymbol.Description} | "   +
                           $"Enabled: {lightSymbol.Enabled} | "           +
                           $"symbolId: {lightSymbol.symbolId} | "         +
                           $"symbolName: {lightSymbol.symbolName} | "     +
                           $"baseAssetId: {lightSymbol.baseAssetId} | "   +
                           $"quoteAssetId: {lightSymbol.quoteAssetId} | " +
                           $"symbolCategoryId: {lightSymbol.symbolCategoryId} | ";
            }

            Log.Info("ProtoOASymbolsForConversionRes | "                   +
                     $"ctidTraderAccountId: {args.ctidTraderAccountId} | " +
                     $"Symbols: [{Symbols}]");

            OnSymbolsForConversionResReceived?.Invoke(args);
        }

        public event SymbolsForConversionResReceived OnSymbolsForConversionResReceived;

        public delegate void SymbolsForConversionResReceived(ProtoOASymbolsForConversionRes args);
    }
}