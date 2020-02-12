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
                _log.Info($"SymbolCategoryListRes | "                           +
                          $"ctidTraderAccountId: {args.ctidTraderAccountId} | " +
                          $"Id: {symbolCategory.Id} | "                         +
                          $"Name: {symbolCategory.Name} | "                     +
                          $"assetClassId: {symbolCategory.assetClassId}");
            }

            OnSymbolCategoryListResReceived?.Invoke(args);
        }

        public event SymbolCategoryListResReceived OnSymbolCategoryListResReceived;

        public delegate void SymbolCategoryListResReceived(ProtoOASymbolCategoryListRes args);
    }
}