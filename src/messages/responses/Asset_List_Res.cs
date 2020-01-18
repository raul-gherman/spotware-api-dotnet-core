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
                _log.Info($"{args.ctidTraderAccountId} | assetId: {asset.assetId} | displayName: {asset.displayName} | Name: {asset.Name}");
            }

            OnAssetListRes_Received?.Invoke(args);
        }

        public event AssetListResReceived OnAssetListRes_Received;

        public delegate void AssetListResReceived(ProtoOAAssetListRes args);
    }
}