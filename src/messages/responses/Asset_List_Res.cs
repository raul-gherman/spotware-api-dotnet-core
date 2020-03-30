using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Asset_List_Res()
        {
            ProtoOAAssetListRes args = Serializer.Deserialize<ProtoOAAssetListRes>(_processorMemoryStream);

            foreach (ProtoOAAsset asset in args.Assets)
            {
                TradingAccounts[args.ctidTraderAccountId].Assets[asset.assetId] = asset;

                string item = $"assetId: {asset.assetId}; "         +
                              $"displayName: {asset.displayName}; " +
                              $"Name: {asset.Name}";

                Log.Info("ProtoOAAssetListRes:: "                             +
                         $"ctidTraderAccountId: {args.ctidTraderAccountId}; " +
                         $"Asset: [{item}]");
            }

            Send(Symbol_Category_List_Req(args.ctidTraderAccountId));

            OnAssetListResReceived?.Invoke(args);
        }

        public event AssetListResReceived OnAssetListResReceived;

        public delegate void AssetListResReceived(ProtoOAAssetListRes args);
    }
}