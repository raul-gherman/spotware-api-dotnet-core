using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Asset_Class_List_Res()
        {
            ProtoOAAssetClassListRes args = Serializer.Deserialize<ProtoOAAssetClassListRes>(_processorMemoryStream);

            foreach (ProtoOAAssetClass assetClass in args.assetClasses)
            {
                TradingAccounts[args.ctidTraderAccountId].AssetClasses[assetClass.Id] = assetClass;

                string item = $"Id: {assetClass.Id}; " +
                              $"Name: {assetClass.Name}";

                Log.Info("ProtoOAAssetClassListRes:: "                        +
                         $"ctidTraderAccountId: {args.ctidTraderAccountId}; " +
                         $"assetClass: [{item}]");
            }

            Send(Asset_List_Req(args.ctidTraderAccountId));

            OnAssetClassListResReceived?.Invoke(args);
        }

        public event AssetClassListResReceived OnAssetClassListResReceived;

        public delegate void AssetClassListResReceived(ProtoOAAssetClassListRes args);
    }
}