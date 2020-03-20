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
                string Symbols = string.Empty;
                Symbols += $"symbolId: {lightSymbol.symbolId}; "                 +
                           $"symbolName: {lightSymbol.symbolName}; "             +
                           $"Description: {lightSymbol.Description}; "           +
                           $"Enabled: {lightSymbol.Enabled}; "                   +
                           $"symbolCategoryId: {lightSymbol.symbolCategoryId}; " +
                           $"baseAssetId: {lightSymbol.baseAssetId}; "           +
                           $"quoteAssetId: {lightSymbol.quoteAssetId} | ";

                Log.Info("ProtoOASymbolsForConversionRes:: "                  +
                         $"ctidTraderAccountId: {args.ctidTraderAccountId}; " +
                         $"Symbol: {Symbols}");
            }

            OnSymbolsForConversionResReceived?.Invoke(args);
        }

        public event SymbolsForConversionResReceived OnSymbolsForConversionResReceived;

        public delegate void SymbolsForConversionResReceived(ProtoOASymbolsForConversionRes args);
    }
}