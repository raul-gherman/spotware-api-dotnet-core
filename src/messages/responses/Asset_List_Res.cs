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
                _log.Info($"ProtoOAAssetListRes | "                             +
                          $"ctidTraderAccountId: {args.ctidTraderAccountId} | " +
                          $"assetId: {asset.assetId} | "                        +
                          $"displayName: {asset.displayName} | "                +
                          $"Name: {asset.Name}");
            }

            OnAssetListResReceived?.Invoke(args);
        }

        public event AssetListResReceived OnAssetListResReceived;

        public delegate void AssetListResReceived(ProtoOAAssetListRes args);
    }
}