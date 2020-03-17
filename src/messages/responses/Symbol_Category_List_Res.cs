using System;
using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Symbol_Category_List_Res()
        {
            ProtoOASymbolCategoryListRes args = Serializer.Deserialize<ProtoOASymbolCategoryListRes>(_processorMemoryStream);

            string symbolCategories = String.Empty;
            foreach (ProtoOASymbolCategory symbolCategory in args.symbolCategories)
            {
                symbolCategories += $"Id: {symbolCategory.Id} | "     +
                                    $"Name: {symbolCategory.Name} | " +
                                    $"assetClassId: {symbolCategory.assetClassId} | ";
            }

            Log.Info("ProtoOASymbolCategoryListRes | "                     +
                     $"ctidTraderAccountId: {args.ctidTraderAccountId} | " +
                     $"symbolCategories: [{symbolCategories}]");

            OnSymbolCategoryListResReceived?.Invoke(args);
        }

        public event SymbolCategoryListResReceived OnSymbolCategoryListResReceived;

        public delegate void SymbolCategoryListResReceived(ProtoOASymbolCategoryListRes args);
    }
}