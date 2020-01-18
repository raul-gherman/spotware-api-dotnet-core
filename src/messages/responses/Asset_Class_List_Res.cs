using ProtoBuf;

namespace spotware
{
    public partial class Client
    {
        private void Process_Asset_Class_List_Res()
        {
            ProtoOAAssetClassListRes args = Serializer.Deserialize<ProtoOAAssetClassListRes>(_processorMemoryStream);

            foreach (ProtoOAAssetClass asset_class in args.assetClasses)
            {
                _log.Info($"{args.ctidTraderAccountId} assetClass: {asset_class.Id} {asset_class.Name}");
            }

            OnAssetClassListRes_Received?.Invoke(args);
        }

        public event AssetClassListResReceived OnAssetClassListRes_Received;

        public delegate void AssetClassListResReceived(ProtoOAAssetClassListRes args);
    }
}