using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Asset_List_Res()
        {
            ProtoOAAssetListRes args = Serializer.Deserialize<ProtoOAAssetListRes>(_processorMemoryStream);

            string Assets = string.Empty;
            foreach (ProtoOAAsset asset in args.Assets)
            {
                Assets += $"assetId: {asset.assetId} | "         +
                          $"displayName: {asset.displayName} | " +
                          $"Name: {asset.Name}";
            }

            Log.Info("ProtoOAAssetListRes | "                              +
                     $"ctidTraderAccountId: {args.ctidTraderAccountId} | " +
                     $"Assets: [{Assets}]");

            OnAssetListResReceived?.Invoke(args);
        }

        public event AssetListResReceived OnAssetListResReceived;

        public delegate void AssetListResReceived(ProtoOAAssetListRes args);
    }
}