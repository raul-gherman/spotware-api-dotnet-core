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
                _log.Info($"ProtoOAAssetClassListRes | "                        +
                          $"ctidTraderAccountId: {args.ctidTraderAccountId} | " +
                          $"asset_class.Id: {assetClass.Id} | "                 +
                          $"asset_class.Name: {assetClass.Name}");
            }

            OnAssetClassListResReceived?.Invoke(args);
        }

        public event AssetClassListResReceived OnAssetClassListResReceived;

        public delegate void AssetClassListResReceived(ProtoOAAssetClassListRes args);
    }
}