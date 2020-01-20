using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Symbol_Category_List_Res()
        {
            ProtoOASymbolCategoryListRes args = Serializer.Deserialize<ProtoOASymbolCategoryListRes>(_processorMemoryStream);

            foreach (var symbol in args.symbolCategories)
            {
                _log.Info($"TradingAccount: {args.ctidTraderAccountId} | " +
                          $"Id: {symbol.Id} | "                            +
                          $"Name: {symbol.Name} | "                        +
                          $"assetClassId: {symbol.assetClassId}");
            }

            OnSymbolCategoryListRes_Received?.Invoke(args);
        }

        public event SymbolCategoryListResReceived OnSymbolCategoryListRes_Received;

        public delegate void SymbolCategoryListResReceived(ProtoOASymbolCategoryListRes args);
    }
}