using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Symbol_Category_List_Res()
        {
            ProtoOASymbolCategoryListRes args = Serializer.Deserialize<ProtoOASymbolCategoryListRes>(_processorMemoryStream);

            foreach (ProtoOASymbolCategory symbolCategory in args.symbolCategories)
            {
                TradingAccounts[args.ctidTraderAccountId].SymbolCategories[symbolCategory.Id] = symbolCategory;

                string item = $"Id: {symbolCategory.Id}; " +
                              $"Name: {symbolCategory.Name}; " +
                              $"assetClassId: {symbolCategory.assetClassId} ({TradingAccounts[args.ctidTraderAccountId].AssetClasses[symbolCategory.assetClassId].Name})";

                Log.Info("ProtoOASymbolCategoryListRes:: " +
                         $"ctidTraderAccountId: {args.ctidTraderAccountId}; " +
                         $"symbolCategory: [{item}]");
            }

            Send(Symbols_List_Req(args.ctidTraderAccountId));

            OnSymbolCategoryListResReceived?.Invoke(args);
        }

        public event SymbolCategoryListResReceived OnSymbolCategoryListResReceived;

        public delegate void SymbolCategoryListResReceived(ProtoOASymbolCategoryListRes args);
    }
}